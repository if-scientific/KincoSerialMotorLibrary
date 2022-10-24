using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KincoSerialRS232;
using System.IO.Ports;
using System.Threading;
namespace ActualTestingProject
{

    public class MotorControl
    {
        private SerialPort port;
        private KincoSerial motor;

        private const uint encoderResolution = 10000;
        private const uint encoderRotation = 400000;
        private const double perI = 200;

        public MotorControl(string comPort) {
            port = new SerialPort("COM" + comPort);
            // configure serial port
            port.BaudRate = 38400;
            port.WriteTimeout = 1000;
            port.ReadTimeout = 1000;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.Open();

            motor = new KincoSerial(1, port);
        }

        public double oneTurn(uint speed)
        {
            // Turn the motor off
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_OFF);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_ON);
            motor.writeToRegister(Constants.OPERATION_MODE, Constants.OPERATION_MODE_POSITION_CONTROL);
            motor.writeToRegister(Constants.TARGET_POSITION, encoderRotation);
            motor.writeToRegister(Constants.PROFILE_SPEED, speed);
            motor.writeToRegister(Constants.PROFILE_ACC, 0x000080000);
            motor.writeToRegister(Constants.PROFILE_DEC, 0x00008000);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON | 0x4F);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON | 0x5F);
            Thread.Sleep(100);
            double position = this.getMotorPosition();
            return position;
        }

        public bool targetReached() {
            uint status = motor.readFromRegister(Constants.STATUS_WORD);
            return (status & 0x0400) != 0x0400 ? false : true;
        }
        public void stopAndReset() {
            stopMotor();
            Thread.Sleep(100);
            this.goToZero();
        }


        public bool goToZero()
        {
            // Turn the motor off
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_OFF);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_ON);
            motor.writeToRegister(Constants.OPERATION_MODE, Constants.OPERATION_MODE_POSITION_CONTROL);
            motor.writeToRegister(Constants.TARGET_POSITION, 0);
            motor.writeToRegister(Constants.PROFILE_SPEED, 0x00090000);
            motor.writeToRegister(Constants.PROFILE_ACC, 0x00080000);
            motor.writeToRegister(Constants.PROFILE_DEC, 0x00008000);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON | 0x2F);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON | 0x3F);
            uint status = 0;
            while ((status & 0x0400) != 0x0400)
            {
                status = motor.readFromRegister(Constants.STATUS_WORD);
                // need to check for errors.
            }
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_OFF);
            return true;
        }


        public Int32 getMotorPosition()
        {
            Int32 position = motor.readFromRegisterInt(Constants.POS_ACTUAL);
            return position;
        }

        public void runAtRPM(double speed, int direction) {
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_OFF);
            motor.writeToRegister(Constants.OPERATION_MODE, Constants.OPERATION_MODE_SPEED_CONTROL);
            uint decUnits = (uint)(direction * speed  * 512 * encoderResolution / 1875);
            motor.writeToRegister(Constants.TARGET_SPEED,decUnits );
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON);
        }
        public void stopMotor() {
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_OFF);
            motor.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_OFF);
        }


        ~MotorControl() {
            port.Close();
        }

    }
}

// See https://aka.ms/new-console-template for more information

using System.IO.Ports;
using System;
using System.Threading;

namespace KincoSerialRS232
{
    public class testing 
    {
        /*
        static void Main(string[] args)
        {
            SerialPort port = new SerialPort("COM1");
            // configure serial port
            port.BaudRate = 38400;
            port.WriteTimeout = 1000;
            port.ReadTimeout = 1000;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.Open();

            KincoSerial kincoSerial = new KincoSerial(1, port);

            int relativeDiff = -400000;
            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_OFF);

            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING| Constants.CONTROL_WORD_POWER_OFF);
            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_CLEAR_INTERNAL_SHOOTING | Constants.CONTROL_WORD_POWER_ON);
            Thread.Sleep(1000);
            int position = kincoSerial.readFromRegisterInt(Constants.POS_ACTUAL);
            Console.WriteLine("reached :" + position + "         \r");
            Console.WriteLine(kincoSerial.readFromRegister(Constants.CONTROL_WORD));
            kincoSerial.writeToRegister(Constants.OPERATION_MODE, Constants.OPERATION_MODE_POSITION_CONTROL);
            kincoSerial.writeToRegister(Constants.TARGET_POSITION, (uint)relativeDiff);
            kincoSerial.writeToRegister(Constants.PROFILE_SPEED, 0x000F0000);
            kincoSerial.writeToRegister(Constants.PROFILE_ACC, 0x00008000);
            kincoSerial.writeToRegister(Constants.PROFILE_DEC, 0x00008000);
            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON| 0x4F);
            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_ON | 0x5F);

            uint status = 0;
            Thread.Sleep(100);
            while ( (status & 0x0400) != 0x0400) {
                position = kincoSerial.readFromRegisterInt(Constants.POS_ACTUAL);
                status = kincoSerial.readFromRegister(Constants.STATUS_WORD);

                string message = "position: {0:X}.";
                Console.WriteLine(String.Format(message, status));
                Console.WriteLine(position);
            }

            position = kincoSerial.readFromRegisterInt(Constants.POS_ACTUAL);
            Console.WriteLine("reached :" + position);

            kincoSerial.writeToRegister(Constants.CONTROL_WORD, Constants.CONTROL_WORD_POWER_OFF);

            port.Close();
            Console.ReadLine();


        }
        */
    }


}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincoSerialRS232
{
    public static class Constants
    {
        // constants for communication with the servo motor
        public const byte BYTE_SEND_4_BYTES = 0x23;
        public const byte BYTE_SEND_2_BYTES = 0x2b;
        public const byte BYTE_SEND_1_BYTES = 0x2f;
        public const byte BYTE_READ = 0x40;
        public const byte BYTE_SENT_SUCCESSFUL = 0x60;
        public const byte BYTE_READ_RESPONSE_4_BYTES = 0x43;
        public const byte BYTE_READ_RESPONSE_2_BYTES = 0x4b;
        public const byte BYTE_READ_RESPONSE_1_BYTES = 0x4f;
        public const byte BYTE_ERROR = 0x80;

        // Registers
        public const ulong CONTROL_WORD = 0x604000100D;
        public const ulong STATUS_WORD = 0x6041001009;
        public const ulong OPERATION_MODE = 0x606000080D;
        public const ulong POSITIONING_CONTROL_SELECT = 0x20200F0E;
        public const ulong POS_ACTUAL = 0x6063002009;
        public const ulong POS_ABS = 0x6004002009;
        public const ulong REAL_CURRENT = 0x6078001009;
        public const ulong STATUS_INPUT_PORT = 0x60FD002009;
        public const ulong REAL_SPEED = 0x606C002009;
        public const ulong INVERT_DIRECTION = 0x607E00080E;
        public const ulong TARGET_POSITION = 0x607A00200E;
        public const ulong PROFILE_SPEED = 0x608100200E;
        public const ulong TARGET_SPEED = 0x60FF00200E;
        public const ulong MAX_SPEED = 0x608000100C;
        public const ulong PROFILE_ACC = 0x608300200F;
        public const ulong PROFILE_DEC = 0x608400200F;
        public const ulong TARGET_TORQUE = 0x607100100C;
        public const ulong GROUP_CURRENT_LOOP = 0x60F608100D;
        public const ulong MAXIMAL_CURRENT_COMMAND = 0x607300100F;
        public const ulong DIN_POS0 = 0x202001200E;
        public const ulong DIN_POS1 = 0x202002200E;
        public const ulong DIN_POS2 = 0x202003200E;
        public const ulong DIN_POS3 = 0x202004200E;
        public const ulong DIN_POS4 = 0x202010200E;
        public const ulong DIN_POS5 = 0x202011200E;
        public const ulong DIN_POS6 = 0x202012200E;
        public const ulong DIN_POS7 = 0x202013200E;
        public const ulong DIN_SPEED0 = 0x202005200E;
        public const ulong DIN_SPEED1 = 0x202006200E;
        public const ulong DIN_SPEED2 = 0x202007200E;
        public const ulong DIN_SPEED3 = 0x202008200E;
        public const ulong DIN_SPEED4 = 0x202014200E;
        public const ulong DIN_SPEED5 = 0x202015200E;
        public const ulong DIN_SPEED6 = 0x202016200E;
        public const ulong DIN_SPEED7 = 0x202017200E;
        public const ulong MAX_FOLLOWING_ERROR = 0x606500200F;
        public const ulong TARGET_POS_WIND = 0x606700200E;
        public const ulong POSITION_WINDOW_TIME = 0x250809160C;
        public const ulong TARGET_SPEED_WINDOW = 0x60F90A200E;
        public const ulong ZERO_SPEED_WINDOW = 0x201018100E;
        public const ulong ZERO_SPEED_TIME = 0x60F914100E;
        public const ulong SOFT_POSITIVE_LIMIT = 0x607D01200E;
        public const ulong SOFT_NEGATIVE_LIMIT = 0x607D02200E;
        public const ulong LIMIT_FUNCTION = 0x201019080E;
        public const ulong HOMING_METHOD = 0x609800080F;
        public const ulong HOMING_SPEED_SWITCH = 0x609901200F;
        public const ulong HOMING_SPEED_ZERO = 0x609902200F;
        public const ulong HOMING_ACCELERATION = 0x609A00200E;
        public const ulong HOMING_OFFSET = 0x607C00200F;
        public const ulong HOMING_OFFSET_MODE = 0x609905080E;
        public const ulong VELOCITY_LOOP_KVP = 0x60F901100C;
        public const ulong VELOCITY_LOOP_KVI = 0x60F902100C;
        public const ulong VELOCITY_LOOP_KVI_32 = 0x60F907100F;
        public const ulong VELOCITY_LOOP_SPEED_FB_N = 0x60F905080C;
        public const ulong POSITION_LOOP_KPP = 0x60FB01100E;
        public const ulong POSITION_LOOP_K_VELOCITY_FF =0x60FB02100E;
        public const ulong POSITION_LOOP_K_ACC_FF = 0x60FB03100E;
        public const ulong POSITION_LOOP_POS_FILTER_N = 0x60FB05100E;
        public const ulong DIN1_FUNCTION = 0x201003100E;
        public const ulong DIN2_FUNCTION = 0x201004100E;
        public const ulong DIN3_FUNCTION = 0x201005100E;
        public const ulong DIN4_FUNCTION = 0x201006100E;
        public const ulong DOUT1_FUNCTION = 0x20100F100E;
        public const ulong DOUT2_FUNCTION = 0x201010100E;
        public const ulong DIN_REAL = 0x20100A1009;
        public const ulong DOUT_REAL = 0x2010141009;
        public const ulong DIN_POLARITY = 0x201001100E;
        public const ulong DOUT_POLARITY = 0x20100D100F;
        public const ulong DIN_SIMULATE = 0x201002100C;
        public const ulong DOUT_SIMULATE = 0x20100E100D;
        public const ulong GEAR_FACTOR0 = 0x250801100F;
        public const ulong GEAR_DIVIDER0 = 0x250802100F;
        public const ulong PD_CW = 0x250803100F;
        public const ulong GEAR_MASTER = 0x250804100D;
        public const ulong GEAR_SLAVE = 0x250805100C;
        public const ulong PD_FILTER = 0x250806100E;
        public const ulong MASTER_SPEED = 0x25080C1009;
        public const ulong SLAVE_SPEED = 0x25080D100C;
        public const ulong STORE_DATA = 0x2FF001080C;
        public const ulong STORE_MOTOR_DATA = 0x2FF003080C;
        public const ulong ERROR_STATE = 0x2601001009;
        public const ulong QUICK_STOP_MODE = 0x605A00100E;
        public const ulong SHUTDOWN_STOP_MODE = 0x605B00100E;
        public const ulong DISABLE_STOP_MODE = 0x605C00100E;
        public const ulong HALT_MODE = 0x605D00100E;
        public const ulong FAULT_STOP_MODE = 0x605E00100E;
        public const ulong QUICK_STOP_DEC = 0x608500200E;

        // Values
        public const byte CONTROL_WORD_POWER_OFF = 0x06;
        public const byte CONTROL_WORD_POWER_ON = 0x0F;
        public const byte CONTROL_WORD_QUICK_STOP = 0x0B;
        public const byte CONTROL_WORD_ABSOLUTE_POSITIONING = 0X3F;
        public const byte CONTROL_WORD_RELATIVE_POSITIONING = 0X5F;
        public const short CONTROL_WORD_ABSOLUTE_POSITIONING_WITH_TARGET_POSITION = 0X103F;
        public const byte CONTROL_WORD_HOME_POSITIONING = 0X1F;
        public const byte CONTROL_WORD_CLEAR_INTERNAL_SHOOTING = 0X80;
        public const byte OPERATION_MODE_POSITION_CONTROL = 1;
        public const byte OPERATION_MODE_SPEED_CONTROL = 3;
        public const byte OPERATION_MODE_TORQUE_CONTROL = 4;
        public const short OPERATION_MODE_QUICK_FAST_SPEED_CONTROL = -3;
        public const short OPERATION_MODE_PULSE_TRAIN_CONTROL = -4;
        public const byte OPERATION_MODE_HOME_MODE = 6;
        public const byte OPERRATION_MODE_DIFFERENTIAL =7;
        public const byte INVERT_DIRECTION_CCW = 0;
        public const byte INVERT_DIRECTION_CW = 1;
        public const byte HOMING_OFFSET_MODE_0_POSITION = 0;
        public const byte HOMING_OFFSET_MODE_OFFSET_POSITION = 1;
        public const byte PD_CW_CCW_CW = 0;
        public const byte PD_CW_PULSE_DIRECTION = 1;
        public const byte PD_CW_A_B_MODE = 2;
        public const byte PD_CW_422_DOUBLE_PULSE = 10;
        public const byte PD_CW_422_PULSE_DIRECTION = 11;
        public const byte PD_CW_422_INCREMENTAL_ENCODER = 12;
        public const byte STORE_DATA_STORE_ALL = 1;
        public const byte STORE_DATA_INITIATE = 10;
        public const byte STORE_MOTORR_DATA_ALL = 1;
        public const byte QUICK_STOP_MODE_WITHOUT_CONTROLE = 0;
        public const byte QUICK_STOP_MODE_USING_RAMP = 1;
        public const byte QUICK_STOP_MODE_USING_DEC = 2;
        public const byte QUICK_STOP_MODE_USING_PROFILE_DEC = 5;
        public const byte QUICK_STOP_MODE_USING_DEC_ACTIVE =6;
        public const byte SHUTDOWN_STOP_MODE_WITHOUT = 0;
        public const byte SHUTDOWN_STOP_MODE_RAMP = 1;
        public const byte SHUTDOWN_STOP_MODE_DEC = 2;
        public const byte HALT_MODE_RAMP = 1;
        public const byte HALT_MODE_DEC = 2;
        public const byte FAULT_STOP_MODE_WITHOUT = 0;
        public const byte FAULT_STOP_MODE_RAMP = 1;
        public const byte FAULT_STOP_MODE_DEC = 2;
    }
}

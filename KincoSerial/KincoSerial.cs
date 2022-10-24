using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace KincoSerialRS232
{
    public class KincoSerial
    {
        private byte _id;
        private SerialPort _port;

        public byte ID => _id;
        public SerialPort Port => _port;


        public KincoSerial(byte id, SerialPort port)
        {
            _id = id;
            _port = port;
        }

        private byte getByte(ulong register, int number) {
            if (number >= 8) {
                throw new Exception("Trying to get "+ number+ " byte from an 8 byte ulong.");
            }
            const byte mask = 0xFF;
            return (byte)(register >> (number * 8));
        }


        private uint convertByteArrayToUint(byte[] bytes) {
            uint result = 0;
            result = (uint)(bytes[3]<<24 | (bytes[2]<<16) | (bytes[1] <<8) | (bytes[0] ));
            return result;
        }

        private int convertByteArrayToInt(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }


        private uint getData(byte[] result, byte size)
        {
            int dataLength = 4;
            int startIndex = 5;
            if (size == 0x08)
            {
                dataLength = 1;
                startIndex = 8 - dataLength-1;
            }
            else if (size == 0x10) {
                dataLength = 2;
                startIndex = 8 - dataLength-1;
            }

            byte[] data = { 0,0,0,0};
            Array.Copy(result, startIndex, data, 0, dataLength);
            return convertByteArrayToUint(data);
        }

        private int getDataInt(byte[] result, byte size)
        {
            int dataLength = 4;
            int startIndex = 5;
            if (size == 0x08)
            {
                dataLength = 1;
                startIndex = 8 - dataLength-1;
            }
            else if (size == 0x10)
            {
                dataLength = 2;
                startIndex = 8 - dataLength-1;
            }

            byte[] data = { 0, 0, 0, 0 };
            Array.Copy(result, startIndex, data, 0, dataLength);

            return convertByteArrayToInt(data);
        }
        private byte getWriteCMD(ulong register) {
            byte CMD = 0x00;

            if (getByte(register, 1) == 0x08)
            {
                CMD = Constants.BYTE_SEND_1_BYTES;
            }
            else if (getByte(register, 1) == 0x10)
            {
                CMD = Constants.BYTE_SEND_2_BYTES;
            }
            else if (getByte(register, 1) == 0x20)
            {
                CMD = Constants.BYTE_SEND_4_BYTES;
            }

            return CMD;
        }

        private byte[] setData(uint data,byte dataSize) {
            if (dataSize == Constants.BYTE_SEND_1_BYTES)
            {
                byte[] result = { (byte)data, 0, 0, 0 };
                return result;
            }
            else if (dataSize == Constants.BYTE_SEND_2_BYTES)
            {
                byte[] result = { (byte)data, (byte)(data >> 8), 0, 0 };
                return result;
            }
            else if (dataSize == Constants.BYTE_SEND_4_BYTES)
            {
                byte[] result = { (byte)data, (byte)(data >> 8), (byte)(data >> 16), (byte)(data >> 24) };
                return result;
            }
            else {
                throw (new Exception("Cant convert data to binary values for data: " + data +" with the size of: "+dataSize));
            }

        }
        public uint readFromRegister(ulong register) {
            ushort index = (ushort)((getByte(register, 4)) | (getByte(register, 3) << 8));
            byte subIndex = getByte(register, 2);
            // check if readable
            if ((byte)(getByte(register, 0) & 0x08) == 0) {
                throw (new Exception("Cant read from register with CANADDRESS of: " + register));
            }
            byte[] result = readFromDevice(Constants.BYTE_READ, index, subIndex);
            if (result[0] == Constants.BYTE_ERROR) {
                throw (new Exception("Reading from register returned error code: " + getData(result, 0x20)));
            }

            return getData(result,getByte(register,1));
        }


        public int readFromRegisterInt(ulong register)
        {
            ushort index = (ushort)((getByte(register, 4)) | (getByte(register, 3) << 8));
            byte subIndex = getByte(register, 2);
            // check if readable
            if ((byte)(getByte(register, 0) & 0x08) == 0)
            {
                throw (new Exception("Cant read from register with CANADDRESS of: " + register));
            }
            byte[] result = readFromDevice(Constants.BYTE_READ, index, subIndex);
            if (result[0] == Constants.BYTE_ERROR)
            {
                throw (new Exception("Reading from register returned error code: " + getData(result, 0x20)));
            }

            return getDataInt(result,getByte(register,1));
        }

        public uint writeToRegister(ulong register, uint data) {
            ushort index = (ushort)((getByte(register, 4)) | (getByte(register, 3) << 8));
            byte subIndex = getByte(register, 2);
            byte CMD = getWriteCMD(register);
            // check if readable
            if ((byte)(getByte(register, 0) & 0x04) == 0)
            {
                throw (new Exception("Cant write to register with CANADDRESS of: " + register));
            }

           
            byte[] result = writeToDevice(CMD, index, subIndex,setData(data,CMD));
            if (result[0] == Constants.BYTE_ERROR)
            {
                throw (new Exception("Writing to register returned error code: " + getData(result, 0x20)));
            }
            return getData(result, 0x20);

        }

        private byte[] readFromDevice(byte CMD, ushort Index, byte subIndex) {
            byte[] fullCommand = { _id, CMD, (byte)((Index >> 8) & 0x00FF), (byte)(Index & 0x00FF), subIndex, 0,0, 0, 0, 0x00 };
            byte[] response = new byte[10];
            byte chks = KincoSerialUtility.GetChecksum(fullCommand);
            fullCommand[fullCommand.Length - 1] = chks;
            _port.Write(fullCommand,0,10);
            Thread.Sleep(100);
            _port.Read(response,0,10);
            return response;
        }


        private byte[] writeToDevice(byte CMD, ushort Index, byte subIndex,byte[] data) {
            byte[] fullCommand = { _id,CMD, (byte)((Index >>8) & 0x00FF), (byte)(Index & 0x00FF), subIndex, data[0], data[1], data[2], data[3],0x00};
            byte[] response = new byte[10];
            byte chks = KincoSerialUtility.GetChecksum(fullCommand);
            fullCommand[fullCommand.Length - 1] = chks;
            _port.Write(fullCommand, 0, 10);
            Thread.Sleep(100);
            _port.Read(response, 0, 10);
            return response;
        }

    }
}

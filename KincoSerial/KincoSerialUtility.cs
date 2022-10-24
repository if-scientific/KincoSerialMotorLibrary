using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincoSerialRS232
{
    static class KincoSerialUtility {
        public static byte GetChecksum(byte[] bytes) {
            int sum = 0;
            for (int i = 0; i < bytes.Length; i++) {
                byte t = bytes[i];
                sum += t;
            } 
            return (byte)(((~sum) + 0x01) & 0xFF);
        }

        public static string GetStringOutput(uint result) {
            if (result == null)
            {
                return "Given output is not correct or flawed.";
            }
            else if ((byte)(result>>8) == (byte)Constants.BYTE_ERROR)
            {
                return "Error executing command";
            }
            else if ((byte)(result>> 8) == (byte)Constants.BYTE_SENT_SUCCESSFUL)
            {
                return "Command executed succesfully";
            }
            else {
                return "Return code unknown: " + (byte)(result << 8);
            }
        }
    }
}

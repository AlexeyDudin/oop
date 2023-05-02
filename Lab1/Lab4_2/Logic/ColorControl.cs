using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2.Logic
{
    public static class ColorControl
    {
        public static byte[] GetColorFromUInt(uint color)
        {
            byte[] result = new byte[3];
            result[0] = (byte)((color >> 16) & 0xFF);
            result[1] = (byte)((color >> 8) & 0xFF);
            result[2] = (byte)(color & 0xFF);
            return result;
        }
    }
}

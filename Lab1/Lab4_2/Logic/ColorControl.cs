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
            result[0] = (byte)((color >> 4) % byte.MaxValue);
            result[1] = (byte)((color >> 2) % byte.MaxValue);
            result[2] = (byte)(color % byte.MaxValue);
            return result;
        }
    }
}

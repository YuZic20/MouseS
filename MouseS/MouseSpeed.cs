﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    static class MouseSpeed
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;

        public const UInt32 SPI_GETMOUSESPEED = 0x0070;


        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            object pvParam,
            UInt32 fWinIni);


        public static void SetMouseSpeed ( int speed)
        {
            if(speed <= 20 && speed >= 1)
            {
                
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, (UInt32)Convert.ToUInt32(speed), 0);
            }
            
        }
        public static unsafe int GetMouseSpeed()
        {

            uint speed;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, (UInt32)new IntPtr(&speed), 0);



            return Convert.ToInt32(Convert.ToInt32(speed));
            
        }
    }
}

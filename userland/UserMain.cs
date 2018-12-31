using NsSupervJoy.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NsSupervJoy.Engine.SuperVJoy;
using System.Windows.Forms;

namespace NsSupervJoy.userland
{
    public static class UserMain
    {
        // called once at startup
        public static void Init()
        {
            // general configuration
            SuperVJoy.maxOutputAxisCountIWantToUse = 6;
            SuperVJoy.debugOutputRawInputInLog = true;

        }

   
        public static void Process() // data routing, behaviour etc
        {
 
        }
    }
}

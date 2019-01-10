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
            SuperVJoy.maxOutputAxisCountIWantToUse = 9;
            SuperVJoy.debugOutputRawInputInLog = false;
            SuperVJoy.showDebugForm = false;
            SuperVJoy.showKekeFrom = false;

        }

   
        public static void Process() // data routing, behaviour etc
        {
 
        }
    }
}

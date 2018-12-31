using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static NsSupervJoy.Engine.SuperVJoy;

namespace NsSupervJoy.engine
{
    public static class Global
    {

        public static string ReturnCleanASCII(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s)
            {
                if ((int)c > 127) // you probably don't want 127 either
                    continue;
                if ((int)c < 32)  // I bet you don't want control characters
                    continue;
                if (c == ',')
                    continue;
                if (c == '"')
                    continue;
                sb.Append(c);
            }
            return sb.ToString();
        }


        private static Keys GetModifierKey(KeyModifier modifier)
        {
            switch(modifier)
            {
                case KeyModifier.Shift:
                    return Keys.Shift;
        
                  
            }
            return Keys.Shift;
        }

        public static void AsyncKeyPress(Keys key)
        {
            new Thread(() =>
            {
                Console.WriteLine("Key press " + key.ToString());
                if (plzOutputToDebugFrm) debugFrmEvents.Add("Key press " + key.ToString());
                InputManager.Keyboard.KeyPress(key);
            }).Start();
        }
        public static void AsyncKeyPress(Keys key, Keys modifier)
        {
            new Thread(() =>
            {
                InputManager.Keyboard.KeyDown(modifier);
                Thread.Sleep(35);
                InputManager.Keyboard.KeyPress(key);
                InputManager.Keyboard.KeyUp(modifier);

            }).Start();
        }
        public static void AsyncKeyUp(Keys key)
        {
            new Thread(() =>
            {
                Console.WriteLine("Key up " + key.ToString());
                if (plzOutputToDebugFrm) debugFrmEvents.Add("Key up " + key.ToString());
                InputManager.Keyboard.KeyUp(key);
            }).Start();
        }
        public static void AsyncKeyUp(Keys key, Keys modifier)
        {
            new Thread(() =>
            {

                InputManager.Keyboard.KeyUp(key);
                InputManager.Keyboard.KeyUp(modifier);
            }).Start();
        }
        public static void AsyncKeyDown(Keys key)
        {
            new Thread(() =>
            {
                Console.WriteLine("Key down " + key.ToString());
                if (plzOutputToDebugFrm) debugFrmEvents.Add("Key down " + key.ToString());
                InputManager.Keyboard.KeyDown(key);
            }).Start();
        }
        public static void AsyncKeyDown(Keys key, Keys modifier)
        {
            new Thread(() =>
            {

                InputManager.Keyboard.KeyDown(modifier);
                InputManager.Keyboard.KeyDown(key);
            }).Start();
        }
    }


}

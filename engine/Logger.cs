using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsSupervJoy.engine
{
    class Logger
    {
        private string name;

        public Logger(string name)
        {
            this.name = name;
        }

        public void Debug(string content)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK") + "]" + name + ": " + content);
        }
        public void JumpLine(int count)
        {
            for(int i=0; i<count; ++i)
            {
                Console.WriteLine("");
            }
        }

    }
}

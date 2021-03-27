using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class Sleep
    {
        public int Second { get; set; }
        public Sleep(int second)
        {
            this.Second = second;
        }
    }
}

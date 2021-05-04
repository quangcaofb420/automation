using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ActionParam
{
    public class Sleep
    {
        public Int32 Second { get; set; }
        public Sleep(object second)
        {
            this.Second = Int32.Parse(second.ToString());
        } 
      
    }
}

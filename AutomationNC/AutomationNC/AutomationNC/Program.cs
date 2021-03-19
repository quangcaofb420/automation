using AutomationNC.Business;
using System;

namespace AutomationNC
{
    class Program
    {
        static void Main(string[] args)
        {
             SlcSenarior.GetInstance().Process();
             Environment.Exit(-1);

        }
    }
}

using Core.Models;
using System;

namespace AutomationNC
{
    class Program
    {
        static void Main(string[] args)
        {

             SlnSenarior.GetInstance().Process();
             Environment.Exit(-1);

        }
    }
}

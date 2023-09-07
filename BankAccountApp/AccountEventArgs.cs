using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    class AccountEventArgs : EventArgs
    {
        public static string Message { get; set; }
        public AccountEventArgs(string message)
        {
            Message = message;
        }
    }
}

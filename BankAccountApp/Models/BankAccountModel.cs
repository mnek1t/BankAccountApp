using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.BankAccountModels
{
    delegate void AccountHandler(object sender, AccountEventArgs e);
    class BankAccountModel
    {
        public event AccountHandler Notify;
        public static double Sum { get; set; }
        public const int MaxSum = 1000000; 
        public void Put(double a)
        {
            Sum += a;
            Notify?.Invoke(this, new AccountEventArgs($"{a}$ is put on the bank account!"));
        }
        public void Withdraw(double a)
        {
            Sum -= a;
            Notify?.Invoke(this,new AccountEventArgs($"{a}$ money is taken from the bank account!"));
        }
    }
}

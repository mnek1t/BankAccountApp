using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankAccountApp;
using BankAccountApp.BankAccountModels;

namespace BankAccountApp
{
     
    class PresenterBankAccount
    {
        public double loadedSum;
        private TaskWindow view;
        private BankAccountModels.BankAccountModel bankAccountModel = new BankAccountModels.BankAccountModel();
        public PresenterBankAccount(TaskWindow view)
        {
            this.view = view;
            BankAccountModel.Sum = loadedSum;
        }
        public void Put(double a)
        {
            if (a < BankAccountModel.MaxSum)
            {
                view.BalnceTextBox.FontSize = 32;
                bankAccountModel.Notify += Display;
                bankAccountModel.Put(a);
            }
            else
            {
                view.BalnceTextBox.Text = "Limit is exceeded";
            }
        }

        public void Withdraw(double a)
        {
            
            if (BankAccountModels.BankAccountModel.Sum + loadedSum >= a)
            {
                if (a < BankAccountModel.MaxSum)
                {
                    view.BalnceTextBox.FontSize = 32;
                    bankAccountModel.Notify += Display;
                    bankAccountModel.Withdraw(a);
                }
                else
                {
                    view.BalnceTextBox.Text = "Limit is exceeded";
                }
                
            }
            else
            {
                view.BalnceTextBox.Text = "Not enough money!";
            }
        } 
        public void CheckBalance()
        {
            view.BalnceTextBox.FontSize = 68;
            AccountEventArgs eventArgs = new AccountEventArgs((BankAccountModels.BankAccountModel.Sum + loadedSum).ToString() + "$");
            view.BalnceTextBox.Text = AccountEventArgs.Message;
        }
        private void Display(object sender, AccountEventArgs e)
        {
            view.BalnceTextBox.Text = AccountEventArgs.Message;
        }
    }
}

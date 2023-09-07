using BankAccountApp.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    class CredentialPresenter
    {
        private MainWindow view;
        private Credential credential = new Credential();
        public string Login { get; set; }
        public string Password { get; set; }
        public CredentialPresenter(MainWindow view)
        {
            this.view = view;
            Login = view.LoginTextBox.Text;
            Password = view.PasswordBox.Password;
        }
        public bool isAccessable()
        {
            if (credential.Login == Login && credential.Password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

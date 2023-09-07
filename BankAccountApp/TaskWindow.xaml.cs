using BankAccountApp.BankAccountModels;
using BankAccountApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankAccountApp
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private PresenterBankAccount presenter;
        private FileIOService _fileIOService;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\bankAccount.json";
        public TaskWindow()
        {
            InitializeComponent();
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            _fileIOService = new FileIOService(PATH);
            presenter = new PresenterBankAccount(this);
            
            try
            {
                presenter.loadedSum = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void BalanceButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.CheckBalance();
        }

        private void PutButton_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(EnterAmountTextBox.Text, out double a))
            {
                EnterAmountTextBox.Text = null;
                presenter.Put(a);
            }
            else
            {
                MessageBox.Show("Please enter some sum for process the operation!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(EnterAmountTextBox.Text, out double a))
            {
                EnterAmountTextBox.Text = null;
                presenter.Withdraw(a);
            }
            else
            {
                MessageBox.Show("Please enter some sum for process the operation!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               _fileIOService.SaveData(BankAccountModel.Sum+ presenter.loadedSum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Application.Current.Shutdown();
        }
    }
}

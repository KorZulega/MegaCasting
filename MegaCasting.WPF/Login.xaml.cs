using System;
using MegaCasting.DBLib;
using MegaCasting.WPF.ViewModels;
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

namespace MegaCasting.WPF
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        #region Static Attributes
        /// <summary>
        /// Instanciation d'une entité de la base de données
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion
        public Login()
        {
            InitializeComponent();
            List<Account> Accounts = megaCastingEntities.Accounts.ToList();
            this.DataContext = new ViewModelViewAccount();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!nameTextBox.Text.Equals("") && !passwordTextBox.Password.Equals(""))
            {
                if (((ViewModelViewAccount)this.DataContext).CheckAccount(nameTextBox.Text, passwordTextBox.Password) == true)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
                else {

                    infoTextBlock.Text = "Identifiants invalides";
                    infoTextBlock.Foreground = Brushes.Red;

                }

            }
            else
            {
                infoTextBlock.Text = "Vous ne pouvez pas laisser de champs vides";
                infoTextBlock.Foreground = Brushes.Red;
            }
        }
    }
}

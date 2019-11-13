using MegaCasting.DBLib;
using MegaCasting.WPF.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCasting.WPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ViewCustomer.xaml
    /// </summary>
    public partial class ViewCustomer : UserControl
    {
        #region Static Attributes

        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion
        public ViewCustomer()
        {
            InitializeComponent();

            List<Customer> Customers = megaCastingEntities.Customers.ToList();

            this.DataContext = new ViewModelViewCustomer();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewCustomer)this.DataContext).AddCustomer();
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewCustomer)this.DataContext).DeleteCustomer();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewCustomer)this.DataContext).SaveCustomer();
        }
    }
}

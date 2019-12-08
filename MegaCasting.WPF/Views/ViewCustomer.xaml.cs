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
        /// <summary>
        /// Instanciation d'une entité de la base de données
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion

        /// <summary>
        /// Constructeur de la View du client
        /// </summary>
        public ViewCustomer()
        {
            InitializeComponent();

            List<Customer> Customers = megaCastingEntities.Customers.ToList();

            this.DataContext = new ViewModelViewCustomer();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode AddCustomer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewCustomer)this.DataContext).AddCustomer();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode DeleteCustome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Etes-vous sûr de vouloir supprimer l'élément ?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            { ((ViewModelViewCustomer)this.DataContext).DeleteCustomer(); }
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode SaveCustomer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewCustomer)this.DataContext).SaveCustomer();
        }
    }
}

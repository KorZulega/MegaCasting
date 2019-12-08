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
    /// Logique d'interaction pour ViewContractType.xaml
    /// </summary>
    public partial class ViewContractType : UserControl
    {
        #region Static Attributes
        /// <summary>
        /// Instanciation d'une entité de la base de données
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion
        public ViewContractType()
        {
            InitializeComponent();
            List<ContractType> ContractTypes = megaCastingEntities.ContractTypes.ToList();

            this.DataContext = new ViewModelViewContractType();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode AddContractType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContractType_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewContractType)this.DataContext).AddContractType();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode DeleteCustome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteContractType_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Etes-vous sûr de vouloir supprimer l'élément ?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            { ((ViewModelViewContractType)this.DataContext).DeleteContractType(); }

        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode SaveContractType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveContractType_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewContractType)this.DataContext).SaveContractType();
        }
    }
}

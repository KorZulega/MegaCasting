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
    /// Logique d'interaction pour ViewJobType.xaml
    /// </summary>
    public partial class ViewJobType : UserControl
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
        public ViewJobType()
        {
            InitializeComponent();

            List<JobType> JobTypes = megaCastingEntities.JobTypes.ToList();

            this.DataContext = new ViewModelViewJobType();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode AddJobType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJobType_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewJobType)this.DataContext).AddJobType();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode DeleteJobType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobType_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Etes-vous sûr de vouloir supprimer l'élément ?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            { ((ViewModelViewJobType)this.DataContext).DeleteJobType(); }
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode SaveJobType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveJobType_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewJobType)this.DataContext).SaveJobType();
        }
    }
}

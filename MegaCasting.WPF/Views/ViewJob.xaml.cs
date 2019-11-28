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
    /// Logique d'interaction pour ViewJob.xaml
    /// </summary>
    public partial class ViewJob : UserControl
    {
        #region Static Attributes
        /// <summary>
        /// Instanciation d'une entité de la base de données
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion

        public ViewJob()
        {
            InitializeComponent();

            List<Job> Jobs = megaCastingEntities.Jobs.ToList();
            List<JobType> JobTypes = megaCastingEntities.JobTypes.ToList();

            this.DataContext = new ViewModelViewJob();
        }

        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewJob)this.DataContext).AddJob();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode DeleteJob
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJob_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewJob)this.DataContext).DeleteJob();
        }

        /// <summary>
        /// Evènement type "click" déclenchant la méthode SaveJob
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveJob_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewJob)this.DataContext).SaveJob();
        }

        
    }
}

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
using MegaCasting.DBLib;
using MegaCasting.WPF.ViewModel;

namespace MegaCasting.WPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ViewAnnouncer.xaml
    /// </summary>
    public partial class ViewProducer : UserControl
    {
        #region Static Attributes
        /// <summary>
        /// Instanciation d'une entité de la base de données
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion

        /// <summary>
        /// Constructeur de la vue de l'annonceur
        /// </summary>
        public ViewProducer()
        {
            InitializeComponent();

            List<Producer> producers = megaCastingEntities.Producers.ToList();

            this.DataContext = new ViewModelViewProducer();

            //producers.ForEach(producer => listBoxAnnouncers.Items.Add(producer));
        }

        //private void ListBoxAnnouncers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (listBoxAnnouncers.SelectedItem != null)
        //    {
        //        //name.Text = ((Producer)listBoxAnnouncers.SelectedItem).Name;
        //    }
        //    else
        //    {

        //    }
            

           


        //}


        /// <summary>
        /// Evènement type "click" déclenchant la méthode AddProducer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProducer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewProducer)this.DataContext).AddProducer();
        }
        /// <summary>
        /// Evènement type "click" déclenchant la méthode DeleteProducter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProducer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewProducer)this.DataContext).DeleteProduter();
        }
        /// <summary>
        /// Evènement type "click" déclenchant la méthode SaveProducer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProducer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewProducer)this.DataContext).SaveProducer();
        }
    }
}

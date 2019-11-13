using MegaCasting.DBLib;
using MegaCasting.WPF.ViewModel;
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
    /// Logique d'interaction pour AnnouncementView.xaml
    /// </summary>
    public partial class ViewAnnouncement : UserControl
    {
        #region Static Attributes

        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion
        public ViewAnnouncement()
        {
            InitializeComponent();

            List<Offer> offers = megaCastingEntities.Offers.ToList();

            this.DataContext = new ViewModelViewAnnouncement();
        }
    }
}

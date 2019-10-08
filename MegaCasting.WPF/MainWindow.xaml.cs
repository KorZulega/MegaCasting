using MegaCasting.WPF.Views;
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

namespace MegaCasting.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AnnonceurBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewProducer viewProducer = new ViewProducer();
            this.dockPanelMain.Children.Add(viewProducer);
            
        }

        private void CleanPanel()
        {
            this.dockPanelMain.Children.Clear();
        }

        private void AnnonceBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewAnnouncement viewAnnouncement = new ViewAnnouncement();
            this.dockPanelMain.Children.Add(viewAnnouncement);
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }

    
}

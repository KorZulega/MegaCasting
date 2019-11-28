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
            this.Height = 730;
            this.Width = 900;
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

        private void ButtonFullWindowed_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                buttonFullWindowedMaterial.Kind.Equals("WindowMaximize");
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                buttonFullWindowedMaterial.Kind.Equals("WindowMinimize");
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void ClientsBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewCustomer viewCustomer = new ViewCustomer();
            this.dockPanelMain.Children.Add(viewCustomer);
        }

        private void JobBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewJob viewJob = new ViewJob();
            this.dockPanelMain.Children.Add(viewJob);
        }

        private void JobTypeBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewJobType viewJobType = new ViewJobType();
            this.dockPanelMain.Children.Add(viewJobType);
        }

        private void ContractTypeBoutton_Click(object sender, RoutedEventArgs e)
        {
            CleanPanel();
            ViewContractType viewContractType = new ViewContractType();
            this.dockPanelMain.Children.Add(viewContractType);
        }
    }

    
}

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
    /// Logique d'interaction pour ViewConfirmDelete.xaml
    /// </summary>
    public partial class ViewConfirmDelete : UserControl
    {
        #region static attributes

        public static bool IsConfirmed = false;

        #endregion
        public ViewConfirmDelete()
        {
            InitializeComponent();
            this.DataContext = new ViewModelViewConfirmDelete();
        }

        private void ConfirmDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelViewConfirmDelete)this.DataContext).ConfirmDelete();
            Environment.Exit(0);
        }
    }
}

﻿using System;
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


namespace MegaCasting.WPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ViewAnnouncer.xaml
    /// </summary>
    public partial class ViewAnnouncer : UserControl
    {
        #region Static Attributes

        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion

        public ViewAnnouncer()
        {
            InitializeComponent();

            List<Producer> producers = megaCastingEntities.Producers.ToList();

            producers.ForEach(producer => listBoxAnnouncers.Items.Add(producer));
        }

        private void ListBoxAnnouncers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxAnnouncers.SelectedItem != null)
            {
                name.Text = ((Producer)listBoxAnnouncers.SelectedItem).Name;
            }
            else
            {

            }
            

           


        }
    }
}

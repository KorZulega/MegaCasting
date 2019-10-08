using MegaCasting.DBLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelViewProducer : ViewModelBase
    {
        #region Attributes
        private ObservableCollection<Producer> _Producers;
        #endregion

        #region Properties
        public ObservableCollection<Producer> Producers
        {
            get { return _Producers; }
            set { _Producers = value; }
        }
        #endregion
        #region Constructor
        public ViewModelViewProducer()
        {
            Producers = new ObservableCollection<Producer>(this.Entities.Producers);
        }

        #endregion
    }
}

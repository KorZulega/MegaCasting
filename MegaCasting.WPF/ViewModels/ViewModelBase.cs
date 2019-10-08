using MegaCasting.DBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelBase
    {
        #region Attributes
        private MegaCastingEntities _Entities;
        #endregion

        #region Properties
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }
        #endregion
        #region Contructor
        public ViewModelBase()
        {
            this.Entities = new MegaCastingEntities();
        }
        #endregion
    }
}

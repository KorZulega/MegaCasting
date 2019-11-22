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
        /// <summary>
        /// Permet de définir et de retourner les valeurs de la base de données
        /// </summary>
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Permet de créer une instance de la base de donnée
        /// </summary>
        public ViewModelBase()
        {
            this.Entities = new MegaCastingEntities();
        }
        #endregion
    }
}

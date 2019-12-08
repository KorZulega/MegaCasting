using MegaCasting.WPF.ViewModel;
using MegaCasting.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModels
{
    class ViewModelViewConfirmDelete : ViewModelBase
    {
        #region Constructors

        public ViewModelViewConfirmDelete()
        {
            
        }

        #endregion

        #region Methods

        public void ConfirmDelete()
        {
            ViewConfirmDelete.IsConfirmed = true;
            
        }

        public void CancelDelete()
        {
            ViewConfirmDelete.IsConfirmed = false;
        }
        #endregion
    }
}

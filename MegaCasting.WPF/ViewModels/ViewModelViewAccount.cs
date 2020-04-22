using MegaCasting.DBLib;
using System;
using MegaCasting.WPF.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModels
{
    class ViewModelViewAccount : ViewModelBase
    {

        #region Attributes
        /// <summary>
        /// Attribut privé stockant la liste de Domaine de métiers
        /// </summary>
        private ObservableCollection<Account> _Accounts;

        /// <summary>
        /// Attribut privé contenant le Domaine de métier sélectionné
        /// </summary>
        private Account _SelectedAccount;


        #endregion






        #region Properties


        /// <summary>
        /// Affecte ou retourne la liste des Domaine de métiers
        /// </summary>
        public ObservableCollection<Account> Accounts
        {
            get { return _Accounts; }
            set { _Accounts = value; }
        }
        /// <summary>
        /// Affecte ou retourne le Domaine de métier sélectionné
        /// </summary>
        public Account SelectedAccount
        {
            get { return _SelectedAccount; }
            set { _SelectedAccount = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ModelView du Domaine de métier
        /// </summary>
        public ViewModelViewAccount()
        {
            Accounts = new ObservableCollection<Account>(this.Entities.Accounts);
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant d'ajouter un Domaine de métier dans l'application, cette méthode n'implémente pas la sauvegarde dans la BDD 
        /// et les changements seront perdus si l'élément perd le focus
        /// </summary>
        public bool CheckAccount(string user, string password)
        {
            try
            {
                
                bool query = Accounts.Where(Account => 
                (Account.Username.Equals(user) 
                && (Account.Password.Equals(password)))).Select(Accounts => (Accounts.Username.Equals(user))&&(Accounts.Password.Equals(password))).FirstOrDefault();
                    
                return query;
            }
            catch
            {
                return false;
            }



        }
        

        #endregion

    }
}

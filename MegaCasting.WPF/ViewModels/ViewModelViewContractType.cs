using MaterialDesignThemes.Wpf;
using MegaCasting.DBLib;
using MegaCasting.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModels
{
    class ViewModelViewContractType : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Attribut privé stockant la liste de Type de contrats
        /// </summary>
        private ObservableCollection<ContractType> _ContractTypes;

        /// <summary>
        /// Attribut privé contenant le Type de contrat sélectionné
        /// </summary>
        private ContractType _SelectedContractType;

        /// <summary>
        /// Attribut privé contenant les messages de la SnackBar
        /// </summary>
        private SnackbarMessageQueue _MyMessageQueue;
        #endregion






        #region Properties

        /// <summary>
        /// Affecte ou retourne les messages de la Snackbar
        /// </summary>
        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }

        /// <summary>
        /// Affecte ou retourne la liste des Type de contrat
        /// </summary>
        public ObservableCollection<ContractType> ContractTypes
        {
            get { return _ContractTypes; }
            set { _ContractTypes = value; }
        }
        /// <summary>
        /// Affecte ou retourne le Type de contrat sélectionné
        /// </summary>
        public ContractType SelectedContractType
        {
            get { return _SelectedContractType; }
            set { _SelectedContractType = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ModelView du Type de contrat
        /// </summary>
        public ViewModelViewContractType()
        {
            ContractTypes = new ObservableCollection<ContractType>(this.Entities.ContractTypes);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant d'ajouter un Type de contrat dans l'application, cette méthode n'implémente pas la sauvegarde dans la BDD 
        /// et les changements seront perdus si l'élément perd le focus
        /// </summary>
        public void AddContractType()
        {
            try
            {
                ContractType ContractType = new ContractType();
                ContractType.Name = "Saisir un nom";
                this.ContractTypes.Add(ContractType);
                this.Entities.ContractTypes.Add(ContractType);

                MyMessageQueue.Enqueue("Un Domaine de métier a été ajouté, pensez à l'enregistrer");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }



        }
        /// <summary>
        /// Méthode permettant de supprimer le Type de contrat sélectionnée de la base de données
        /// </summary>
        public void DeleteContractType()
        {
            try
            {
                this.Entities.ContractTypes.Remove(SelectedContractType);
                this.ContractTypes.Remove(SelectedContractType);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Le Type de contrat a bien été supprimé");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }

        }
        /// <summary>
        /// Permet de sauvegarder en base de données les changements appliqués au Type de contrat sélectionné
        /// </summary>
        public void SaveContractType()
        {
            try
            {
                ContractTypes.Where(ContractType => ContractType.Identifier.Equals(SelectedContractType.Identifier));
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue(SelectedContractType.Name + " a bien été modifié !");
            }
            catch
            {
                MyMessageQueue.Enqueue("Wow, une erreur s'est produite !");
            }


        }

        

        #endregion
    }
}

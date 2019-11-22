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
    class ViewModelViewAnnouncement : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Liste d'offre privée
        /// </summary>
        private ObservableCollection<Offer> _Offers;
        /// <summary>
        /// Contient l'offre sélectionnée dans l'application
        /// </summary>
        private Offer _SelectedOffer;
        //Contient les messages d'information de la SnackBar
        private SnackbarMessageQueue _MyMessageQueue;
        #endregion
        #region Properties

        /// <summary>
        /// Retourne ou affecte la valeur de la SnackBar
        /// </summary>
        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }

        /// <summary>
        /// Retourne ou affecte la liste d'offre
        /// </summary>
        public ObservableCollection<Offer> Offers
        {
            get { return _Offers; }
            set { _Offers = value; }
        }
        
        /// <summary>
        /// Affecte ou retourne l'offre sélectionnée
        /// </summary>
        public Offer SelectedOffer
        {
            get { return _SelectedOffer; }
            set { _SelectedOffer = value; }
        }

        #endregion
        #region Constructors

        /// <summary>
        /// Constructeur du ViewModel de l'offre
        /// </summary>
        public ViewModelViewAnnouncement()
        {
            Offers = new ObservableCollection<Offer>(this.Entities.Offers);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Méthode permettant d'ajouter une offre temporaire dans l'application sans implémenter la sauvegarde de l'entité dans la base de donnée
        /// </summary>
        public void AddOffer()
        {
            try
            {
                Offer offer = new Offer();
                offer.Name = "Saisir un nom";
                offer.Reference = "A déterminer";
                offer.PublishDateTime = DateTime.Now;
                offer.Duration = 30;
                offer.StartContractDate = DateTime.Now;
                offer.PostCount = 1;
                offer.Job = null;
                offer.ProfilDescription = "A saisir";
                offer.Street = "A saisir";
                offer.Street = "75000";
                this.Entities.SaveChanges();

                MyMessageQueue.Enqueue("L'offre a bien été ajoutée");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite");
            }
        }

        #endregion
    }
}

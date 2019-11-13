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
        private ObservableCollection<Offer> _Offers;
        
        private Offer _SelectedOffer;
        private SnackbarMessageQueue _MyMessageQueue;
        #endregion
        #region Properties
        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }

        public ObservableCollection<Offer> Offers
        {
            get { return _Offers; }
            set { _Offers = value; }
        }
        

        public Offer SelectedOffer
        {
            get { return _SelectedOffer; }
            set { _SelectedOffer = value; }
        }

        #endregion
        #region Constructors

        public ViewModelViewAnnouncement()
        {
            Offers = new ObservableCollection<Offer>(this.Entities.Offers);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

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

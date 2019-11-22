using MaterialDesignThemes.Wpf;
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
        /// <summary>
        /// Attribut privé contenant la liste des annonceurs
        /// </summary>
        private ObservableCollection<Producer> _Producers;

        /// <summary>
        /// Attribut privé contenant l'annonceur sélectionné
        /// </summary>
        private Producer _SelectedProducer;

        /// <summary>
        /// Attribut privé contenant les messages de la SnackBar
        /// </summary>
        private SnackbarMessageQueue _MyMessageQueue;
        #endregion



        #region Properties
        /// <summary>
        /// Affecte ou retourne les messages de la SnackBar
        /// </summary>
        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }

        /// <summary>
        /// Affecte ou retourne la liste des annonceurs
        /// </summary>
        public ObservableCollection<Producer> Producers
        {
            get { return _Producers; }
            set { _Producers = value; }
        }

        /// <summary>
        /// Affecte ou retourne l'annonceur sélectionné
        /// </summary>
        public Producer SelectedProducer
        {
            get { return _SelectedProducer; }
            set { _SelectedProducer = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ViewModel de l'annonceur
        /// </summary>
        public ViewModelViewProducer()
        {
            Producers = new ObservableCollection<Producer>(this.Entities.Producers);
            MyMessageQueue = new SnackbarMessageQueue(); 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant de créer un nouvel annonceur dans l'application sans l'ajouter dans la base de données
        /// </summary>
        public void AddProducer()
        {
            try {
                Producer producer = new Producer();
                producer.Name = "Saisir un nom";
                producer.UserName = CreateRandomPassphrase(8);
                producer.Password = CreateRandomPassphrase(15);

                this.Producers.Add(producer);
                this.Entities.Producers.Add(producer);
                
                MyMessageQueue.Enqueue("Un producteur a été ajouté, pensez à l'enregistrer");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }
            


        }

        /// <summary>
        /// Méthode permettant de supprimer l'annonceur sélectionnée de la base de données
        /// </summary>
        public void DeleteProduter()
        {
            try {
                this.Entities.Producers.Remove(SelectedProducer);
                this.Producers.Remove(SelectedProducer);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Le producteur a bien été supprimé");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }
            
        }

        /// <summary>
        /// Méthode permettant de sauvegarder les changements en base de données concernant l'annonceur sélectionné
        /// </summary>
        public void SaveProducer()
        {
            try {
                Producers.Where(producer => producer.Identifier.Equals(SelectedProducer.Identifier));
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue(SelectedProducer.Name + " a bien été modifié !");
            }
            catch
            {
                MyMessageQueue.Enqueue("Wow, une erreur s'est produite !");
            }
            
            
        }

        /// <summary>
        /// Méthode permettant de créer une chaine alphanumérique aléatoire dont la longueur est passée en paramètre
        /// </summary>
        /// <param name="length"></param>
        /// <returns>Retourne la chaine de type string</returns>
        public static string CreateRandomPassphrase(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        #endregion


        
    }
}

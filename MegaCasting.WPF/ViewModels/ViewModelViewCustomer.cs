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
    /// <summary>
    /// ViewModel de l'entité Client
    /// </summary>
    class ViewModelViewCustomer : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Attribut privé stockant la liste de clients
        /// </summary>
        private ObservableCollection<Customer> _Customers;

        /// <summary>
        /// Attribut privé contenant le client sélectionné
        /// </summary>
        private Customer _SelectedCustomer;

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
        /// Affecte ou retourne la liste des clients
        /// </summary>
        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }
        /// <summary>
        /// Affecte ou retourne le client sélectionné
        /// </summary>
        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set { _SelectedCustomer = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ModelView du client
        /// </summary>
        public ViewModelViewCustomer()
        {
            Customers = new ObservableCollection<Customer>(this.Entities.Customers);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant d'ajouter un client dans l'application, cette méthode n'implémente pas la sauvegarde dans la BDD 
        /// et les changements seront perdus si l'élément perd le focus
        /// </summary>
        public void AddCustomer()
        {
            try
            {
                Customer Customer = new Customer();
                Customer.Name = "Saisir un nom";
                Customer.UserName = CreateRandomPassphrase(8);
                Customer.Password = CreateRandomPassphrase(15);

                this.Customers.Add(Customer);
                this.Entities.Customers.Add(Customer);

                MyMessageQueue.Enqueue("Un producteur a été ajouté, pensez à l'enregistrer");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }



        }
        /// <summary>
        /// Méthode permettant de supprimer le client sélectionnée de la base de données
        /// </summary>
        public void DeleteCustomer()
        {
            try
            {
                this.Entities.Customers.Remove(SelectedCustomer);
                this.Customers.Remove(SelectedCustomer);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Le producteur a bien été supprimé");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }

        }
        /// <summary>
        /// Permet de sauvegarder en base de données les changements appliqués au client sélectionné
        /// </summary>
        public void SaveCustomer()
        {
            try
            {
                Customers.Where(Customer => Customer.Identifier.Equals(SelectedCustomer.Identifier));
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue(SelectedCustomer.Name + " a bien été modifié !");
            }
            catch
            {
                MyMessageQueue.Enqueue("Wow, une erreur s'est produite !");
            }


        }

        /// <summary>
        /// Méthode permettant de créer une chaîne de caractères alphanumérique d'une longeur passée en paramètres
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
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

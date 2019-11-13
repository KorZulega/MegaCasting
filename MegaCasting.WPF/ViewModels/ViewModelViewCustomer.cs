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
    class ViewModelViewCustomer : ViewModelBase
    {
        #region Attributes
        private ObservableCollection<Customer> _Customers;
        #endregion
        private Customer _SelectedCustomer;
        private SnackbarMessageQueue _MyMessageQueue;

        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }




        #region Properties
        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }

        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set { _SelectedCustomer = value; }
        }
        #endregion
        #region Constructor
        public ViewModelViewCustomer()
        {
            Customers = new ObservableCollection<Customer>(this.Entities.Customers);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

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

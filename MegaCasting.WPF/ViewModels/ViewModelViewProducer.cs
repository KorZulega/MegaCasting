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
        private ObservableCollection<Producer> _Producers;
        #endregion
        private Producer _SelectedProducer;
        private SnackbarMessageQueue _MyMessageQueue;

        public SnackbarMessageQueue MyMessageQueue
        {
            get { return _MyMessageQueue; }
            set { _MyMessageQueue = value; }
        }




        #region Properties
        public ObservableCollection<Producer> Producers
        {
            get { return _Producers; }
            set { _Producers = value; }
        }

        public Producer SelectedProducer
        {
            get { return _SelectedProducer; }
            set { _SelectedProducer = value; }
        }
        #endregion
        #region Constructor
        public ViewModelViewProducer()
        {
            Producers = new ObservableCollection<Producer>(this.Entities.Producers);
            MyMessageQueue = new SnackbarMessageQueue(); 
        }

        #endregion

        #region Methods

        public void AddProducer()
        {
            try {
                Producer producer = new Producer();
                producer.Name = "Saisir un nom";
                producer.Password = CreateRandomPassword(15);

                this.Producers.Add(producer);
                this.Entities.Producers.Add(producer);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Yay! Il a bien été ajouté !");
            }
            catch
            {
                MyMessageQueue.Enqueue("Wow, une erreur s'est produite !");
            }
            


        }

        public void DeleteProduter()
        {
            try {
                this.Entities.Producers.Remove(SelectedProducer);
                this.Producers.Remove(SelectedProducer);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Yes, il est parti dans les couloirs du temps !");
            }
            catch
            {
                MyMessageQueue.Enqueue("Wow, une erreur s'est produite !");
            }
            
        }

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

        public static string CreateRandomPassword(int length)
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

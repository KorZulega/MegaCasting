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
    class ViewModelViewJob : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Attribut privé stockant la liste de Métiers
        /// </summary>
        private ObservableCollection<Job> _Jobs;

        private ObservableCollection<JobType> _JobTypes;

        /// <summary>
        /// Attribut privé contenant le Métier sélectionné
        /// </summary>
        private Job _SelectedJob;

        private JobType _SelectedJobType;
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
        /// Affecte ou retourne la liste des Métiers
        /// </summary>
        public ObservableCollection<Job> Jobs
        {
            get { return _Jobs; }
            set { _Jobs = value; }
        }
        /// <summary>
        /// Affecte ou retourne le Métier sélectionné
        /// </summary>
        public Job SelectedJob
        {
            get { return _SelectedJob; }
            set { _SelectedJob = value; }
        }
        public ObservableCollection<JobType> JobTypes
        {
            get { return _JobTypes; }
            set { _JobTypes = value; }
        }

        public JobType SelectedJobType
        {
            get { return _SelectedJobType; }
            set { _SelectedJobType = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ModelView du Métier
        /// </summary>
        public ViewModelViewJob()
        {
            Jobs = new ObservableCollection<Job>(this.Entities.Jobs);
            JobTypes = new ObservableCollection<JobType>(this.Entities.JobTypes);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant d'ajouter un Métier dans l'application, cette méthode n'implémente pas la sauvegarde dans la BDD 
        /// et les changements seront perdus si l'élément perd le focus
        /// </summary>
        public void AddJob()
        {
            try
            {
                Job Job = new Job();
                Job.Name = "Saisir un nom";
                
                
                this.Jobs.Add(Job);
                this.Entities.Jobs.Add(Job);

                MyMessageQueue.Enqueue("Un Métier a été ajouté, pensez à l'enregistrer");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }



        }
        /// <summary>
        /// Méthode permettant de supprimer le Métier sélectionnée de la base de données
        /// </summary>
        public void DeleteJob()
        {
            try
            {
                this.Entities.Jobs.Remove(SelectedJob);
                this.Jobs.Remove(SelectedJob);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Le Métier a bien été supprimé");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }

        }
        /// <summary>
        /// Permet de sauvegarder en base de données les changements appliqués au Métier sélectionné
        /// </summary>
        public void SaveJob()
        {
            try
            {
                SelectedJob.IdentifierJobType = SelectedJobType.Identifier;
                Jobs.Where(Job => Job.Identifier.Equals(SelectedJob.Identifier));
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue(SelectedJob.Name + " a bien été modifié !");
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

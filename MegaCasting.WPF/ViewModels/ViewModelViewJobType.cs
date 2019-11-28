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
    class ViewModelViewJobType : ViewModelBase
    {


        #region Attributes
        /// <summary>
        /// Attribut privé stockant la liste de Domaine de métiers
        /// </summary>
        private ObservableCollection<JobType> _JobTypes;

        /// <summary>
        /// Attribut privé contenant le Domaine de métier sélectionné
        /// </summary>
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
        /// Affecte ou retourne la liste des Domaine de métiers
        /// </summary>
        public ObservableCollection<JobType> JobTypes
        {
            get { return _JobTypes; }
            set { _JobTypes = value; }
        }
        /// <summary>
        /// Affecte ou retourne le Domaine de métier sélectionné
        /// </summary>
        public JobType SelectedJobType
        {
            get { return _SelectedJobType; }
            set { _SelectedJobType = value; }
        }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructeur du ModelView du Domaine de métier
        /// </summary>
        public ViewModelViewJobType()
        {
            JobTypes = new ObservableCollection<JobType>(this.Entities.JobTypes);
            MyMessageQueue = new SnackbarMessageQueue();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant d'ajouter un Domaine de métier dans l'application, cette méthode n'implémente pas la sauvegarde dans la BDD 
        /// et les changements seront perdus si l'élément perd le focus
        /// </summary>
        public void AddJobType()
        {
            try
            {
                JobType JobType = new JobType();
                JobType.Name = "Saisir un nom";
                this.JobTypes.Add(JobType);
                this.Entities.JobTypes.Add(JobType);

                MyMessageQueue.Enqueue("Un Domaine de métier a été ajouté, pensez à l'enregistrer");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }



        }
        /// <summary>
        /// Méthode permettant de supprimer le Domaine de métier sélectionnée de la base de données
        /// </summary>
        public void DeleteJobType()
        {
            try
            {
                this.Entities.JobTypes.Remove(SelectedJobType);
                this.JobTypes.Remove(SelectedJobType);
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue("Le domaine de métier a bien été supprimé");
            }
            catch
            {
                MyMessageQueue.Enqueue("Une erreur s'est produite !");
            }

        }
        /// <summary>
        /// Permet de sauvegarder en base de données les changements appliqués au Domaine de métier sélectionné
        /// </summary>
        public void SaveJobType()
        {
            try
            {
                JobTypes.Where(JobType => JobType.Identifier.Equals(SelectedJobType.Identifier));
                this.Entities.SaveChanges();
                MyMessageQueue.Enqueue(SelectedJobType.Name + " a bien été modifié !");
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

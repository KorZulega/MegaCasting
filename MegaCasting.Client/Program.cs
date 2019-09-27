using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBLib;

namespace MegaCasting.Client
{
    /// <summary>
    /// Classe du programme principal
    /// </summary>
    class Program
    {

        /*
         * Voici un exemple de projet incluant une base de donnée connectée via EntiryFramework, voici les étapes à suivre :
         * 
         * 1- Créer sa base de données sur SSMS (penser au clés primaires et unicité)
         * 2- ajouter un projet de base de données dans le projet en cours (avec les identifiants)
         * 3- Comparer les schémas en ayant pour source votre Db et pour cible votre projet
         * 4- Ajouter ADO.NET Entity Data Model dans la bibliothèque de classes, connectez vous à votre base et créer un fichier App.config
         * 5- Ajouter EntityFramework dans MegaCsting.DBLib
         * 6- Créer une référence de votre MegaCasting.DBLib dans les références du projet
         * 7- Ajouter EntityFramework dans votre projet principal (MegaCasting.Client) 
         * 8- Ajouter la chaine de connexion de votre App.config vers votre App.config de votre programme principal (lignes XML)
         * 9- Ajouter un using MegaCasting.DBLib dans le Program.cs
         * 
         */

        #region Static Attributes

        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion


        #region Static Methods
        /// <summary>
        /// Méthode principale
        /// </summary>
        /// <param name="args">arguements passés en paramètre</param>
        static void Main(string[] args)
        {
            Console.WriteLine(
                "---MegaCasting---" + Environment.NewLine
                + "1 - Ajout d'un producteur" + Environment.NewLine
                + "2 - Modification d'un producteur" + Environment.NewLine
                + "3 - Suppression d'un producteur"

                );
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {

                

                case "1":




                    break;
                case "2":




                    break;
                case "3":




                    break;

                default:
                    break;
            }
            ////Intanciation du contexte
            //MegaCastingEntities entities = new MegaCastingEntities();

            //List<ContractType> contractTypes = entities.ContractTypes.ToList();

            //contractTypes
            //    .ForEach(contractType => Console.WriteLine(contractType.Name));
            //Console.ReadKey();




        }


        public static void AddProducer()
        {
            Producer producer = new Producer();

            Console.WriteLine("Le nom du producteur :");

            producer.Name = Console.ReadLine();
            Console.WriteLine("Un mot de passe par défaut va être affecté");
            producer.Password = " "; //TODO : Générer un mdp aléatoire
            //On ajoute le producteur à la liste
            megaCastingEntities.Producers.Add(producer);
            //On push les modifications en base de données
            megaCastingEntities.SaveChanges();
        }

        #endregion
    }
}

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
            
            string userChoice = "";
            do
            {
                Console.WriteLine(
                "---MegaCasting---" + Environment.NewLine
                + "1 - Ajout d'un producteur" + Environment.NewLine
                + "2 - Modification d'un producteur" + Environment.NewLine
                + "3 - Suppression d'un producteur"

                );
                userChoice = Console.ReadLine();
                switch (userChoice)
                {



                    case "1":

                        AddProducer();


                        break;
                    case "2":


                        EditProducer();

                        break;
                    case "3":

                        ListProducers();


                        break;

                    default:
                        break;
                }
            }
            while (userChoice != "0");
            
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

        public static void EditProducer()
        {
            List<Producer> producers = megaCastingEntities.Producers.ToList();

            Console.WriteLine("Choisissez un producteur à modifier");

            producers.ForEach(producer => Console.WriteLine(producer.Identifier + " - " + producer.Name));

            string choice = Console.ReadLine();

            int isInteger = 0;


            if (int.TryParse(choice, out isInteger))
            {

                if(megaCastingEntities.Producers.Any(producer => producer.Identifier == isInteger))
                {
                    Producer producer = megaCastingEntities.Producers.First(producer1 => producer1.Identifier == isInteger);


                    Console.WriteLine("Donnez un nouveau nom à : " + producer.Name);

                    string modifier = Console.ReadLine();

                    producer.Name = modifier;


                    megaCastingEntities.SaveChanges();

                    Console.WriteLine("Le nouveau nom est bien" + modifier);

                }

                else
                {
                    Console.WriteLine("Impossible de trouver le producteur correspondant à l'ID demandé");
                }

            }

        }


        public static void ListProducers()
        {
            //Récupération de la liste des producteurs
            List<Producer> producers = megaCastingEntities.Producers.ToList();
            //Affichage de la liste des producteurs de la base de données
            producers.ForEach(producer => Console.WriteLine(producer.Identifier + " - " + producer.Name));

            //Demande de suppresion éventuelle ?

            Console.WriteLine("Souhaitez-vous supprimer un producteur ? Entrez l'ID correspondant");

            producers.ForEach(producer => Console.WriteLine(producer.Identifier + " - " + producer.Name));

            string choice = Console.ReadLine();

            int isInteger = 0;

            if (int.TryParse(choice, out isInteger))
            {
                //Méthode alternative
                //Producer producer1 = megaCastingEntities.Producers.FirstOrDefault((producer => producer.Identifier == isInteger));

                //if(producer1 != null)
                //{

                //}

                //On vérifie que le producteur choisi exsite
                if (megaCastingEntities.Producers.Any(producer => producer.Identifier == isInteger))
                {
                    //Suppresson si VRAI
                    Producer producer = megaCastingEntities.Producers.First(producerTemp => producerTemp.Identifier == isInteger);

                    megaCastingEntities.Producers.Remove(producer);

                    //Validation de la supprssion
                    megaCastingEntities.SaveChanges();

                    //Retour confirmation
                    Console.WriteLine("Le producteur sélectionné a bien été supprimé");
                }
                else
                {
                    //Retour erreur si FAUX
                    Console.WriteLine("Aucun producteur n'a été trouve à cet ID");
                }
            }
        }

        #endregion
    }
}

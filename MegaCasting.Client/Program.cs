using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBLib;

namespace MegaCasting.Client
{
    class Program
    {

        /*
         * Voici un exemple de projet incluant une base de donnée connectée via EntiryFramework, voici les étapes à suivre :
         * 
         * 1- Créer sa base de données sur SSMS (penser au clés primaires et unicité)
         * 2- ajouter une base de données dans le projet en cours (avec les identifiants)
         * 3- Comparer les schémas en ayant pour source votre Db et pour cible votre projet
         * 4- Ajouter ADO.NET Entity Data Model, connectez vous à votre base et créer un fichier App.config
         * 5- Créer une référence de votre MegaCasting.DBLib dans les références du projet
         * 6- Ajouter EntityFramework dans votre projet principal (MegaCasting.Client) 
         * 7- Ajouter la chaine de connexion de votre App.config vers votre App.config de votre programme principal
         * 
         */
        
        
        static void Main(string[] args)
        {
            //Intanciation du contexte
            MegaCastingEntities entities = new MegaCastingEntities();

            List<ContractType> contractTypes = entities.ContractTypes.ToList();

            contractTypes
                .ForEach(contractType => Console.WriteLine(contractType.Name));
            Console.ReadKey();


            

        }
    }
}

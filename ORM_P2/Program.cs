using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new FSRepository();

            int c = 50;

            while(c!=0)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter 1 to get a list of clubs");
                System.Console.WriteLine("Enter 2 to get a list of figure skaters for each club");
                System.Console.WriteLine("Enter 3 to add a club");
                System.Console.WriteLine("Enter 4 to add a figure skater");
                System.Console.WriteLine("Enter 0 to exit the programm");


                c = Convert.ToInt32(System.Console.ReadLine());

                switch(c)
                {
                    case 1:
                        repository.GetClubs();
                        break;
                    case 2:
                        repository.GetClubsAndFigureSkaters();
                        break;
                    case 3:
                        repository.AddClub();
                        break;
                    case 4:
                        repository.AddFSkater();
                        break;                
                }
            }
        }        
    }
}

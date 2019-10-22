using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;

namespace ORM_P2
{
    class FSRepository
    {
        public void AddClub()
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        System.Console.WriteLine("Enter a name");
                        string name = System.Console.ReadLine();

                        System.Console.WriteLine("Enter a city");
                        string city = System.Console.ReadLine();

                        System.Console.WriteLine("Enter a country");
                        string country = System.Console.ReadLine();

                        Club club = new Club
                        {
                            Name = name,
                            City = city,
                            Country = country
                        };
                        session.SaveOrUpdate(club);
                        transaction.Commit();
                        System.Console.WriteLine("Club is recorded!");
                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("Something went wrong! Check the input!");
                    }                    
                }
            }
        }

        public void AddClub(Club club)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                    
                    session.SaveOrUpdate(club);
                    transaction.Commit();                    
                }
            }
        }

        public void AddFSkater()
        {
            bool success = true;
            FigureSkater figureSkater;
            Club club = null;

            using (ISession session = HibernateHelper.OpenSession())
            {

                System.Console.WriteLine();
                try
                {
                    System.Console.WriteLine("Enter a club Id");
                    int id = Convert.ToInt32(System.Console.ReadLine());

                    club = session.Get<Club>(id);
                    if (club == null) throw new Exception();

                    System.Console.WriteLine("Enter a first name");
                    string firstName = System.Console.ReadLine();

                    System.Console.WriteLine("Enter a last name");
                    string lastName = System.Console.ReadLine();

                    System.Console.WriteLine("Enter an age");
                    int age = Convert.ToInt32(System.Console.ReadLine());

                    figureSkater = new FigureSkater
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    };

                    club.Add(figureSkater);
                }
                catch (Exception)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Something went wrong! Check the input!");
                    success = false;
                }
            }

            if (success)
            {
                this.AddClub(club);
                System.Console.WriteLine("Figure skater is recorded!");
            }
        }

        public void GetClubs()
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var criteria = session.CreateCriteria<Club>();
                    var clubs = criteria.List<Club>();

                    System.Console.WriteLine();
                    System.Console.WriteLine("Club Id    Name     Location");
                    foreach (var cl in clubs)
                    {
                        System.Console.WriteLine("{0}:   {1}   ||   {2}, {3}", cl.ClubId, cl.Name, cl.City, cl.Country);
                    }
                }
            }
        }

        public void GetClubsAndFigureSkaters()
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                
                var criteria = session.CreateCriteria<Club>();                    
                var clubs = criteria.List<Club>();

                System.Console.WriteLine();
                foreach (var cl in clubs)
                {                        
                    System.Console.WriteLine("{0}:   {1}", cl.ClubId, cl.Name);
                    foreach (var fs in cl.FigureSkaters)
                        System.Console.WriteLine("  {0}: {1} {2}, {3} years old", fs.FigureSkaterId, fs.FirstName, fs.LastName, fs.Age);
                }                
            }
        }      
        
        public void CreateOrUpdateBD()
        {
            var cfg = new Configuration();
            cfg.Configure(); //ищет файл cfg.xml парсит и понимает с какой бд мы работаем, где она лежит
            cfg.AddAssembly(typeof(Club).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}

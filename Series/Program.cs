using System;
using Series.Classes;
using Series.Enums;

namespace Series
{
    class Program
    {
        static SeriesRepo SeriesRepository = new SeriesRepo();
        static void Main(string[] args)
        {
            string userOption = Options();

            while(userOption != "X")
            {
                switch(userOption)
                {
                    case "1":
                    ListSeries();
                    break;
                    
                    case "2":
                    AddSerie();
                    break;

                    case "3":
                    UpdateSerie();
                    break;

                    case "4":
                    DeleteSerie();
                    break;
                    
                    case "5":
                    ViewTitle();
                    break;
                    
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                userOption = Options();
            }
            Console.WriteLine("Exiting...");
        }

        private static void ViewTitle()
        {
            Console.WriteLine("[Showing Title]");
            ListSeries();
            Console.Write("Type series ID to View: ");
            int titleId = int.Parse(Console.ReadLine());
            var serie = SeriesRepository.ReturnById(titleId);
            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("[Deleting Series]");
            ListSeries();

            Console.Write("Type series ID to delete: ");
            int titleID = int.Parse(Console.ReadLine());
            Console.Write("[Do you really want to delete, type Y to confirm] ");
            string option = Console.ReadLine().ToUpper();
            if (option == "Y") SeriesRepository.Delete(titleID);
            else return;
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("[Updating Series]");

            Console.Write("Insert Serie ID: ");
            int selectedId = int.Parse(Console.ReadLine()); 
            int selectedGenre;
            string selectedTitle;
            string selectedDescription;
            int selectedYear;

            ChangeSeriesMenu(out selectedGenre, out selectedTitle, out selectedYear, out selectedDescription);

            Classes.Series newSerie = new Classes.Series
            (
                selectedId, 
                (Genres)selectedGenre, 
                selectedTitle, 
                selectedDescription,
                selectedYear
            );

            SeriesRepository.Update(selectedId, newSerie);
        }

        private static void AddSerie()
        {
            Console.WriteLine("[Inserting Series]");

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genres), i));
            }

            int selectedGenre;
            string selectedTitle;
            string selectedDescription;
            int selectedYear;

            ChangeSeriesMenu(out selectedGenre, out selectedTitle, out selectedYear, out selectedDescription);

            Classes.Series newSerie = new Classes.Series
            (
                SeriesRepository.NextId(), 
                (Genres)selectedGenre, 
                selectedTitle, 
                selectedDescription,
                selectedYear
            );

            SeriesRepository.Insert(newSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("[Listing Series]");
            var list = SeriesRepository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Empty Series List");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.ReturnExcluded();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitle(), deleted? "*Deleted*" : "" );
            }
        }

        private static string Options()
        {

            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - List Titles");
            Console.WriteLine("2 - Add New Title");
            Console.WriteLine("3 - Update Title");
            Console.WriteLine("4 - Delete Title");
            Console.WriteLine("5 - View Title");
            Console.WriteLine("C - Refresh Screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void ChangeSeriesMenu(out int selectedGenre, out string selectedTitle,
                                             out int selectedYear, out string selectedDescription)
        {
            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write("Insert Genrer Value according to the List above: ");
            selectedGenre = int.Parse(Console.ReadLine()); 

            Console.Write("Insert New Title: ");
            selectedTitle = Console.ReadLine(); 
            
            Console.Write("Insert Title Release Year: ");
            selectedYear = int.Parse(Console.ReadLine()); 

            Console.Write("Insert Title Description: ");
            selectedDescription = Console.ReadLine(); 
        }
    }
}

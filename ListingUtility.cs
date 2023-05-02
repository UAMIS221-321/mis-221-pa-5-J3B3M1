using System.Globalization;
namespace mis_221_pa_5_J3B3M1
{
    public class ListingUtility
    {
        private Listing[] listings;

        private Trainer[] trainers;

        public ListingUtility(Listing[] listings, Trainer[] trainers)
        {
            this.listings = listings;
            this.trainers = trainers;
        }

        public void AddListing()
        {
            int input;
            do
            {
                System.Console.WriteLine("Enter ListingID:(****)");

                if(int.TryParse(Console.ReadLine(), out input) && input.ToString().Length == 4)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid Input...Enter 4 digit ListingID");
                }
            }
            while(true);
            
            Listing myListing = new Listing();
            myListing.SetListingID(input);
            

            int searchVal;
            int foundIndex;
            do
            {
                System.Console.WriteLine("Enter TrainerID:");
                searchVal = int.Parse(Console.ReadLine());
                foundIndex = FindTrainer(searchVal);
                if(foundIndex != -1)
                {
                    myListing.SetTrainerName(trainers[foundIndex].GetTrainerName());
                }
                else
                {
                    System.Console.WriteLine("Trainer Not Found");
                }
            }
            while(foundIndex == -1);

            DateTime date;
            string userInput;
            do
            {
                System.Console.WriteLine("Enter Session Date:(mm/dd/yyyy)");
                userInput = Console.ReadLine();

                if(!DateTime.TryParseExact(userInput, "mm/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out date))
                {
                    System.Console.WriteLine("Invalid Date Format");
                }
                else
                {
                    myListing.SetSessionDate(userInput);
                }
            }
            while(!DateTime.TryParseExact(userInput, "mm/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out date));
            
            double userOption;
            do
            {    
                System.Console.WriteLine("Enter Session Cost:(00.00)");
                if(double.TryParse(Console.ReadLine(), out userOption))
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid Input... Use Correct Format");
                }
            }
            while(true);

            int response;
            do
            {
                System.Console.WriteLine("Is this listing availible?\n1.Yes 2.No");
                response = int.Parse(Console.ReadLine());
                
                if(response == 1)
                {
                    myListing.SetAvailability(true);
                }
                else if(response == 2)
                {
                    myListing.SetAvailability(false);
                }
                else
                {
                    System.Console.WriteLine("Invalid Input... Try Again");
                }
            }
            while(response != 1 || response != 2);

            listings[Listing.GetCount()] = myListing;
            Listing.IncCount();

            Save();
            

        }

        private void Save()
        {
            StreamWriter outfile = new StreamWriter("Listing.txt");

            for(int i = 0; i < Listing.GetCount();i++)
            {
                outfile.WriteLine(listings[i].ToFile());
            }

            outfile.Close();
        }

        public int Find(int searchVal)
        {
            for(int i = 0; i < Listing.GetCount();i++)
            {
                if(listings[i].GetListingID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindTrainer(int searchVal)
        {
            for(int i = 0; i < Trainer.GetCount();i++)
            {
                if(trainers[i].GetTrainerID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateListing()
        {
            System.Console.WriteLine("What is the ID of the listing you are trying to find?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
               int input;
                do
                {
                    System.Console.WriteLine("Enter ListingID:(****)");

                    if(int.TryParse(Console.ReadLine(), out input) && input.ToString().Length == 4)
                    {
                        listings[foundIndex].SetListingID(input);
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Input...Enter 4 digit ListingID");
                    }
                }
                while(true);
                int searchValOne;
                int foundIndexOne;
                do
                {
                    System.Console.WriteLine("Enter TrainerID:");
                    searchValOne = int.Parse(Console.ReadLine());
                    foundIndexOne = FindTrainer(searchValOne);
                    if(foundIndexOne != -1)
                    {
                        listings[foundIndex].SetTrainerName(trainers[foundIndexOne].GetTrainerName());
                    }
                    else
                    {
                        System.Console.WriteLine("Trainer Not Found");
                    }
                }
                while(foundIndex == -1);
                DateTime date;
                string userInput;
                do
                {
                    System.Console.WriteLine("Enter Session Date:(mm/dd/yyyy)");
                    userInput = Console.ReadLine();

                    if(!DateTime.TryParseExact(userInput, "mm/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out date))
                    {
                        System.Console.WriteLine("Invalid Date Format");
                    }
                    else
                    {
                        listings[foundIndex].SetSessionDate(userInput);
                    }
                }
                while(!DateTime.TryParseExact(userInput, "mm/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out date));

                double userOption;
                do
                {    
                    System.Console.WriteLine("Enter Session Cost:(00.00)");
                    if(double.TryParse(Console.ReadLine(), out userOption))
                    {
                        listings[foundIndex].SetSessionCost(userOption);
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Input... Use Correct Format");
                    }
                }
                while(true);
                int response;
                do
                {
                    System.Console.WriteLine("Is this listing availible?\n1.Yes 2.No");
                    response = int.Parse(Console.ReadLine());
                    
                    if(response == 1)
                    {
                        listings[foundIndex].SetAvailability(true);
                    }
                    else if(response == 2)
                    {
                        listings[foundIndex].SetAvailability(false);
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Input... Try Again");
                    }
                }
                while(response != 1 || response != 2);

                Save();
            }
            else
            {
                System.Console.WriteLine("Listing not found");
            }
        }

        public void DeleteListing()
        {
            System.Console.WriteLine("What is the ListingID of the listing you are trying to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != 1)
            {
                System.Console.WriteLine("Are you sure you want to delete this listing?");
                System.Console.WriteLine("1:Yes 2:No");
                int response = int.Parse(Console.ReadLine());

                if(response == 1)
                {
                    listings[foundIndex].SetAvailability(false);
                    System.Console.WriteLine("Listing has been deleted!");
                }
                else if(response == 2)
                {
                    System.Console.WriteLine("Listing was not deleted");
                }

                Save();
            }
        }
    }
}
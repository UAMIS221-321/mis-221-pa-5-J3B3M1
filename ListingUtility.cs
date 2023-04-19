namespace mis_221_pa_5_J3B3M1
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public void AddListing()
        {
            System.Console.WriteLine("Enter ListingID:");
            Listing myListing = new Listing();
            myListing.SetListingID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter Trainer Name:");
            myListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Enter Session Date:(mm/dd/yyyy)");
            myListing.SetSessionDate(Console.ReadLine());
            System.Console.WriteLine("Enter Session Cost:(00.00)");
            myListing.SetSessionCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("Is this booking availible?\n1.Yes 2.No");
            int response = int.Parse(Console.ReadLine());
            if(response == 1)
            {
                myListing.SetAvailability(true);
            }
            else if(response == 2)
            {
                myListing.SetAvailability(false);
            }

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

        public void UpdateListing()
        {
            System.Console.WriteLine("What is the ID of the listing you are trying to find?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Enter the listing ID:");
                listings[foundIndex].SetListingID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Enter the trainer name:");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Enter session date:(mm/dd)");
                listings[foundIndex].SetSessionDate(Console.ReadLine());
                System.Console.WriteLine("Enter session cost:(0.00)");
                listings[foundIndex].SetSessionCost(double.Parse(Console.ReadLine()));
                System.Console.WriteLine("Is this session still availible?\n1.Yes 2.No");
                int response = int.Parse(Console.ReadLine());
                if(response == 1)
                {
                    listings[foundIndex].SetAvailability(true);
                }
                else if(response == 2)
                {
                    listings[foundIndex].SetAvailability(false);
                }

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
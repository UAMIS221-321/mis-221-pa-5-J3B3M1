using System;
using mis_221_pa_5_J3B3M1;

const int MAX = 100;
Booking[] bookings = new Booking[MAX];
Booking booking = new Booking();
BookingUtility bookingUtility = new BookingUtility(bookings);

Listing[] listings = new Listing[MAX];
Listing listing = new Listing();

Reports[] reports = new Reports[MAX];
Reports report = new Reports(bookings);


Trainer[] trainers = new Trainer[MAX];
Trainer trainer = new Trainer();
TrainerUtility trainerUtility = new TrainerUtility(trainers);
trainerUtility.GetAllTrainersFromFile();

ListingUtility listingUtility = new ListingUtility(listings, trainers);

int userChoice = -1;
while(userChoice != 5)// looped menu
{
    try
    {
        userChoice = GetUserChoice();
        if(userChoice < 1 || userChoice > 5)
        {
            throw new Exception("Please enter a valid menu choice");
        }
        else
        {
            RouteEm(userChoice,trainerUtility, listingUtility, bookingUtility,booking);
        }
    }
    catch (Exception e)
    {
        System.Console.WriteLine(e.Message);
        userChoice = 0;
        Pause();
    }
    
}

static void MainMenu()
{
    System.Console.WriteLine("Welcome to the TLAC Personal Fitness App!\nSelect one of the following:\n1.Manage Trainer Data\n2.Manage Listing Data\n3.Manage Customer Booking Data\n4.Reports\n5.Exit");

}

static int GetUserChoice()
{
    MainMenu();
    string userChoice = Console.ReadLine();
    if(IsValidChoice(userChoice))
    {
        return int.Parse(userChoice);
    }
    else return 0;


}

static bool IsValidChoice(string userInput)
{
    if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5")
    {
        return true;
    }
    else return false;
}

static void RouteEm(int menuChoice , TrainerUtility trainerUtility, ListingUtility listingUtility, BookingUtility bookingUtility, Booking booking)
{
    if(menuChoice == 1)
    {
        ManageTrainer(trainerUtility);
    }
    else if(menuChoice == 2)
    {
        ManageListing(listingUtility);
    }
    else if(menuChoice == 3)
    {
        ManageCustomerBookings(bookingUtility,booking);
    }
    else if(menuChoice == 4)
    {
        ViewReports();
    }
}

static void SayInvalid()
{
    System.Console.WriteLine("Invalid");
}

static void Pause()
{
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static void ManageTrainer(TrainerUtility trainerUtility)
{
    Console.Clear();
    System.Console.WriteLine("Welcome to Trainer Management! Select one of the following:\n1.Add Trainer\n2.Edit Trainer\n3.Delete Trainer\n4.Exit");
    int userChoice = int.Parse(Console.ReadLine());
    
    while(userChoice < 1 || userChoice > 4)
    {
        try
        {
            if(userChoice < 1 || userChoice > 4)
            {
                throw new Exception("Please enter a valid menu choice");
                // ManageTrainer(trainerUtility);
            }
            // else
            // {
            //     ManageTrainer(trainerUtility);
            // }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            Pause();
            // ManageTrainer(trainerUtility); 
        }

        System.Console.WriteLine("Welcome to Trainer Management! Select one of the following:\n1.Add Trainer\n2.Edit Trainer\n3.Delete Trainer\n4.Exit");
        userChoice = int.Parse(Console.ReadLine());
    }
    

    if(userChoice == 1)
    {
        trainerUtility.AddTrainer();
        Pause();
    }
    else if(userChoice == 2)
    {
        
        trainerUtility.UpdateTrainer();
        Pause();    
    }
    else if(userChoice == 3)
    {
        trainerUtility.DeleteTrainer();
        Pause();
    }    
}


static void ManageListing(ListingUtility listingUtility)
{
    Console.Clear();
    System.Console.WriteLine("Welcome to Listing Management! Select one of the following:\n1.Add Listing\n2.Edit Listing\n3.Delete Listing\n4.Exit");
    int userChoice = int.Parse(Console.ReadLine());

    while(userChoice < 1 || userChoice > 4)
    {
        try
        {
            if(userChoice < 1 || userChoice > 4)
            {
                throw new Exception("Please enter a valid menu choice");
            }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            Pause();
        }
        System.Console.WriteLine("Welcome to Listing Management! Select one of the following:\n1.Add Listing\n2.Edit Listing\n3.Delete Listing\n4.Exit");
        userChoice = int.Parse(Console.ReadLine());
    }


    if(userChoice == 1)
    {
        listingUtility.AddListing();
        Pause();
    }
    else if(userChoice == 2)
    {
        listingUtility.UpdateListing();
        Pause();
    }
    else if(userChoice == 3)
    {
        listingUtility.DeleteListing();
        Pause();
    }
}

static void ManageCustomerBookings(BookingUtility bookingUtility, Booking booking)
{
    Console.Clear();
    System.Console.WriteLine("Welcome to Booking Management! Select one of the following:\n1.View Bookings\n2.Book Session\n3.Edit Booking\n4.Exit");
    int userChoice = int.Parse(Console.ReadLine());

    while(userChoice < 1 || userChoice > 4)
    {
        try
        {
            if(userChoice < 1 || userChoice > 4)
            {
                throw new Exception("Please enter a valid menu choice");
            }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            Pause();
        }
        System.Console.WriteLine("Welcome to Booking Management! Select one of the following:\n1.View Bookings\n2.Book Session\n3.Edit Booking\n4.Exit");
        userChoice = int.Parse(Console.ReadLine());
    }

    if(userChoice == 1)
    {
        if(Booking.GetCount() > 0)
        {
            bookingUtility.PrintAllBookings();
            System.Console.WriteLine("(* True = Booked *)\n(* False = Completed/Canceled *)");
            Pause();
        }
        else
        {
            System.Console.WriteLine("There are currently no bookings! Make one today!");
            Pause();
        }
    }
    else if(userChoice == 2)
    {    
        bookingUtility.AddBooking();
        Pause();        
    }
    else if(userChoice == 3)
    {
        if(Booking.GetCount() > 0)
        {
            bookingUtility.EditBooking();
            Pause();
        }
        else
        {
            System.Console.WriteLine("There are currently no bookings to edit! Make one today!");
            Pause();
        }
    }
}

static void ViewReports()
{
    Console.Clear();
    System.Console.WriteLine("Welcome to the Reports Menu!Choose one of the following:\n1.Individual Customer Sessions\n2.Historical Customer Session\n3.Historical Revenue Report");

    int userChoice = int.Parse(Console.ReadLine());

    while(userChoice < 1 || userChoice > 3)
    {
        try
        {
            if(userChoice < 1 || userChoice > 3)
            {
                throw new Exception("Please enter a valid menu choice");
            }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            Pause();
        }
        System.Console.WriteLine("Welcome to the Reports Menu!Choose one of the following:\n1.Individual Customer Sessions\n2.Historical Customer Session\n3.Historical Revenue Report");
        userChoice = int.Parse(Console.ReadLine());
    }

    if(userChoice == 1)
    {
        
    }
    else if(userChoice == 2)
    {
        HistoricalCustomerSession();
    }
    else if(userChoice == 3)
    {
        HistoricalRevenueReport();
    }
}



static void HistoricalCustomerSession()
{

}

static void HistoricalRevenueReport()
{

}



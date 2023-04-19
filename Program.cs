using System;
using mis_221_pa_5_J3B3M1;

int userChoice = GetUserChoice();
while(userChoice != 5)// looped menu
{
    RouteEm(userChoice);
    userChoice = GetUserChoice();
}

static void MainMenu()
{
    System.Console.WriteLine("Welcome to the TLAC Personal Fitness App!\n Select one of the following:\n1:Manage Trainer Data\n2.Manage Listing Data\n3.Manage Customer Booking Data\n4.Reports\n5.Exit");

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

static void RouteEm(int menuChoice)
{
    if(menuChoice == 1)
    {
        ManageTrainer();
    }
    else if(menuChoice == 2)
    {
        ManageListing();
    }
    else if(menuChoice == 3)
    {
        ManageCustomerBookings();
    }
    else if(menuChoice == 4)
    {
        ViewReports();
    }
    else if(menuChoice != 5)
    {
        SayInvalid();
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

static void ManageTrainer()
{

}

static void ManageListing()
{

}

static void ManageCustomerBookings()
{

}

static void ViewReports()
{

}


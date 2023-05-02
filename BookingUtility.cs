namespace mis_221_pa_5_J3B3M1
{
    public class BookingUtility
    {
        private Booking[] bookings;

        public BookingUtility(Booking[] bookings)
        {
            this.bookings = bookings;
        }

        public void AddBooking()
        {
            System.Console.WriteLine("Enter bookingID(****):");
            Booking mybooking = new Booking();
            mybooking.SetSessionID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter customer name:");
            mybooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Enter customer email:");
            mybooking.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Enter the training date (mm/dd/yyyy):");
            mybooking.SetTrainingDate(Console.ReadLine());
            System.Console.WriteLine("Enter trainerID(****):");
            mybooking.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter trainer name:");
            mybooking.SetTrainerName(Console.ReadLine());

            mybooking.SetStatus(true);

            bookings[Booking.GetCount()] = mybooking;
            Booking.IncCount();

            Save();

        }

        private void Save()
        {
            StreamWriter outfile = new StreamWriter("Transactions.txt");

            for(int i = 0; i < Booking.GetCount();i++)
            {
                outfile.WriteLine(bookings[i].ToFile());
            }

            outfile.Close();
        }

        public int Find(int searchVal)
        {
            for(int i = 0; i < Trainer.GetCount();i++)
            {
                if(bookings[i].GetSessionID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public void EditBooking()
        {
            System.Console.WriteLine("What is the ID# of the booking you are trying to edit?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Enter bookingID(****):");
                bookings[foundIndex].SetSessionID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Enter the customer name:");
                bookings[foundIndex].SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Enter customer email:");
                bookings[foundIndex].SetCustomerEmail(Console.ReadLine());
                System.Console.WriteLine("Enter training date(dd/mm/yyyy):");
                bookings[foundIndex].SetTrainingDate(Console.ReadLine());
                System.Console.WriteLine("Enter trainerID(****)");
                bookings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Enter trainer name:");
                bookings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Has this booking been completed and/or cancelled?\n1:Yes 2:No");
                int response = int.Parse(Console.ReadLine());
                if(response == 1)
                {
                    bookings[foundIndex].SetStatus(false);
                }
                else if(response == 2)
                {
                    bookings[foundIndex].SetStatus(true);
                }

                Save();
            }
        }

        public void DeleteBooking()
        {
            System.Console.WriteLine("What is the ID# of the booking you are trying to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine($"Are you sure you want to delete the following booking:{bookings[foundIndex].GetSessionID()} with {bookings[foundIndex].GetTrainerName()}?");
                System.Console.WriteLine("1:Yes 2:No");
                int response = int.Parse(Console.ReadLine());

                if(response == 1)
                {
                    bookings[foundIndex].SetStatus(false);
                    System.Console.WriteLine("The booking has been canceled.");
                }
                else if(response == 2)
                {
                    System.Console.WriteLine("Booking has not been canceled.");
                }
            }  
        }

        public void PrintAllBookings()
        {
            for(int i = 0;i < Booking.GetCount();i++)
            {
                if(bookings[i].GetStatus() == true)
                {
                    System.Console.WriteLine(bookings[i].ToString());
                }
                
            }
        }
    }
}
namespace mis_221_pa_5_J3B3M1
{
    public class Reports
    {
        Booking[] bookings;

        public Reports(Booking[] bookings)
        {
            this.bookings = bookings;
        }

        public void PreviousSessionsReport()
        {
            System.Console.WriteLine("Please input customer email:");
            string email = Console.ReadLine();

            string filename = "Transactions.txt";

            if(File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    bool foundCustomer = false;

                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] temp = line.Split('#');

                        int tempSessionID = int.Parse(temp[0]);
                        string tempCustomerEmail = temp[2];
                        string tempSessionDate = temp[3];
                        int tempTrainerID = int.Parse(temp[4]);
                        string tempTrainerName = temp[5];

                        if(tempCustomerEmail.ToLower() == email.ToLower())
                        {
                            foundCustomer = true;
                            System.Console.WriteLine($"{tempSessionID}\t{tempSessionDate}\t{tempTrainerID}\t{tempTrainerName}");
                            
                        }
                        line = reader.ReadLine();
                        


                    }
                    if(!foundCustomer)
                    {
                        System.Console.WriteLine($"No training sessions found for customer {email}");
                    }
                    reader.Close();
                }
                
            }
            System.Console.WriteLine("Would you like to save this report?\n1:Yes\n2:No");
            int response = int.Parse(Console.ReadLine());
            if(response == 1)
            {
                StreamWriter newReport = new StreamWriter("Reports.txt");
                
                StreamReader transaction = new StreamReader("Transactions.txt");
                string line = transaction.ReadLine();
                while(line != null)
                {
                    string[] temp = line.Split('#');
                    int tempSessionID = int.Parse(temp[0]);
                    int tempTrainerID = int.Parse(temp[4]);
                    newReport.Write($"{tempSessionID}#{temp[1]}#{temp[2]}#{temp[3]}#{tempTrainerID}#{temp[5]}#{temp[6]}");
                    
                    line = transaction.ReadLine();

                }
                

                newReport.Close();
                transaction.Close();

            }
            else if(response == 2)
            {

            }

        }

        public void HistoricalSessionsReport()
        {
            
        }

        public void HistoricalRevenueReport()
        {

        }
    }
}
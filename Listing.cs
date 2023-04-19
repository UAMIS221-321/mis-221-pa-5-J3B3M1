namespace mis_221_pa_5_J3B3M1
{
    public class Listing
    {
        private int listingID;

        private string trainerName;

        private string sessionDate;

        private double sessionCost;

        private bool availability; 

        static private int count;

        public Listing()
        {

        }

        public Listing(int listingID, string trainerName, string sessionDate, double sessionCost, bool availability)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionCost = sessionCost;
            this.availability = true;
        }

        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }

        public int GetListingID()
        {
            return listingID;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate()
        {
            return sessionDate;
        }

        public void SetSessionCost(double sessionCost)
        {
            this.sessionCost = sessionCost;
        }

        public double GetSessionCost()
        {
            return sessionCost;
        }

        public void SetAvailability(bool availability)
        {
            this.availability = availability;
        }

        public bool GetAvailability()
        {
            return availability;
        }

        public void SetListingStatus()
        {
            availability = !availability;
        }

        static public void SetCount(int count)
        {
            Listing.count = count;
        }

        static public int GetCount()
        {
            return Listing.count;
        }

        static public void IncCount()
        {
            Listing.count++;
        }

        public override string ToString()
        {
            return $"ListingID:{listingID} is with trainer {trainerName}! The listing is for {sessionDate} and cost {sessionCost}.";

        }

        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionCost}#{availability}";
        }

    }
}
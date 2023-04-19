namespace mis_221_pa_5_J3B3M1
{
    public class Booking
    {
        private int sessionID;

        private string customerName;

        private string customerEmail;

        private string trainingDate;

        private int trainerID;

        private string trainerName;

        private bool status;

        static private int count;

        public Booking()
        {

        }

        public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, bool status)
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = true;
        }

        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }

        public int GetSessionID()
        {
            return sessionID;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        }

        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
        }

        public string GetTrainingDate()
        {
            return trainingDate;
        }

        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }

        public int GetTrainerID()
        {
            return trainerID;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetStatus(bool status)
        {
            this.status = status;
        }

        public bool GetStatus()
        {
            return status;
        }

        public void SetBookingStatus()
        {
            status = !status;
        }

        static public void SetCount(int count)
        {
            Booking.count = count;
        }

        static public int GetCount()
        {
            return Booking.count;
        }

        static public void IncCount()
        {
            Booking.count++;
        }

        public override string ToString()
        {
            return $"SessionID:{sessionID}\nCustomer Name:{customerName}\nCustomer Email:{customerEmail}\nTraining Date:{trainingDate}\n TrainerID:{trainerID}\n Trainer Name:{trainerName}\n Booking Status:{status}";
        }

        public string ToFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}"; 
        }
    }
}
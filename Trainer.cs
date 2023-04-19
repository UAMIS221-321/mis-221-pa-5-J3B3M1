namespace mis_221_pa_5_J3B3M1
{
    public class Trainer
    {
        private int trainerID;

        private string trainerName;

        private string address;

        private string email;

        private bool active;

        static private int count;

        public Trainer()
        {

        }

        public Trainer(int trainerID, string trainerName, string address, string email, bool active)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.address = address;
            this.email = email;
            this.active = true;
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

        public void SetTrainerAddress(string address)
        {
            this.address = address;
        }

        public string GetTrainerAddress()
        {
            return address;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public bool GetActive()
        {
            return active;
        }

        public void SetTrainerStatus()
        {
            active = !active;
        }

        static public void SetCount(int count)
        {
            Trainer.count = count;
        }

        static public int GetCount()
        {
            return Trainer.count;
        }

        static public void IncCount()
        {
            Trainer.count++;
        }

        public override string ToString()
        {
            return $"TrainerID:{trainerID} belongs to trainer {trainerName}, who lives at {address}.\nYou can contact them by emailing them at:{email}";
        }

        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{address}#{email}#{active}";
        }
    }
}
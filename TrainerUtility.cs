namespace mis_221_pa_5_J3B3M1
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void AddTrainer()
        {
            System.Console.WriteLine("Please enter trainer ID(****):");
            Trainer myTrainer = new Trainer();
            myTrainer.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter trainer name:");
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter trainer's address:");
            myTrainer.SetTrainerAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter trainers email:");
            myTrainer.SetEmail(Console.ReadLine());
            System.Console.WriteLine("Is this trainer currently active?\n1.Yes 2.No");
            int response = int.Parse(Console.ReadLine());
            if(response == 1)
            {
                myTrainer.SetActive(true);
            }
            else if(response == 2)
            {
                myTrainer.SetActive(false);
            }

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();

            System.Console.WriteLine($"Trainer {myTrainer.GetTrainerName()} has been created!");
        }

        private void Save()
        {
            StreamWriter outfile = new StreamWriter("Trainers.txt");

            for(int i = 0; i < Trainer.GetCount();i++)
            {
                outfile.WriteLine(trainers[i].ToFile());
            }

            outfile.Close();
        }

        public int Find(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount();i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateTrainer()
        {
            System.Console.WriteLine("What is the name of the Trainer you are trying to update?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Enter the trainer ID:");
                trainers[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Enter the trainer's name:");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Enter the trainer's address:");
                trainers[foundIndex].SetTrainerAddress(Console.ReadLine());
                System.Console.WriteLine("Enter the trainer's email:");
                trainers[foundIndex].SetEmail(Console.ReadLine());
                System.Console.WriteLine("Is this trainer currently active?\n1.Yes 2.No");
                int response = int.Parse(Console.ReadLine());
                if(response == 1)
                {
                    trainers[foundIndex].SetActive(true);
                }
                else if(response == 2)
                {
                    trainers[foundIndex].SetActive(false);
                }

                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer not found");
            }
        }

        public void DeleteTrainer()
        {
            System.Console.WriteLine("What is the name of the trainer you are trying to delete?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine($"Deleting this trainer will deactivate their account until the trainer reactivates...\n Are you sure you want to delete {trainers[foundIndex].GetTrainerName()}?");
                System.Console.WriteLine("1:Yes 2:No");
                int response = int.Parse(Console.ReadLine());

                if(response == 1)
                {
                    trainers[foundIndex].SetActive(false);
                    System.Console.WriteLine("Trainer has now been deactivated! You can no longer book with this trainer until they reactivate their account.");
                }
                else if(response == 2)
                {
                    System.Console.WriteLine("You have choose not to delete the trainer. Trainer is currently still active.");
                }

                Save();

                
            }
            else
            {
                System.Console.WriteLine("Trainer not found!");
            }
        }

        public void PrintAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount();i++)
            {
                System.Console.WriteLine(trainers[i].GetTrainerName());
            }

        }

        public void GetAllTrainersFromFile()
        {
            StreamReader infile = new StreamReader("Trainers.txt");

            Trainer.SetCount(0);
            string line = infile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]),temp[1],temp[2],temp[3],bool.Parse(temp[4]));
                Trainer.IncCount();
                line = infile.ReadLine();
            }
            infile.Close();
        }
    }
}
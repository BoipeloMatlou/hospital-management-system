using static System.Console;

namespace HospitalManagementSystem
{
    class Patient
    {
        public string name,
                      condition;
        public int age;
    }

    class Hospital
    {
        private const int wardAmount = 3;
        private const int wardCapacity = 4;

        private Patient[,] patients = new Patient[wardAmount,wardCapacity];

        public bool AddPatients(int wardNumber, Patient patient)
        {
            if (wardNumber<0||wardNumber>=wardAmount)
            {
                WriteLine("Invalid ward number! Please try again.");
                return false;
            }

            for (int i = 0; i < wardCapacity; i++)
            {
                if (patients[wardNumber,i] == null)
                {
                    patients[wardNumber, i] = patient;

                    WriteLine("Patient {0} added successfully to Ward {1}!",
                        patient.name,wardNumber);
                    return true;
                }

            }
            
            WriteLine("Ward capacity Reached!");
            return false;
        }


        public void DisplayPatients()
        {
            
                for (int i = 0; i < wardAmount; i++)
                {
                    WriteLine("\nList of Patients:\nWard {0}: ", i);
                    bool wardEmpty = true;

                    for (int j = 0; j < wardCapacity; j++)
                    {
                        if (patients[i, j] != null)
                        {
                            WriteLine("Name: {0}, Age: {1}, Condition: {2}",
                                patients[i, j].name, patients[i, j].age, patients[i, j].condition);

                            wardEmpty=false;
                        }
                    }

                    if (wardEmpty)
                    {
                        WriteLine("No Patients in this ward.");
                    }
                }
            
        }


    }

    class Program
    {
        static void Main()
        {
            int wardNumber,
                choice;
            bool run = true;
            Hospital hospital = new Hospital();



            do
            {
                WriteLine("Hospital Management System \n" +
                          "1. Add a Patient\n" +
                          "2. Display Patients\n" +
                          "3. Exit");

                Write("Enter your choice: ");
                choice = Convert.ToInt32(ReadLine());

                switch (choice)
                {
                    case 1:

                        Patient patient = new Patient();

                        Write("Enter the patient's name: ");
                        patient.name = ReadLine();

                        Write("Enter the patient's age: ");
                        patient.age = Convert.ToInt32(ReadLine());

                        Write("Enter the patient's condition: ");
                        patient.condition = ReadLine();

                        bool added = false;
                        do
                        {
                            Write("Enter the ward number: ");
                            wardNumber = Convert.ToInt32(ReadLine());

                            added = hospital.AddPatients(wardNumber, patient);

                            if (!added)
                            {
                                WriteLine("Please enter ward number from 0 to 2.");
                            }

                        } while (!added);   

                        break;

                    case 2:

                        hospital.DisplayPatients();
                        break;

                    case 3:

                        run = false;
                        WriteLine("Exiting program...");
                        break;

                    default:

                        WriteLine("Invalid input! Try again.");
                        break;
                }


            } while (run == true);
        }
    }
}
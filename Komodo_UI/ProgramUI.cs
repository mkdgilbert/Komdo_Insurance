using KomodoTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_UI
{
    class ProgramUI
    {
        private DevRepo _devRepo = new DevRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedContentList(); //Pulls up list of employee
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display the Options
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Employee \n" +
                    "2. View All Employees \n" +
                    "3. View Employee by ID\n" +
                    "4. Update Existing Employee\n" +
                    "5. Delete Existing Employee\n" +
                    "6. Create New Team\n" +
                    "7. View All Teams\n" +
                    "8. View Team by Name\n" +
                    "9. Update Existing Team\n" +
                    "10. Delete Existing Team\n" +
                    "20. Exit");
                //Get input
                string input = Console.ReadLine();

                //Evaluate input
                switch (input)
                {
                    case "1":
                        CreateNewEmployee();
                        break;
                    case "2":
                        DisplayAllEmployees();
                        break;
                    case "3":
                        DisplayEmployeeById();
                        break;
                    case "4":
                        UpdateExistingEmployee();
                        break;
                    case "5":
                        DeleteExistingEmployee();
                        break;
                    case "6":
                        CreateNewTeam();
                        break;
                    case "7":
                        DisplayAllEmployees();
                        break;
                    case "8":
                        DisplayEmployeeById();
                        break;
                    case "9":
                        UpdateExistingEmployee();
                        break;
                    case "10":
                        DeleteExistingEmployee();
                        break;
                    case "20":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue..");
                //before the code runs it prompts the user
                Console.ReadKey();
                Console.Clear();
            }

            //
        }
        private void CreateNewEmployee()
        {
            Console.Clear();

            DevPOCO newEmployee = new DevPOCO();

            //Developer ID
            Console.WriteLine("Enter the employee ID: ");
            string idAsString = Console.ReadLine();
            newEmployee.DeveloperID = int.Parse(idAsString);

            //Firstname
            Console.WriteLine("Enter the employee's First Name: ");
            newEmployee.FirstName = Console.ReadLine();

            //Lastname
            Console.WriteLine("Enter the employee's Last Name: ");
            newEmployee.LastName = Console.ReadLine();

            //pluralsight
            Console.WriteLine("Does the employee have a PluralSight account? (y/n): ");
            string pluralsight = Console.ReadLine().ToLower();

            if (pluralsight == "y")
            {
                newEmployee.PluralSightAccount = true;
            }
            else
            {
                newEmployee.PluralSightAccount = false;
            }

            _devRepo.AddToDevelopersList(newEmployee);
        }

        private void DisplayAllEmployees()
        {
            Console.Clear();

            List<DevPOCO> listOfDevs = _devRepo.GetDevelopers();
            foreach (DevPOCO devPOCO in listOfDevs)
            {
                Console.WriteLine($"Developer ID: {devPOCO.DeveloperID}\n" +
                    $" First Name: {devPOCO.FirstName}\n" +
                    $" Last name: {devPOCO.LastName}\n" +
                    $"PluralSight Account: {devPOCO.PluralSightAccount}");
            }
        }

        private void DisplayEmployeeById()
        {
            Console.Clear();
            //Prompt
            Console.WriteLine("Please enter the employee ID: ");
            //Get input
            string devId = Console.ReadLine();
            //find by ID
            DevPOCO devPoco = _devRepo.GetDeveloperByID(devId);
            //display if null
            if (devPoco != null)
            {
                Console.WriteLine($"Developer ID: {devPoco.DeveloperID}\n" +
                    $" First Name: {devPoco.FirstName}\n" +
                    $" Last name: {devPoco.LastName}\n" +
                    $"PluralSight Account: {devPoco.PluralSightAccount}");
            }
            else
            {
                Console.WriteLine("Can find employee by that ID.");
            }


        }

        private void UpdateExistingEmployee()
        {
            Console.Clear();
            //Display
            DisplayAllEmployees();

            //input
            Console.WriteLine("Please enter the employee ID to be updated: ");

            //get employee
            string oldInfo = Console.ReadLine();

            //build new object
            DevPOCO newEmployee = new DevPOCO();

            //Developer ID
            Console.WriteLine("Enter the employee ID: ");
            string idAsString = Console.ReadLine();
            newEmployee.DeveloperID = int.Parse(idAsString);

            //Firstname
            Console.WriteLine("Enter the employee's First Name: ");
            newEmployee.FirstName = Console.ReadLine();

            //Lastname
            Console.WriteLine("Enter the employee's Last Name: ");
            newEmployee.LastName = Console.ReadLine();

            //pluralsight
            Console.WriteLine("Does the employee have a PluralSight account? (y/n): ");
            string pluralsight = Console.ReadLine().ToLower();

            if (pluralsight == "y")
            {
                newEmployee.PluralSightAccount = true;
            }
            else
            {
                newEmployee.PluralSightAccount = false;
            }

            //Veriry
            bool wasUpdated = _devRepo.UpdateExistingDevList(oldInfo, newEmployee);

            if (wasUpdated)
            {
                Console.WriteLine("Employee was successfully updated.");
            }
            else
            {
                Console.WriteLine("Employee could not be updated.");
            }
        }

        private void DeleteExistingEmployee()
        {
            //display
            DisplayAllEmployees();
            //input
            Console.WriteLine("\nPlease enter a employee ID to remove: ");
            string input = Console.ReadLine();
            //delete
            bool wasDeleted = _devRepo.RemoveDeveloperFromList(int.Parse(input));
            if (wasDeleted)
            {
                Console.WriteLine("The employee was deleted");
            }
            else
            {
                Console.WriteLine("Employee could not be deleted");
            }

        }

        private void CreateNewTeam()
        {
            Console.Clear();

            DevTeamPOCO devTeam = new DevTeamPOCO();

            //Team Name
            Console.WriteLine("Please enter the Team Name: ");
            devTeam.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Please enter the Team ID: ");
            string stringAsID = Console.ReadLine();
            devTeam.TeamID = int.Parse(stringAsID);
        }

        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeamPOCO> listOfTeams = _devTeamRepo.GetDevTeams();

            foreach (DevTeamPOCO devTeam in listOfTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Team ID: {devTeam.TeamID}");
            }
        }


        private void DisplayTeamByName()
        {
            Console.Clear();

            Console.WriteLine("Please enter a Team Name: ");
            string teamName = Console.ReadLine();
            DevTeamPOCO devTeam = _devTeamRepo.GetDevTeamByName(teamName);

            if (devTeam != null)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Team ID: {devTeam.TeamID}");
            }
            else
            {
                Console.WriteLine("Sorry, Could not find a Team by that Name.");
            }

        }

        private void UpdateExistingTeam()
        {
            Console.Clear();

            DisplayAllTeams();

            Console.WriteLine("Please enter the Team Name to be updated: ");

            string oldInfo = Console.ReadLine();

            DevTeamPOCO devTeam = new DevTeamPOCO();
            DevPOCO developers = new DevPOCO();

            //Team Name
            Console.WriteLine("Please enter the Team Name: ");
            devTeam.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Please enter the Team ID: ");
            string stringAsID = Console.ReadLine();
            devTeam.TeamID = int.Parse(stringAsID);

            bool wasUpdated = _devTeamRepo.UpdateExistingDevTeam(oldInfo, devTeam);

            if (wasUpdated)
            {
                Console.WriteLine("Team information was updated successfully");
            }
            else
            {
                Console.WriteLine("Team was not updated successfully");
            }
        }

        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("Please enter a Team ID to be deleted");

            string input = Console.ReadLine();
            bool wasDeleted = _devTeamRepo.RemoveDevTeamByname(input);

            if (wasDeleted)
            {
                Console.WriteLine("Employee has been removed");
            }
            else
            {
                Console.WriteLine("Employee could not be removed");
            }
        }

        // See Method
        private void SeedContentList()
        {
            DevPOCO mikeGilbert = new DevPOCO("Mike", "Gilbert", 1234, true);
            DevPOCO patrickMahomes = new DevPOCO("Patrick", "Mahomes", 1235, false);
            DevPOCO allenIverson = new DevPOCO("Allen", "Iverson", 1236, false);
            DevPOCO michaelJohnson = new DevPOCO("Michael", "Johsnon", 1237, true);
            DevPOCO rogerFederer = new DevPOCO("Roger", "Federer", 1238, true);
            DevTeamPOCO teamOne = new DevTeamPOCO("Team One", 10);
            DevTeamPOCO teamTwo = new DevTeamPOCO("Team Two", 12);
            DevTeamPOCO teamThree = new DevTeamPOCO("Team Three", 13);
            DevTeamPOCO teamFour = new DevTeamPOCO("Team Four", 14);


            _devRepo.AddToDevelopersList(mikeGilbert);
            _devRepo.AddToDevelopersList(patrickMahomes);
            _devRepo.AddToDevelopersList(allenIverson);
            _devRepo.AddToDevelopersList(michaelJohnson);
            _devRepo.AddToDevelopersList(rogerFederer);
            _devTeamRepo.AddToDevTeamRepo(teamOne);
            _devTeamRepo.AddToDevTeamRepo(teamTwo);
            _devTeamRepo.AddToDevTeamRepo(teamThree);
            _devTeamRepo.AddToDevTeamRepo(teamFour);
        }
    }
}

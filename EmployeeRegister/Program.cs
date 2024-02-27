namespace EmployeeRegister
{
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            bool isRunning = true;

            while (isRunning)
            {
                bool correctInput = false;

                while (!correctInput)
                {
                    // Print menu for adding a new employee or all listing employees
                    Console.Clear();
                    Console.WriteLine("Employee register");
                    Console.WriteLine("1. Add new employee");
                    Console.WriteLine("2. List all employees");
                    Console.WriteLine("3. Exit");

                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.D1)
                        AddNewEmployee();
                    else if (userInput.Key == ConsoleKey.D2)
                        ListAllEmployees();
                    else if (userInput.Key == ConsoleKey.D3)
                    {
                        isRunning = false;
                        correctInput = true;
                    }
                    else
                        Console.WriteLine("\nError: Can only accept the input '1', '2' or '3'. Please try again.");
                }
            }
        }

        static void AddNewEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add new employee");

            Employee employeeToBeAdded = new Employee();
            string userInput = "";
            decimal result = 0.0M;

            Console.Write("\nEnter first name: ");
            userInput = Console.ReadLine();
            employeeToBeAdded.FirstName = userInput;

            Console.Write("\nEnter last name: ");
            userInput = Console.ReadLine();
            employeeToBeAdded.LastName = userInput;

            bool correctInput = false;
            while (!correctInput)
            {
                Console.Write("\nEnter wage: ");
                userInput = Console.ReadLine();
                if (Decimal.TryParse(userInput, out result))
                {
                    employeeToBeAdded.Wage = result;
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("\nFailed to parse user input. Please try again.");
                }
            }

            employeeToBeAdded.Id = employees.Count + 1;
            employees.Add(employeeToBeAdded);

            Console.WriteLine("\nEmployee successfully added!");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void ListAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("All employees:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine("\nFull name: " + employee.FullName());
                Console.WriteLine("Wage: " + employee.Wage.ToString("c"));
            }
            Console.WriteLine("\nPress any key to go back.");
            Console.ReadKey();
        }
    }
}

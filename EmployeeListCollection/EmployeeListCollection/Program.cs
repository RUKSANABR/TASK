using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public void Print()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>(); //stores the added emp in list

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEmployee System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        UpdateEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        DisplayEmployees();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            employees.Add(new Employee { Id = id, Name = name, Department = dept }); //Creates Employee object and add to the employees list.
            Console.WriteLine("Employee added successfully.");
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter ID of employee to update: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                Console.Write("Enter new Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter new Department: ");
                emp.Department = Console.ReadLine();

                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter ID of employee to delete: ");
            int id = int.Parse(Console.ReadLine());

            int removed = employees.RemoveAll(e => e.Id == id);
            Console.WriteLine(removed > 0 ? "Employee deleted." : "Employee not found.");
        }

        static void DisplayEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees");
                return;
            }

            Console.WriteLine("\nEmployee List");
            var sortedEmployees = employees.OrderBy(e => e.Name).ToList();
            foreach (var emp in sortedEmployees)
            {
                emp.Print();
            }
        }
    }
}

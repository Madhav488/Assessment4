using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{

    static string connectionString = @"Server=LAPTOP-RV5DRVU1;Database=assessment4q1;Integrated Security=true;";

    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            while (true)
            {
                Console.WriteLine("Enter Employee Type (Payroll/Contract) or 'exit' to finish:");
                string type = Console.ReadLine().Trim();

                if (type.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (type.Equals("Payroll", StringComparison.OrdinalIgnoreCase))
                {
                    PayrollEmployee p = new PayrollEmployee();
                    Console.Write("Name: "); p.Name = Console.ReadLine();
                    Console.Write("Reporting Manager: "); p.ReportingManager = Console.ReadLine();
                    Console.Write("Joining Date (yyyy-mm-dd): "); p.JoiningDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Experience Years: "); p.ExperienceYears = int.Parse(Console.ReadLine());
                    Console.Write("Basic Salary: "); p.BasicSalary = decimal.Parse(Console.ReadLine());

                    p.CalculateSalary();
                    p.SaveToDatabase(conn);
                    employees.Add(p);
                }
                else if (type.Equals("Contract", StringComparison.OrdinalIgnoreCase))
                {
                    ContractEmployee c = new ContractEmployee();
                    Console.Write("Name: "); c.Name = Console.ReadLine();
                    Console.Write("Reporting Manager: "); c.ReportingManager = Console.ReadLine();
                    Console.Write("Contract Date (yyyy-mm-dd): "); c.ContractDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Duration Months: "); c.DurationMonths = int.Parse(Console.ReadLine());
                    Console.Write("Charges: "); c.Charges = decimal.Parse(Console.ReadLine());

                    c.SaveToDatabase(conn);
                    employees.Add(c);
                }
                else
                {
                    Console.WriteLine("Invalid type, try again.");
                }
            }
        }

        Console.WriteLine($"Total number of employees added: {employees.Count}");
    }
}


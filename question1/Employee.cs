using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public abstract class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string ReportingManager { get; set; }
    public string EmployeeType { get; protected set; }

    public abstract void SaveToDatabase(SqlConnection conn);
}

public class PayrollEmployee : Employee
{
    public DateTime JoiningDate { get; set; }
    public int ExperienceYears { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal DA { get; set; }
    public decimal HRA { get; set; }
    public decimal PF { get; set; }
    public decimal NetSalary { get; set; }

    public PayrollEmployee()
    {
        EmployeeType = "Payroll";
    }

    public void CalculateSalary()
    {
        if (ExperienceYears > 10)
        {
            DA = BasicSalary * 0.10m;
            HRA = BasicSalary * 0.085m;
            PF = 6200;
        }
        else if (ExperienceYears > 7)
        {
            DA = BasicSalary * 0.07m;
            HRA = BasicSalary * 0.065m;
            PF = 4100;
        }
        else if (ExperienceYears > 5)
        {
            DA = BasicSalary * 0.041m;
            HRA = BasicSalary * 0.038m;
            PF = 1800;
        }
        else
        {
            DA = BasicSalary * 0.019m;
            HRA = BasicSalary * 0.020m;
            PF = 1200;
        }
        NetSalary = BasicSalary + DA + HRA - PF;
    }

    public override void SaveToDatabase(SqlConnection conn)
    {
        string query = @"INSERT INTO Employees
        (Name, ReportingManager, EmployeeType, JoiningDate, ExperienceYears, BasicSalary, DA, HRA, PF, NetSalary)
        VALUES (@Name, @ReportingManager, @EmployeeType, @JoiningDate, @ExperienceYears, @BasicSalary, @DA, @HRA, @PF, @NetSalary)";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@ReportingManager", ReportingManager);
            cmd.Parameters.AddWithValue("@EmployeeType", EmployeeType);
            cmd.Parameters.AddWithValue("@JoiningDate", JoiningDate);
            cmd.Parameters.AddWithValue("@ExperienceYears", ExperienceYears);
            cmd.Parameters.AddWithValue("@BasicSalary", BasicSalary);
            cmd.Parameters.AddWithValue("@DA", DA);
            cmd.Parameters.AddWithValue("@HRA", HRA);
            cmd.Parameters.AddWithValue("@PF", PF);
            cmd.Parameters.AddWithValue("@NetSalary", NetSalary);
            cmd.ExecuteNonQuery();
        }
    }
}

public class ContractEmployee : Employee
{
    public DateTime ContractDate { get; set; }
    public int DurationMonths { get; set; }
    public decimal Charges { get; set; }

    public ContractEmployee()
    {
        EmployeeType = "Contract";
    }

    public override void SaveToDatabase(SqlConnection conn)
    {
        string query = @"INSERT INTO Employees
        (Name, ReportingManager, EmployeeType, ContractDate, DurationMonths, Charges)
        VALUES (@Name, @ReportingManager, @EmployeeType, @ContractDate, @DurationMonths, @Charges)";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@ReportingManager", ReportingManager);
            cmd.Parameters.AddWithValue("@EmployeeType", EmployeeType);
            cmd.Parameters.AddWithValue("@ContractDate", ContractDate);
            cmd.Parameters.AddWithValue("@DurationMonths", DurationMonths);
            cmd.Parameters.AddWithValue("@Charges", Charges);
            cmd.ExecuteNonQuery();
        }
    }
}

namespace BasicPayrollCalculator;

class Program
{
    static void Main(string[] args)
    {
        // Variable declaration outside the try block so they are available throughout the Main method
        int hoursWorked = 0;
        decimal hourlyRate = 0;

        // PHASE 1: Functionality planning

        // PHASE 3: Exception handling
        try
        {
            // 1. Ask for hours worked
            Console.WriteLine("Enter the number of hours worked: ");
            hoursWorked = Convert.ToInt32(Console.ReadLine());

            // 2. Ask for hourly rate
            Console.WriteLine("Enter the hourly rate: ");
            hourlyRate = Convert.ToDecimal(Console.ReadLine());

            if (hoursWorked <= 0 || hourlyRate <= 0)
            {
                Console.WriteLine("Hours worked and hourly rate must be positive numbers.");
                PauseConsole();
                return;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter numbers only.");
            PauseConsole();
            return;
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number entered is too large.");
            PauseConsole();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            PauseConsole();
            return;
        }

        // 3. Calculate gross salary
        decimal grossSalary = hoursWorked * hourlyRate;

        // 4. Display gross salary
        Console.WriteLine($"\nGross salary: {grossSalary:C}");

        // 5. Calculate and display total deductions
        decimal totalDeductions = CalculateDeductions(grossSalary);
        Console.WriteLine($"\nTotal deductions: {totalDeductions:C}");

        // 6. Calculate and display net salary
        decimal netSalary = grossSalary - totalDeductions;
        Console.WriteLine($"\nNet salary: {netSalary:C}");

        // 7. Pause console
        PauseConsole();
    }

    // PHASE 2:
    // Objective: Implement the calculation of deductions on gross salary

    static decimal CalculateDeductions(decimal grossSalary)
    {
        const decimal socialSecurityRate = 0.04m;
        const decimal taxRate = 0.10m;
        const decimal taxThreshold = 2000000m;

        decimal socialSecurityDeduction = grossSalary * socialSecurityRate;

        decimal taxDeduction = 0;
        if (grossSalary > taxThreshold)
        {
            taxDeduction = grossSalary * taxRate;
        }

        decimal totalDeductions = socialSecurityDeduction + taxDeduction;

        return totalDeductions;
    }

    // Pause the console
    static void PauseConsole()
    {
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadLine();
    }
}

using System;

class Rent_or_Buy_Property_Application
{
    static void Main()
    {
        // Let the user enter their monthly income.
        Console.Write(" ");
        Console.Write("Please enter your gross monthly income (before deductions): ");
        // I used double to convert the user's input from a string to a decimal value. 
        double grossMonthlyIncome = double.Parse(Console.ReadLine());

        // Let the user enter their monthly tax deductions.
        Console.Write(" ");
        Console.Write("Please enter your estimated monthly tax deducted: ");
        double monthlyTax = double.Parse(Console.ReadLine());

        // Let the user enter their monthly expenditures.
        Console.Write(" ");
        Console.Write("Please enter your estimated monthly expenditures: ");
        double monthlyExpenditures = double.Parse(Console.ReadLine());

        // Ask the user if they want to rent or buy a property.
        Console.Write("\n");
        Console.Write("Do you want to rent or buy a property? Enter 'rent' or 'buy': ");
        string rentOrBuy = Console.ReadLine();
        Console.Write("\n");

        // create the variable to calculate the available money after all deductions.
        double availableMonthlyMoney;

        if (rentOrBuy == "rent")
        {
            // Let the user enter the monthly rental amount.
            Console.Write("Please enter the monthly rental amount: ");
            double monthlyRentalAmount = double.Parse(Console.ReadLine());

            // Calculate the available money left after deductions.
            availableMonthlyMoney = grossMonthlyIncome - monthlyTax - monthlyExpenditures - monthlyRentalAmount;

            // display the monthly money available.
            Console.Write("\n");
            Console.Write("*************************************************************************");
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine($"Your available monthly money after all specified deductions is: {availableMonthlyMoney}");
            Console.Write("\n");
            Console.Write("*************************************************************************");
        }
        else if (rentOrBuy == "buy")
        {
            // Let the userr enter the purchase price.
            Console.Write("Please enter the purchase price: ");
            double purchasePrice = double.Parse(Console.ReadLine());

            // Let the user enter the deposit amount.
            Console.Write("Please enter the total deposit: ");
            double totalDeposit = double.Parse(Console.ReadLine());

            // Let the user enter the interest rate.
            Console.Write("Please enter the interest rate: ");
            double interestRate = double.Parse(Console.ReadLine());

            // Let the user enter the amount of months they have to repay.
            Console.Write("\n");
            Console.Write("Please enter the number of months to repay: ");
            int monthsToRepay = int.Parse(Console.ReadLine());


            // Calculate the monthly repayment.
            double monthlyRepayment = CalculateMonthlyRepayment(purchasePrice, totalDeposit, interestRate, monthsToRepay);

            // If the users repayment is more than 1/3 of their gross monthly income, a message will appear to inform them of the unsuccessful loan.
            if (monthlyRepayment > grossMonthlyIncome / 3)
            {
                Console.Write("\n");
                Console.WriteLine("Unfortunately, approval of the home loan is unlikely because " + "\n" +
                    "the monthly repayment amount is more than a third of your gross monthly income.");
                Console.Write("\n");
            }

            // Let the user know that they cam afford the current price of the property.
            else
            {
                Console.Write("\n");
                Console.Write("Congratulations! You can afford to buy this house.");
                Console.Write("\n");
            }


            // Calculate the available money left after deductions.
            availableMonthlyMoney = grossMonthlyIncome - monthlyTax - monthlyExpenditures - monthlyRepayment;

            Console.Write("\n");
            Console.Write("***************************************************************************************");
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine($"Your available monthly money after all specified deductions is: {availableMonthlyMoney}");
            Console.Write("\n");
            Console.Write("***************************************************************************************");
        }

        // If the userr doesn't enter the correct option, close the program.
        else
        {
            Console.Write("\n");
            Console.Write("**********************************************************");
            Console.Write("\n");
            Console.WriteLine("Your choice is invalid. Please choose a better option.");
            Console.Write("\n");
            Console.Write("**********************************************************");
            Console.Write("\n");
            return;
        }

    }

    // Calculate the monthly repayment and the monthly interest rate. 
    static double CalculateMonthlyRepayment(double purchasePrice, double totalDeposit, double interestRate, int monthsToRepay)
    {
        double principal = purchasePrice - totalDeposit;
        double monthlyInterestRate = interestRate / 12;
        double monthlyRepayment = (principal * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -monthsToRepay));
        return monthlyRepayment;
    }
}

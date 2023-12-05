using System.IO;
using System.Text;
namespace ShoppingCalculator;

class Program
{
    static void Main(string[] args)
    {
        bool status = true;
        while (status)
        {

        
        // This is a simple Shopping calculator That saves in a Text file
        // First Three Operations is for me to get the user Data first and set a unique ID for the Programme.
        Guid Id = Guid.NewGuid();

        Console.WriteLine("Input The Name of the Item:");
        string? itemName = Console.ReadLine();

        Console.WriteLine("Input the Quantity of the Item:");
        int itemQuantity = Convert.ToInt32 (Console.ReadLine());

        Console.WriteLine("Input the Unit Price of the Item:");
        double itemUnitPrice = Convert.ToDouble(Console.ReadLine());

        // Calculate the Total Cost
       double totalCost =  itemQuantity * itemUnitPrice ;

        //Next is to create a Logic That will help give discount for items

        double discountThreashold = 5000.0; 
        double discountPercentage = 0.1;
        if (totalCost > discountThreashold)
        {
            double discountAmount = totalCost * discountPercentage;
            totalCost -= discountAmount;
            Console.WriteLine($" Congratulation You are eligible for {discountPercentage *100}% Discount Saved {discountAmount:F2}");
        }
        //Display the Result
        Console.WriteLine($"The Total Cost of Item Id: {Id} with the {itemName}(s) and Quantity:{itemQuantity} with Unit Price : {itemUnitPrice:F2}, has the Total Cost of {totalCost:F2}");

        // using string builder to build the string
        StringBuilder outputStringBuilder = new StringBuilder();
        outputStringBuilder.AppendLine("====================");
        outputStringBuilder.AppendLine($"Item Id is:  { Id }");
        outputStringBuilder.AppendLine($"Item Name is: {itemName}");
        outputStringBuilder.AppendLine($"Item Quantity: {itemQuantity}");
        outputStringBuilder.AppendLine($"Item Unit Price: {itemUnitPrice}");
        outputStringBuilder.AppendLine($"Item Total Cost: {totalCost}");

        SaveToTextFile(outputStringBuilder.ToString());

        static void SaveToTextFile(string data)
        {
             string path = @"C:\PersonalProjects\ShoppingCalculator\ShpoppingList.txt";
             using (StreamWriter writer = File.AppendText(path))
             {
                writer.WriteLine(data);
             }
            Console.WriteLine("Item Saved Successfully to the Text file");
        }

        
        
     


    }
}

}

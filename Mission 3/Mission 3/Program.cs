
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using Mission_3;

// creating a new list to hold FoodItem objects
List<FoodItem> foodItems = new List<FoodItem>();

//defining the integer that will be used for input throughout the program
int input;


// options to be displayed for the user to use. 
string[] options = new string[] { "1: Add Food Item", "2: Delete Food Items", "3: Display a list of Current Food Items", "4: Exit the Program" };

Console.WriteLine("Welcome to the food bank management system! What would you like to do?");

//displaying all the options in the array. 
foreach (string option in options)
{
    Console.WriteLine(option);
}



while (true)
{
    string userInput = Console.ReadLine();

    if (int.TryParse(userInput, out input))
    {
        // Check if the input is valid for your specific use case
        if (input <= 4)
        {
            break; // Exit the loop if the input is valid
        }
        else
        {
            Console.WriteLine("The number must be less than 4. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
    }
}


while (input < 4)
{
    switch (input)
    {
        case 1:
            // declaring variables to be used in the foot Iem
            string name = "";
            string category = "";
            string quantity = "";
            string date = "";

            Console.WriteLine("What is the name of the food item?:");
            name = Console.ReadLine();
            Console.WriteLine("What is the category of the food item?:");
            category = Console.ReadLine();
            Console.WriteLine("What is the quantity of this item?:");
            quantity = Console.ReadLine();
            Console.WriteLine("What is the expiration date? i.e. 07/25/25");
            date = Console.ReadLine();
            FoodItem item1 = new FoodItem(name, category, quantity, date);
            foodItems.Add(item1);
            Console.WriteLine("Item Added!");
            break;


        case 2:
            string foodDelete = "";
            Console.WriteLine("What is the name of the food item you would like to delete:");
            foodDelete = Console.ReadLine();
            bool itemFound = false;

            for (int count = 0; count < foodItems.Count; count++)
            {
                if (foodItems[count].Name == foodDelete)
                {
                    foodItems.RemoveAt(count);
                    Console.WriteLine($"{foodDelete} was removed from inventory");
                    itemFound = true;
                    break; // Exit the loop after removing the item
                }
            }

            if (!itemFound)
            {
                Console.WriteLine("No such item was found.");
            }

            break;

        case 3:
            int i = 1;
            if (foodItems.Count > 0)
            {
                Console.WriteLine("Printing the current food items:");
                foreach (FoodItem item in foodItems)
                {
                    Console.WriteLine($"{i}: {item.Name}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("There are currently no food items.");
            }
            break;
    }

    Console.WriteLine();
    Console.WriteLine("What would you like to do?:");
    foreach (string option in options)
    {
        Console.WriteLine(option);
    }

    string userInput = Console.ReadLine();

    input = int.Parse(userInput);

}

Console.WriteLine("Exiting the program.");

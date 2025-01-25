using Assignment3;

//Program class to fun the apps!
class Program
{
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintInventory();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
                    break;
            }
        }
    }

    static void AddFoodItem()
    {
        Console.Write("Enter the name of the food item: ");
        string name = Console.ReadLine();

        Console.Write("Enter the category of the food item (e.g., Canned Goods, Dairy, Produce): ");
        string category = Console.ReadLine();

        Console.Write("Enter the quantity of the food item: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Please enter a non-negative integer.");
            return;
        }

        Console.Write("Enter the expiration date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
        {
            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
            return;
        }

        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        inventory.Add(newItem);
        Console.WriteLine("Food item added successfully.");
    }

    static void DeleteFoodItem()
    {
        Console.Write("Enter the name of the food item to delete: ");
        string name = Console.ReadLine();

        FoodItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            Console.WriteLine("Food item deleted successfully.");
        }
        else
        {
            Console.WriteLine("Food item not found in the inventory.");
        }
    }

    static void PrintInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
            return;
        }

        Console.WriteLine("\nCurrent Food Items in Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
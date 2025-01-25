
namespace Assignment3;

// Food Items Class represent a list of food
class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity >= 0 ? quantity : throw new ArgumentException("Quantity cannot be negative.");
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"{Name} | {Category} | Quantity: {Quantity} | Expiration Date: {ExpirationDate.ToShortDateString()}";
    }
}
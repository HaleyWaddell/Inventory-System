using System;
using System.IO;
using System.Collections.Generic;



//Haley Waddell

// Inventory class
class Inventory
{

    // Instance variable: 'Name' stores class name
    public String Name;
    // Variable: 'quantity' stores quantity of each one of the 5 items
    public int[] quantity;

    // Constructor will create Inventory object
    public Inventory(int[] items, String Name)
    {
        // Sets name of class
        this.Name = Name;

        // Sets quantity of each item
        this.quantity = new int[5];
        for (int i = 0; i < 5; i++)
        {
            this.quantity[i] = items[i];
        }
    }
    // Prints the status of all warehouses inventory
    public void Print()
    {
        Console.WriteLine(this.Name);
        Console.Write(this.quantity[0] + " " + this.quantity[1] + " " + this.quantity[2] + " " + this.quantity[3] + " " + this.quantity[4] + "\n\n");
    }
}




// Main driver 
class Warehouses
{
    // Converts String array to Integer array.
    private static void ParseStringToInteger(String[] strlist, int[] Item)
    {
        Item[0] = Convert.ToInt32(strlist[0]);
        Item[1] = Convert.ToInt32(strlist[1]);
        Item[2] = Convert.ToInt32(strlist[2]);
        Item[3] = Convert.ToInt32(strlist[3]);
        Item[4] = Convert.ToInt32(strlist[4]);
    }
    // minInventory() function that will give the inventory of minimum quantity 
    private static Inventory minInventory(Inventory one, Inventory two, Inventory three, Inventory four, Inventory five, Inventory six, int index)
    {
        // Finding minimum quantity of the item in all classes
        int min = Math.Min(one.quantity[index], Math.Min(two.quantity[index], Math.Min(three.quantity[index], Math.Min(four.quantity[index], Math.Min(five.quantity[index], six.quantity[index])))));

        // If cases that match the minimum quantity with the current one in each inventory
        // Return the inventory that matches with minimum quantity
        if (min == one.quantity[index])
        {
            return one;
        }
        else if (min == two.quantity[index])
        {
            return two;
        }
        else if (min == three.quantity[index])
        {
            return three;
        }
        else if (min == four.quantity[index])
        {
            return four;
        }
        else if (min == five.quantity[index])
        {
            return five;
        }
        return six;
    }
    // maxInventory() function that will return the inventory with maximum quantity 
    private static Inventory maxInventory(Inventory one, Inventory two, Inventory three, Inventory four, Inventory five, Inventory six, int index)
    {
        // Finding maximum quantity of items in all classes
        int max = Math.Max(one.quantity[index], Math.Max(two.quantity[index], Math.Max(three.quantity[index], Math.Max(four.quantity[index], Math.Max(five.quantity[index], six.quantity[index])))));

        // If cases that match the maximum quantity with the current one in each inventory
        // Return inventory that matches with maximum quantity
        if (max == one.quantity[index])
        {
            return one;
        }
        else if (max == two.quantity[index])
        {
            return two;
        }
        else if (max == three.quantity[index])
        {
            return three;
        }
        else if (max == four.quantity[index])
        {
            return four;
        }
        else if (max == five.quantity[index])
        {
            return five;
        }
        return six;
    }


    // Main Class
    public static void Main(String[] args)
    {
        // Dictionary for Inventory Items array - defines setPartNumber between part number and its index 
        Dictionary<String, int> setPartNumber = new Dictionary<String, int>();
        setPartNumber.Add("102", 0);
        setPartNumber.Add("215", 1);
        setPartNumber.Add("410", 2);
        setPartNumber.Add("525", 3);
        setPartNumber.Add("711", 4);
        

        // Stringing file name
        String inventoryFile = @"C:\\Users\\haleywaddell\\Projects\\Project2\\Project2\\bin\\Debug\\net6.0\\Inventory.txt";
        String inventory;

        // Creating instances of Inventory
        Inventory Atlanta, Baltimore, Chicago, Denver, Ely, Fargo, warehouse;

        // Items array storing quantity for each item in each inventory
        int[] parts = new int[5];

            // Creating input stream for Inventory.txt file.
            using (StreamReader sr = new StreamReader("Inventory.txt"))
            {
                // Reading data for 'Atlanta'
                inventory = sr.ReadLine();
                String[] stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creates 'Atlanta' object
                Atlanta = new Inventory(parts, "Atlanta");

                // Reading data for 'Baltimore'
                inventory = sr.ReadLine();
                stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creating Object for 'Baltimore'.
                Baltimore = new Inventory(parts, "Baltimore");

                // Reading data for 'Chicago'
                inventory = sr.ReadLine();
                stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creating 'Chicago' object
                Chicago = new Inventory(parts, "Chicago");

                // Reading data for 'Denver'
                inventory = sr.ReadLine();
                stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creating 'Denver' object
                Denver = new Inventory(parts, "Denver");

                // Reading data for 'Ely'
                inventory = sr.ReadLine();
                stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creating 'Ely' object
                Ely = new Inventory(parts, "Ely");

                // Reading data for 'Fargo'
                inventory = sr.ReadLine();
                stringInventory = inventory.Split(", ");
                ParseStringToInteger(stringInventory, parts);
                // Creating 'Fargo' object
                Fargo = new Inventory(parts, "Fargo");
            }

        // Prints the before processing transactions Inventory status for each Warehouse using created objects 
        Console.WriteLine("**************************************************************************");
            Console.WriteLine("Status of each Inventory before Transactions: ");
            Atlanta.Print();
            Baltimore.Print();
            Chicago.Print();
            Denver.Print();
            Ely.Print();
            Fargo.Print();



         // Processing transactions and printing status of updated inventory
        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\nTransactions to be processed: ");

        // String file name 
        String transactionFile = @"C:\\Users\\haleywaddell\\Projects\\Project2\\Project2\\bin\\Debug\\net6.0\\Transactions.txt";
            using (StreamReader sr = new StreamReader("Transactions.txt"))

        {
                // Traverse transaction file line by line while it is not empty
                while ((inventory = sr.ReadLine()) != null)
                {
                    String[] stringTransaction = inventory.Split(", ");
                    // Switch-case's  for handling different transactions
                    // P OR S.
                    switch (stringTransaction[0])
                    {
                        case "P":
                            // If transaction is P for type purchasing
                            warehouse = minInventory(Atlanta, Baltimore, Chicago, Denver, Ely, Fargo, setPartNumber[stringTransaction[1]]);
                            warehouse.quantity[setPartNumber[stringTransaction[1]]] += Int32.Parse(stringTransaction[2]);
                            warehouse.Print();
                            break;
                        case "S":
                            // If transaction is S for type selling.
                            warehouse = maxInventory(Atlanta, Baltimore, Chicago, Denver, Ely, Fargo, setPartNumber[stringTransaction[1]]);
                            warehouse.quantity[setPartNumber[stringTransaction[1]]] -= Int32.Parse(stringTransaction[2]);
                            warehouse.Print();
                            break;
                        default:
                            Console.WriteLine("File contains unwanted data.");
                            break;
                    }
                }
            }
            // Prints Inventory's status after processing P OR S from transaction.txt
            Console.WriteLine("\n**************************************************************************");
            Console.WriteLine("Status of each Inventory after Transactions: ");
            Atlanta.Print();
            Baltimore.Print();
            Chicago.Print();
            Denver.Print();
            Ely.Print();
            Fargo.Print();
   
    }
   
}
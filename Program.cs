// See https://aka.ms/new-console-template for more information
List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 15.00M,
        City = "Nashville",
        ZIP = 37377,
        Sold = true,
    },
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 2,
        AskingPrice = 17.00M,
        City = "Chattanooga",
        ZIP = 37209,
        Sold = false,
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 19.00M,
        City = "Memphis",
        ZIP = 37212,
        Sold = true,
    },
    new Plant()
    {
        Species = "Fiddle Leaf Fig",
        LightNeeds = 4,
        AskingPrice = 21.00M,
        City = "Signal Mountain",
        ZIP = 37138,
        Sold = true,
    },
    new Plant()
    {
        Species = "ZZ Plant",
        LightNeeds = 5,
        AskingPrice = 23.00M,
        City = "Knoxville",
        ZIP = 37777,
        Sold = false,
    },
};

string greeting = @"
Welcome to ExtraVerts!
Your home for used houseplants!
";


void DisplayAllPlants()
{
    // Console.WriteLine("\nYou chose option 1\n");
    Console.WriteLine("Plants List:");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? $"was sold for {plants[i].AskingPrice} dollars" : $"is available for {plants[i].AskingPrice} dollars")}\n");
    }

}

void PostAPlant()
{
    // Console.WriteLine("\nYou chose option 2\n");
    Console.WriteLine("Please enter a species:\n");

    Plant newPlant = new Plant();

    Console.WriteLine("Enter a plant species:\n");
    newPlant.Species = Console.ReadLine();

    Console.WriteLine("Enter the plant's light needs (1 for low light, 5 for heavy light)\n");
    newPlant.LightNeeds = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter an asking price:\n");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter a city:\n");
    newPlant.City = Console.ReadLine();

    Console.WriteLine("Enter a ZIP:\n");
    newPlant.ZIP = int.Parse(Console.ReadLine());

    newPlant.Sold = false;

    plants.Add(newPlant);
}

void AdoptAPlant()
{
    Console.WriteLine("\nYou chose option 3\n");
}

void DeListAPlant()
{
    Console.WriteLine("\nYou chose option 4\n");
}

void ExitApp()
{
    Console.WriteLine("\nProgram Exited...\n");
}

void InvalidOption()
{
    Console.WriteLine("\nInvalid option...\n");
}

void Menu()
{
    Console.WriteLine(@"Main Menu:
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. De-List a plant
0. Exit

Please choose an option:");

    string choice = null;
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            DisplayAllPlants();
            Menu();
            break;
        case "2":
            Console.Clear();
            PostAPlant();
            Menu();
            break;
        case "3":
            Console.Clear();
            AdoptAPlant();
            Menu();
            break;
        case "4":
            Console.Clear();
            DeListAPlant();
            Menu();
            break;
        case "0":
            Console.Clear();
            ExitApp();
            break;
        default:
            Console.Clear();
            InvalidOption();
            Menu();
            break;
    }
}

void App()
{
    Console.WriteLine(greeting);
    Console.Clear();
    Menu();
}

App();

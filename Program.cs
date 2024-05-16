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

Random random = new Random();
int randomInteger = random.Next(1, plants.Count + 1);

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


    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species}");
        }
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        Console.WriteLine("\nPlease enter the plant number you wish to adopt:\n");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];

            if (chosenPlant.Sold == true)
            {
                Console.WriteLine("\nThis plant is not available...\n");
            }

            chosenPlant.Sold = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("\nPlease type only integers!\n");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("\nPlease choose an existing item only!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("\nDo better!\n");
        }
    }
}

void DeListAPlant()
{
    // Console.WriteLine("\nYou chose option 4\n");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    Console.WriteLine("\nPlease choose a plant to de-list:\n");
    try
    {
        int response = int.Parse(Console.ReadLine().Trim());

        plants.RemoveAt(response - 1);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("\nDo better!\n");
    }


}

void ExitApp()
{
    Console.WriteLine("\nProgram Exited...\n");
}

void InvalidOption()
{
    Console.WriteLine("\nInvalid option...\n");
}

void RandomPlant()
{
    Plant randomPlant = plants[randomInteger];

    Console.WriteLine($"\n{randomPlant.Species}, {randomPlant.City}, {randomPlant.LightNeeds}, {randomPlant.AskingPrice}\n");
}

void Menu()
{
    Console.WriteLine(@"Main Menu:
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. De-List a plant
5. View a RANDOM Plant
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
        case "5":
            Console.Clear();
            RandomPlant();
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

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
        AvailableUntil = new DateTime(2022,12,12)
    },
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 2,
        AskingPrice = 17.00M,
        City = "Chattanooga",
        ZIP = 37209,
        Sold = true,
        AvailableUntil = new DateTime(2023,12,12)
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 19.00M,
        City = "Memphis",
        ZIP = 37212,
        Sold = false,
        AvailableUntil = new DateTime(2023,12,12)
    },
    new Plant()
    {
        Species = "Fiddle Leaf Fig",
        LightNeeds = 4,
        AskingPrice = 21.00M,
        City = "Signal Mountain",
        ZIP = 37138,
        Sold = false,
        AvailableUntil = new DateTime(2025,12,12)
    },
    new Plant()
    {
        Species = "ZZ Plant",
        LightNeeds = 5,
        AskingPrice = 23.00M,
        City = "Knoxville",
        ZIP = 37777,
        Sold = false,
        AvailableUntil = new DateTime(2026,12,12)
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
    Console.WriteLine("Plants List:");

    for (int i = 0; i < plants.Count; i++)

    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? $"was sold for {plants[i].AskingPrice} dollars" : $"is available for {plants[i].AskingPrice} dollars")}, Expiration Date: {plants[i].AvailableUntil}\n");
    }

}

void PostAPlant()
{
    Plant newPlant = new Plant();

    Console.WriteLine("\nEnter a plant species:\n");
    newPlant.Species = Console.ReadLine().Trim();


    int lightNeeds = 0;

    do
    {
        Console.WriteLine("\nEnter the plant's light needs (1 for low light, 5 for heavy light):\n");
        lightNeeds = int.Parse(Console.ReadLine().Trim());

        try
        {
            if (lightNeeds < 1 || lightNeeds > 5)
            {
                Console.WriteLine("\nLight needs must be a value between 1 and 5. Please try again.\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nInvalid input. Please enter a valid integer.\n");
            lightNeeds = -1; // Set an invalid value to ensure the loop continues
        }
    } while (lightNeeds < 1 || lightNeeds > 5);

    newPlant.LightNeeds = lightNeeds;


    Console.WriteLine("\nEnter an asking price:\n");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine().Trim());

    Console.WriteLine("\nEnter a city:\n");
    newPlant.City = Console.ReadLine().Trim();

    Console.WriteLine("\nEnter a ZIP:\n");
    newPlant.ZIP = int.Parse(Console.ReadLine().Trim());

    newPlant.Sold = false;


    try
    {
        Console.WriteLine("\nPlease enter an expiration year...\n");
        int expirationYear = int.Parse(Console.ReadLine().Trim());


        Console.WriteLine("\nPlease enter an expiration month...\n");
        int expirationMonth = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine("\nPlease enter an expiration day...\n");
        int expirationDay = int.Parse(Console.ReadLine().Trim());

        newPlant.AvailableUntil = new DateTime(expirationYear, expirationMonth, expirationDay);
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.Clear();
        Console.WriteLine("\nDate invalid, please start over...\n");
        PostAPlant();

    }

    plants.Add(newPlant);
    Console.Clear();
    Console.WriteLine("\nPlant successfully posted...");
}

void AdoptAPlant()
{
    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold && plants[i].AvailableUntil >= DateTime.Now)
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

void SearchByLightNeeds()
{
    Console.WriteLine("\nWhat is the maximum Light Need you'd like to search for? (1 thru 5)");

    int response = int.Parse(Console.ReadLine().Trim());

    List<Plant> filteredByLight = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (response < 1 || response > 5)
        {
            Console.WriteLine("\nThis light need option is invalid\n");
        }
        if (response >= plant.LightNeeds)
        {
            filteredByLight.Add(plant);
        }
    }
    for (int i = 0; i < filteredByLight.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {filteredByLight[i].Species}");
    }
}

void PlantStatistics()
{
    Console.WriteLine("\u001b[4mExtraVert Statistics\u001b[0m");

    // Lowest price plant name
    List<Plant> availablePlants = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (plant.Sold == false && plant.AvailableUntil >= DateTime.Now)
        {
            availablePlants.Add(plant);
        }
    }

    Plant cheapestPlant = availablePlants.OrderBy(plant => plant.AskingPrice).First();

    Console.WriteLine($"\n - The cheapest plant available is: \u001b[4m{cheapestPlant.Species}\u001b[0m with a price of \u001b[4m${cheapestPlant.AskingPrice}\u001b[0m\n");


    // Number of Plants Available (not sold, and still available)
    Console.WriteLine($" - The number of plants currently available is: \u001b[4m{availablePlants.Count}\u001b[0m\n");


    // Name of plant with highest light needs
    List<Plant> plantsWithFiveLightNeeds = new List<Plant>();

    foreach (Plant plant in availablePlants)
    {
        if (plant.LightNeeds == 5)
        {
            plantsWithFiveLightNeeds.Add(plant);
        }
    }
    Console.Write($" - The number of plants with a light need of 5 is: \u001b[4m{plantsWithFiveLightNeeds.Count}\u001b[0m\n");


    // Average light needs
    double averageLightNeeds = availablePlants.Average(plant => plant.LightNeeds);

    Console.WriteLine($"\n - The average light need of available plants is: \u001b[4m{averageLightNeeds}\u001b[0m");


    // Percentage of plants adopted
    int plantsCount = plants.Count;
    double plantsAdoptedCount = 0;

    foreach (Plant plant in plants)
    {
        if (plant.Sold == true)
        {
            plantsAdoptedCount++;
        }
    }
    double plantsAdoptedPercentage = plantsAdoptedCount / plantsCount * 100;

    Console.Write($"\n - The percentage of plants that have been adopted overall is \u001b[4m{plantsAdoptedPercentage}%\u001b[0m\n");
}

void CSharpMethodPractice()
{
    foreach (Plant plant in plants)
    {
        Console.WriteLine($"{PlantDetails(plant)}");
    }
}

void Menu()
{
    Console.WriteLine(@$"
{"\u001b[4mMain Menu:\u001b[0m"}
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. De-List a plant
5. View a RANDOM Plant
6. Search Plant by Light Needs
7. See Plant Statistics
8. C# Method Practice
9. Clear Window
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
        case "6":
            Console.Clear();
            SearchByLightNeeds();
            Menu();
            break;
        case "7":
            Console.Clear();
            PlantStatistics();
            Menu();
            break;
        case "8":
            Console.Clear();
            CSharpMethodPractice();
            Menu();
            break;
        case "9":
            Console.Clear();
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

string PlantDetails(Plant plant)
{
    string plantString = plant.Species;

    return plantString;
}

void App()
{
    Console.Clear();
    Console.WriteLine(greeting);
    Menu();
}

App();

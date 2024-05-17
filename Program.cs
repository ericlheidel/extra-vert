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
        AvailableUntil = new DateTime(2021,12,12)
    },
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 2,
        AskingPrice = 17.00M,
        City = "Chattanooga",
        ZIP = 37209,
        Sold = false,
        AvailableUntil = new DateTime(2022,12,12)
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 19.00M,
        City = "Memphis",
        ZIP = 37212,
        Sold = true,
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
        AvailableUntil = new DateTime(2024,12,12)
    },
    new Plant()
    {
        Species = "ZZ Plant",
        LightNeeds = 5,
        AskingPrice = 23.00M,
        City = "Knoxville",
        ZIP = 37777,
        Sold = false,
        AvailableUntil = new DateTime(2025,12,12)
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? $"was sold for {plants[i].AskingPrice} dollars" : $"is available for {plants[i].AskingPrice} dollars")}, Expiration Date: {plants[i].AvailableUntil}\n");
    }

}

void PostAPlant()
{
    // Console.WriteLine("\nYou chose option 2\n");
    Console.WriteLine("\nPlease enter a species:\n");

    Plant newPlant = new Plant();

    Console.WriteLine("\nEnter a plant species:\n");
    newPlant.Species = Console.ReadLine().Trim();


    // Console.WriteLine("Enter the plant's light needs (1 for low light, 5 for heavy light)\n");
    // newPlant.LightNeeds = int.Parse(Console.ReadLine().Trim());

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    Console.WriteLine("\nEnter an asking price:\n");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine().Trim());

    Console.WriteLine("\nEnter a city:\n");
    newPlant.City = Console.ReadLine().Trim();

    Console.WriteLine("\nEnter a ZIP:\n");
    newPlant.ZIP = int.Parse(Console.ReadLine().Trim());

    newPlant.Sold = false;

    Console.WriteLine("\nPlease enter an expiration year...\n");
    int expirationYear = int.Parse(Console.ReadLine().Trim());

    Console.WriteLine("\nPlease enter an expiration month...\n");
    int expirationMonth = int.Parse(Console.ReadLine().Trim());

    Console.WriteLine("\nPlease enter an expiration day...\n");
    int expirationDay = int.Parse(Console.ReadLine().Trim());

    newPlant.AvailableUntil = new DateTime(expirationYear, expirationMonth, expirationDay);

    plants.Add(newPlant);
}

void AdoptAPlant()
{
    // List<Plant> availablePlants = new List<Plant>();

    // foreach (Plant plant in plants)
    // {
    //     if (plant.Sold == false && plant.AvailableUntil >= DateTime.Now)
    //     {
    //         availablePlants.Add(plant);
    //     }
    // }

    // for (int i = 0; i < availablePlants.Count; i++)
    // {
    //     Console.WriteLine($"{i + 1}. {availablePlants[i].Species} in {availablePlants[i].City} {(availablePlants[i].Sold ? $"was sold for {availablePlants[i].AskingPrice} dollars" : $"is available for {availablePlants[i].AskingPrice} dollars")}, Expiration Date: {availablePlants[i].AvailableUntil}\n");
    // }

    // List<Plant> availablePlants = new List<Plant>();

    // for (int i = 0; i < plants.Count; i++)
    // {
    //     if (plants[i].Sold == false && plants[i].AvailableUntil >= DateTime.Now)
    //     {
    //         availablePlants.Add(plants[i]);
    //     }
    // }

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

void Menu()
{
    Console.WriteLine(@"Main Menu:
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. De-List a plant
5. View a RANDOM Plant
6. Search Plant by Light Needs
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

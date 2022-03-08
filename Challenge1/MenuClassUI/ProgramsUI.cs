using MenuClassRepo; //Not sure what's going on here
public class ProgramsUI
{
// Allowing the cafe manager to add, delete, and see all items on the menu list
// Time to Instantiate

private readonly MenuClassRepository _menuRepo = new MenuClassRepository();

public void Run(){
    RunMenu();
}

public void RunMenu(){
    bool continueToRun = true;
    while(continueToRun){
        Console.Clear();

        Console.WriteLine("Enter the number of the option you'd like to select:\n"+
        "1. Show all meals on menu\n"+
        "2. Add meals to the menu\n"+
        "3. Delete meals from the menu\n"+
        "4. Exit");

        string userInput = Console.ReadLine();

        switch(userInput){
            case "1":
            ShowAllMeals();
            break;
            case "2":
            CreateNewMeals();
            break;
            case "3":
            RemoveMealFromList();
            break;
            case "4":
            continueToRun = false;
            break;
            default:
            Console.WriteLine("Please Enter a Valid Number between 1 and 4.\n"+
            "Press any key to continue...............");
            Console.ReadKey();
            break;
        }
    }
}

private void CreateNewMeals(){
    Console.Clear();
    MenuClass menu = new MenuClass();

    Console.WriteLine("Select a Meal Number:\n"+
    "#1\n"+
    "#2\n"+
    "#3\n"+
    "#4\n"+
    "#5\n");
    string mealNumber = Console.ReadLine();
    
    Console.WriteLine("Enter a meal Name:");
    menu.MealName = Console.ReadLine();

    Console.WriteLine("Enter a brief Description of the meal:");
    menu.Description = Console.ReadLine();

    Console.WriteLine("Enter the Ingredients of the meal:");
    menu.IngredientList = Console.ReadLine();

    Console.WriteLine("Enter the Price of the meal:");
    menu.Price = double.Parse(Console.ReadLine());
}

private void ShowAllMeals(){
    Console.Clear();

    List<MenuClass> ingredientList = _menuRepo.GetMeal();

    foreach(MenuClass menu in ingredientList){
        DisplayMenu(menu);
    }
    Console.WriteLine("Press any key to continue................");
    Console.ReadKey();
}

    private void DisplayMenu(MenuClass menu){
        Console.WriteLine($"MealName: {menu.MealName}\n"+
        $"Description:{menu.Description}\n"+
        $"Ingredient: {menu.IngredientList}\n"+
        $"Number: {menu.Number}\n"+
        $"Price: {menu.Price}\n");
    }

private void ShowMenuByMealName(){
    Console.Clear();
    Console.WriteLine("Enter a meal Name");
    string mealName = Console.ReadLine();
    MenuClass menu = _menuRepo.GetMealByMealName(mealName);
    if(menu != null){
        DisplayMenu(menu);
    }
    else{
        Console.WriteLine("Invalid Meal Name! Could Not Find Any Results!");
    }

    Console.WriteLine("Press any key to continue.................");
    Console.ReadKey();
}

private void RemoveMealFromList(){
    Console.Clear();
    Console.WriteLine("Which item would yo like to remove?");

    List<MenuClass> mealList = _menuRepo.GetMeal();

    int count = 0;

    foreach(MenuClass meal in mealList){
        count++;
        Console.WriteLine($"{count}. {meal.MealName}");
    }

int targetMenuID = int.Parse(Console.ReadLine());
int targetIndex = targetMenuID - 1;

if(targetIndex >= 0 && targetIndex < mealList.Count){
    MenuClass desiredMeal = mealList [targetIndex];

    if(_menuRepo.DeleteExistingMeal(desiredMeal)){
        Console.WriteLine($"{desiredMeal.MealName} was successfully removed.");
    }
    else{
        Console.WriteLine("An error occured. Please try again.");
    }

    Console.WriteLine("Press any key to contine................");
    Console.ReadKey();
}
}
}
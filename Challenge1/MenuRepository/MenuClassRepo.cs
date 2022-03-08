namespace MenuClassRepo;
public class MenuClassRepository
{
    protected readonly List<MenuClass> _menuDirectory = new List<MenuClass>();
    public bool AddMenuToDirectory(MenuClass menu){
        int startingCount = _menuDirectory.Count;

        _menuDirectory.Add(menu);

        bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

// public vs private:
// If another coder was to pull this information = public
// If to stay on this VS, where no one can access it = private
public List<MenuClass> GetMeal(){
    return _menuDirectory;
}

public MenuClass GetMealByMealName(string mealName){
    foreach(MenuClass menu in _menuDirectory){
        if(menu.MealName.ToLower() == mealName.ToLower()){
            return menu;
        }
    }

    return null; //Friendly Reminder: If there's an error searching (title name, spelling, etc) this will return and do nothing (like the 404)
}

// Needs this so management can change the menu from old to new
public bool UpdateExistingMenu(string originalMealName, MenuClass newMeal){
    MenuClass oldMeal = GetMealByMealName (originalMealName);

    if(oldMeal != null){
        oldMeal.MealName = newMeal.MealName;
        oldMeal.Number = newMeal.Number;
        oldMeal.Description = newMeal.Description;
        oldMeal.IngredientList = newMeal.IngredientList;

        return true;
    }
    else{
        return false;
    }
}

public bool DeleteExistingMeal(MenuClass existingMeal){
     bool deleteResult = _menuDirectory.Remove(existingMeal);
    return deleteResult;
}
}
//The "content" in this challenge is "meal" not menu
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class CraftManager : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;
    [SerializeField]
    private List<RecipeSO> recipes = new List<RecipeSO>();
    //private RecipeSO recipe;
    [SerializeField]
    private int maxRecipeLen;

    private List<RecipeItemSO> tempCraftItems = new List<RecipeItemSO>();

    public bool CraftItem(RecipeItemSO recipeItem)
    {
        tempCraftItems.Add(recipeItem);

        foreach(var recipe in recipes)
        {
            if (tempCraftItems.Count == recipe.Ingredients.Count)
            {
                if (IsValidRecipe(recipe))
                {
                    inventoryData.AddItem(recipe.Result, 1);
                    tempCraftItems.Clear();
                    return true;
                }
            }
        }
        if (tempCraftItems.Count >= maxRecipeLen)
        {
            ReturnItemsToPlayer();
            return false;
        }
        return false;
    }

    private bool IsValidRecipe(RecipeSO recipe)
    {
        for (int i = 0; i < tempCraftItems.Count; i++)
        {
            if (tempCraftItems[i] != recipe.Ingredients[i])
                return false;
        }
        return true;
    }

    private void ReturnItemsToPlayer()
    {
        foreach (var item in tempCraftItems)
        {
            inventoryData.AddItem(item, 1);
        }
        tempCraftItems.Clear();
    }
}


// namespace Inventory.Model
// {
//     public class CraftManager : MonoBehaviour
//     {
//         private InventoryController inventoryController;
//         private InventorySO inventoryData;

//         private List<ItemSO> tempCraftItems = new List<ItemSO>();

//         public bool CraftItem(CraftableItemSO craftableItem, GameObject character)
//         {

//             tempCraftItems.Add(craftableItem);

//             // Check if we have the required number of items for crafting
//             if (tempCraftItems.Count == craftableItem.Recipe.Ingredients.Count)
//             {
//                 // Check if the items match the recipe
//                 if (IsValidRecipe(craftableItem.Recipe))
//                 {
//                     // Craft the item and add it to the player's inventory
//                     inventoryData.AddItem(craftableItem.Recipe.Result, 1);

//                     // Clear the temporary list
//                     tempCraftItems.Clear();
//                     return true;
//                 }
//                 else
//                 {
//                     // If the recipe is invalid, return the items to the player
//                     ReturnItemsToPlayer();
//                     return false;
//                 }
//             }
//             return false;
//         }

//         private bool IsValidRecipe(RecipeSO recipe)
//         {
//             if (tempCraftItems.Count != recipe.Ingredients.Count)
//                 return false;

//             // Check if each item in tempCraftItems matches the corresponding item in the recipe
//             for (int i = 0; i < tempCraftItems.Count; i++)
//             {
//                 if (tempCraftItems[i] != recipe.Ingredients[i])
//                     return false;
//             }
//             return true;
//         }

//         private void ReturnItemsToPlayer()
//         {
//             foreach (var item in tempCraftItems)
//             {
//                 inventoryData.AddItem(item, 1);
//             }
//             tempCraftItems.Clear();
//         }
//     }
// }

//             // Check if we have the required number of items for crafting
//             if (tempCraftItems.Count == craftableItem.Recipe.Ingredients.Count)
//             {
//                 // Check if the items match the recipe
//                 if (IsValidRecipe(craftableItem.Recipe))
//                 {
//                     // Craft the item and add it to the player's inventory
//                     inventoryData.AddItem(craftableItem.Recipe.Result, 1);

//                     // Clear the temporary list
//                     tempCraftItems.Clear();
//                     return true;
//                 }
//                 else
//                 {
//                     // If the recipe is invalid, return the items to the player
//                     ReturnItemsToPlayer();
//                     return false;
//                 }
//             }
//             return false;
//         }

//         private bool IsValidRecipe(RecipeSO recipe)
//         {
//             if (tempCraftItems.Count != recipe.Ingredients.Count)
//                 return false;

//             // Check if each item in tempCraftItems matches the corresponding item in the recipe
//             for (int i = 0; i < tempCraftItems.Count; i++)
//             {
//                 if (tempCraftItems[i] != recipe.Ingredients[i])
//                     return false;
//             }
//             return true;
//         }

//         private void ReturnItemsToPlayer()
//         {
//             foreach (var item in tempCraftItems)
//             {
//                 inventoryData.AddItem(item, 1);
//             }
//             tempCraftItems.Clear();
//         }
//     }
// }
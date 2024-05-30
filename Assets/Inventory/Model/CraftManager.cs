using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class CraftManager : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;
    [SerializeField]
    private List<RecipeSO> recipes = new List<RecipeSO>();

    [SerializeField]
    private int maxRecipeLen;

    private List<RecipeItemSO> tempCraftItems = new List<RecipeItemSO>();
    [SerializeField]
    private AudioClip craftingSFX;

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
                    AudioSource.PlayClipAtPoint(craftingSFX, transform.position);
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
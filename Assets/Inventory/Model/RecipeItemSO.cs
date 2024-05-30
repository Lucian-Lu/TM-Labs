using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class RecipeItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Craft";

        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            CraftManager craftManager = character.GetComponent<CraftManager>();
            if (craftManager != null)
            {
                craftManager.CraftItem(this);   
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}

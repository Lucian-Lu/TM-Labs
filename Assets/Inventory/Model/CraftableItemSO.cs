// using System.Collections.Generic;
// using UnityEngine;

// namespace Inventory.Model
// {
//     [CreateAssetMenu]
//     public class CraftableItemSO : ItemSO, IItemAction
//     {
//         [SerializeField]
//         private RecipeSO recipe;
//         [field: SerializeField]
//         public AudioClip actionSFX { get; private set; }
//         public CraftManager craftManager;

//         public string ActionName => "Craft";

//         public RecipeSO Recipe => recipe;

//         public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
//         {
//             if (craftManager == null)
//             {
//                 Debug.LogError("CraftManager reference not set in CraftableItemSO.");
//                 return false;
//             }

//             return craftManager.CraftItem(this, character);
//         }
//     }
// }

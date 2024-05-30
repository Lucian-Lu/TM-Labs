// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using Inventory.Model;

// public class CraftSlot : MonoBehaviour
// {
//     public Image icon;
//     public Text nameSlot;
//     public GameObject parts;
//     public InventoryItem craftItem;
//     public Image partPref;
//     public Button createButton;
    
//     // Reference to the inventory
//     public InventorySO inventorySO;

//     public bool checkParts()
//     {
//         // Get the required item and quantity for crafting
//         ItemSO requiredItem = craftItem.item;
//         int requiredQuantity = craftItem.quantity;
        
//         // Check the inventory for the required item and quantity
//         int count = 0;
//         foreach (var inventoryItem in inventorySO.GetCurrentInventoryState().Values)
//         {
//             if (inventoryItem.item == requiredItem)
//             {
//                 count += inventoryItem.quantity;
//                 if (count >= requiredQuantity)
//                 {
//                     return true;
//                 }
//             }
//         }
//         return false;
//     }

//     public void onCreateButton()
//     {
//         if (checkParts())
//         {
//             ItemSO requiredItem = craftItem.item;
//             int requiredQuantity = craftItem.quantity;

//             // Remove the required items from the inventory
//             foreach (var inventoryItem in inventorySO.GetCurrentInventoryState())
//             {
//                 if (requiredQuantity <= 0)
//                     break;

//                 if (inventoryItem.Value.item == requiredItem)
//                 {
//                     int availableQuantity = inventoryItem.Value.quantity;
//                     if (availableQuantity >= requiredQuantity)
//                     {
//                         inventorySO.RemoveItem(inventoryItem.Key, requiredQuantity);
//                         requiredQuantity = 0;
//                     }
//                     else
//                     {
//                         inventorySO.RemoveItem(inventoryItem.Key, availableQuantity);
//                         requiredQuantity -= availableQuantity;
//                     }
//                 }
//             }

//             // Add the crafted item to the inventory
//             inventorySO.AddItem(craftItem.item, craftItem.quantity);
//         }
//     }

//     public void addCraftItem(InventoryItem newItem)
//     {
//         craftItem = newItem;
//         icon.sprite = craftItem.item.ItemImage;
//         nameSlot.text = craftItem.item.Name;

//         // Clear existing parts
//         foreach (Transform child in parts.transform)
//         {
//             Destroy(child.gameObject);
//         }

//         // Assuming craftItem.item.DefaultParametersList contains the parts needed for crafting
//         foreach (var detail in craftItem.item.DefaultParametersList)
//         {
//             if (detail.itemParameter is ItemSO partItemSO)
//             {
//                 partPref.sprite = partItemSO.ItemImage;
//                 Instantiate(partPref, parts.transform);
//             }
//         }
//     }
// }

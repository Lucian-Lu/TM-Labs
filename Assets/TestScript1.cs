// using UnityEngine;
// using UniversalInventorySystem;

// public class TestScript1 : MonoBehaviour
// {   
//     public Inventory inventory;

//     // To test the item drawer in inspector
//     public Item testItem;
//     public int slotAmount;

//     private void Start()
//     {
//         //Events
//         InventoryHandler invEvent = InventoryHandler.current;
//         invEvent.OnAddItem += OnAddItem;
//         invEvent.OnRemoveItem += OnRemoveItem;
//     }

//     private void Update()
//     {
//         //Adds a item
//         if (Input.GetKeyDown(KeyCode.A))
//             inventory.AddItem(InventoryHandler.current.GetItem(0, 0), 1);


//         //Checks an item in a inventory
//         // Debug.Log(inventory.CheckItemInInventory(InventoryHandler.current.GetItem(0, 5), 1).HasItem);
//     }

//     //Callback function for when an item is removed from any inventory
//     private void OnRemoveItem(object sender, InventoryHandler.RemoveItemEventArgs e)
//     {
//         Debug.Log("Remove (ExampleScript)");
//     }

//     //Callback function for when an item is added from any inventory
//     private void OnAddItem(object sender, InventoryHandler.AddItemEventArgs e)
//     {
//         Debug.Log($"The item {e.itemAdded.name} was added (ExampleScript)");
//     }

//     //Unsubscribing the events if this object gets destoyed (better use the OnDisable func if your gameobj can be set inactive in hireachy)
//     private void OnDestroy()
//     {
//         InventoryHandler.current.OnAddItem -= OnAddItem;
//         InventoryHandler.current.OnRemoveItem -= OnRemoveItem;
//     }

// }
// using UnityEngine;
// using UniversalInventorySystem;

// [RequireComponent(typeof(InventoryUI))]
// public class TestScript1 : MonoBehaviour
// {
//     Inventory inventory;
//     InventoryUI invUI;

//     private void Start()
//     {
//         invUI = GetComponent<InventoryUI>();
//         inventory = invUI.GetInventory();
//     }
   
//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.B))
//             inventory.AddItem(InventoryHandler.current.GetItem(0, 0), 1);
//         if (Input.GetKeyDown(KeyCode.V))
//             inventory.AddItem(InventoryHandler.current.GetItem(0, 0), 0);
//     }
// }

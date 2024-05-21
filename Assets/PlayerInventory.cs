using UnityEngine;
using UniversalInventorySystem;

[RequireComponent(typeof(InventoryUI))]
public class PlayerInventory : MonoBehaviour
{
    Inventory inventory;
    InventoryUI invUI;

    private void Start()
    {
        invUI = GetComponent<InventoryUI>();
        inventory = invUI.GetInventory();
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            inventory.AddItem(InventoryHandler.current.GetItem(0, 0), 1);
        if (Input.GetKeyDown(KeyCode.V))
            inventory.AddItem(InventoryHandler.current.GetItem(0, 1), 3);
    }
}
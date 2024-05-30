// using Inventory.Model;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Item : MonoBehaviour
// {
//     [field: SerializeField]
//     public ItemSO InventoryItem { get; private set; }

//     [field: SerializeField]
//     public int Quantity { get; set; } = 1;

//     [SerializeField]
//     private AudioSource audioSource;

//     [SerializeField]
//     private float duration = 0.3f;

//     private void Start()
//     {
//         GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
//     }

//     public void DestroyItem()
//     {
//         GetComponent<Collider2D>().enabled = false;
//         StartCoroutine(AnimateItemPickup());

//     }

//     private IEnumerator AnimateItemPickup()
//     {
//         audioSource.Play();
//         Vector3 startScale = transform.localScale;
//         Vector3 endScale = Vector3.zero;
//         float currentTime = 0;
//         while (currentTime < duration)
//         {
//             currentTime += Time.deltaTime;
//             transform.localScale = 
//                 Vector3.Lerp(startScale, endScale, currentTime / duration);
//             yield return null;
//         }
//         Destroy(gameObject);
//     }
// }
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float duration = 0.3f;

    public ItemSO inventoryItem;

    public ItemSO InventoryItem
    {
        get { return inventoryItem; }
        set
        {
            inventoryItem = value;
            GetComponent<SpriteRenderer>().sprite = inventoryItem.ItemImage;
            inventoryItem.itemPrefab = gameObject;
        }
    }

    public int Quantity { get; set; } = 1;

    private void Start()
    {
        // Set sprite based on the assigned ItemSO
        if (inventoryItem != null)
        {
            GetComponent<SpriteRenderer>().sprite = inventoryItem.ItemImage;
        }
    }

    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup());
    }

    private IEnumerator AnimateItemPickup()
    {
        audioSource.Play();
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            transform.localScale = 
                Vector3.Lerp(startScale, endScale, currentTime / duration);
            yield return null;
        }
        Destroy(gameObject);
    }
}

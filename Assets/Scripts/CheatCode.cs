using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class CheatCode : MonoBehaviour
{
    private string[] cheatCode;
    private int index;
    public List<ItemSO> cheatItems;

    void Start()
    {
        cheatCode = new string[] { "s", "o", "t", "h", "i", "s", "i", "s", "a", "n", "e", "a", "s", "t", "e", "r", "e", "g", "g"};
        index = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            foreach (ItemSO item in cheatItems)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
            }
            index = 0;
        }
    }
}

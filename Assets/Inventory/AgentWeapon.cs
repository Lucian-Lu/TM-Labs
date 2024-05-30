using Inventory.Model;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField]
    private EquippableItemSO weapon;

    [SerializeField]
    private EquippableItemSO armor;

    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private List<ItemParameter> weaponParametersToModify, armorParametersToModify, itemCurrentState;

    public void SetWeapon(EquippableItemSO weaponItemSO, List<ItemParameter> itemState)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1, itemCurrentState);
        }

        this.weapon = weaponItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        ModifyWeaponParameters();
        UpdatePlayerCombatDamage();
    }

    public void SetArmor(EquippableItemSO armorItemSO, List<ItemParameter> itemState)
    {
        if (armor != null)
        {
            inventoryData.AddItem(armor, 1, itemCurrentState);
        }

        this.armor = armorItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        ModifyArmorParameters();
        UpdatePlayerMaxHealth();
    }

    private void ModifyWeaponParameters()
    {
        foreach (var parameter in weaponParametersToModify)
        {
            if (itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }

    private void ModifyArmorParameters()
    {
        foreach (var parameter in armorParametersToModify)
        {
            if (itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }

    private void UpdatePlayerCombatDamage()
    {
        PlayerCombat playerCombat = GetComponent<PlayerCombat>();
        if (playerCombat != null && weapon != null)
        {
            playerCombat.attackDamage = weapon.AttackDamage;
        }
    }

    private void UpdatePlayerMaxHealth()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null && armor != null)
        {
            playerHealth.setMaxHealth(armor.MaxHealthIncrease);
        }
    }
}

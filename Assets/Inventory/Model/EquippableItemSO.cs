// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Inventory.Model
// {
//     [CreateAssetMenu]
//     public class EquippableItemSO : ItemSO, IDestroyableItem, IItemAction
//     {
//         public string ActionName => "Equip";

        // [field: SerializeField]
        // public AudioClip actionSFX { get; private set; }

//         [field: SerializeField]
//         public int attackDamage { get; private set; }

//         public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
//         {
//             AgentWeapon weaponSystem = character.GetComponent<AgentWeapon>();
//             if (weaponSystem != null)
//             {
//                 weaponSystem.SetWeapon(this, itemState == null ? 
//                     DefaultParametersList : itemState);
//                 return true;
//             }
//             return false;
//         }
//     }
// }
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EquippableItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        [field: SerializeField]
        public int attackDamage; // For weapons

        [field: SerializeField]
        public int maxHealthIncrease; // For armor

        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }

        public int AttackDamage => attackDamage;

        public int MaxHealthIncrease => maxHealthIncrease;

        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            AgentWeapon weaponSystem = character.GetComponent<AgentWeapon>();
            if (weaponSystem != null)
            {
                if (attackDamage != 0)
                {
                    weaponSystem.SetWeapon(this, itemState == null ? DefaultParametersList : itemState);
                }
                else if (maxHealthIncrease != 0)
                {
                    weaponSystem.SetArmor(this, itemState == null ? DefaultParametersList : itemState);
                }
                return true;
            }
            return false;
        }
    }
}
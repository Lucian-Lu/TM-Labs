using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class RecipeSO : ScriptableObject
    {
        [SerializeField]
        private List<RecipeItemSO> ingredients;
        [SerializeField]
        private EquippableItemSO result;

        public List<RecipeItemSO> Ingredients => ingredients;
        public EquippableItemSO Result => result;
    }
}

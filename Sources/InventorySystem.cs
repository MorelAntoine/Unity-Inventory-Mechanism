using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniCraft.InventoryMechanism
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to replicate the behaviour of an inventory
    /// </summary>
    [AddComponentMenu("UniCraft/InventorySystem")]
    [DisallowMultipleComponent]
    public class InventorySystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] protected List<AInventoryItem> InventoryItems;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public IEnumerable<AInventoryItem> GetInventoryItems => InventoryItems;
        public int GetCapacity => InventoryItems.Capacity;
        public int GetSize => InventoryItems.Count;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /////////////////////////
        ////////// API //////////
        
        ////////// Mechanism //////////
        
        public virtual bool AddInventoryItem(AInventoryItem inventoryItem)
        {
            if (InventoryItems.Count >= InventoryItems.Capacity)
            {
                return (false);
            }
            InventoryItems.Add(inventoryItem);
            return (true);
        }

        public virtual bool RemoveInventoryItem(AInventoryItem inventoryItem)
        {
            return (InventoryItems.Remove(inventoryItem));
        }

        public virtual int ResizeInventory(int newCapacity)
        {
            InventoryItems.Capacity = newCapacity;
            return (InventoryItems.Capacity);
        }

        ////////// Sort //////////
        
        public virtual IEnumerable<AInventoryItem> SortInventoryByName(bool bAscending = true)
        {
            if ( bAscending )
            {
                InventoryItems = InventoryItems.OrderBy(item => item.GetName).ToList();
            }
            else
            {
                InventoryItems = InventoryItems.OrderByDescending(item => item.GetName).ToList();
            }
            return (InventoryItems);
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour callback //////////

        protected virtual void Awake()
        {
            // instantiate ScriptableObject
        }
    }
}

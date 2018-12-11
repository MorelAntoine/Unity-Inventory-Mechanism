using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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

        /////////////////////////////////////
        ////////// Default Setting //////////

        public const int MinCapacity = 0;
        public const int MaxCapacity = 999;
        
        /////////////////////////////////
        ////////// Information //////////

        [SerializeField] protected int Capacity;
        [SerializeField] protected int Size;
        
        ///////////////////////////////
        ////////// Inventory //////////

        [SerializeField] protected List<AInventoryItem> Items;

        /////////////////////////////////
        ////////// Unity Event //////////

        ////////// Inventory Management //////////
        
        [SerializeField] protected UnityEvent OnOpenInventoryEvents = null;
        [SerializeField] protected UnityEvent OnCloseInventoryEvents = null;
        [SerializeField] protected UnityEvent OnResizeInventoryEvents = null;

        ////////// Item Management //////////

        [SerializeField] protected UnityEvent OnAddItemEvents = null;
        [SerializeField] protected UnityEvent OnRemoveItemEvents = null;

        ////////// Sort //////////
        
        [SerializeField] protected UnityEvent OnSortItemsEvents = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        /////////////////////////////////
        ////////// Information //////////

        public int GetCapacity => Capacity;
        public int GetSize => Size;
        
        ///////////////////////////////
        ////////// Inventory //////////

        public List<AInventoryItem> GetItems => Items;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////
        
        ////////// Inventory Management //////////
        
        public virtual void OpenInventory()
        {
            OnOpenInventoryEvents.Invoke();
        }

        public virtual void CloseInventory()
        {
            OnCloseInventoryEvents.Invoke();
        }

        public virtual void ResizeInventory(int newCapacity)
        {
            Items.Capacity = newCapacity;
            Capacity = Items.Capacity;
            Size = Items.Count;
            OnResizeInventoryEvents.Invoke();
        }
        
        ////////// Item Management //////////

        public virtual bool AddItem(AInventoryItem item)
        {
            if ( Size == Capacity )
            {
                return (false);
            }
            Items.Add(item);
            OnAddItemEvents.Invoke();
            return (true);
        }

        public virtual bool RemoveItem(AInventoryItem item)
        {
            if ( !Items.Remove(item) )
            {
                return (false);
            }
            OnRemoveItemEvents.Invoke();
            return (true);
        }
        
        ////////// Research //////////

        public bool Contains(AInventoryItem item)
        {
            return (Items.Contains(item));
        }
        
        public AInventoryItem FindItemByName(string itemName)
        {
            return (Items.Find(item => item.GetName == itemName));
        }

        public List<AInventoryItem> FindAllItemByName(string itemName)
        {
            return (Items.FindAll(item => item.GetName == itemName));
        }
        
        ////////// Sort //////////

        public void SortItemsByName(bool bAscending = true)
        {
            Items = (bAscending ? Items.OrderBy(i => i.GetName) : Items.OrderByDescending(i => i.GetName)).ToList();
            OnSortItemsEvents.Invoke();
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            Items.Capacity = Capacity;
        }
    }
}

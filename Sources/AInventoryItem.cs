using UnityEngine;

namespace UniCraft.InventoryMechanism
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create an inventory item
    /// </summary>
    public abstract class AInventoryItem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public string GetName => Name;
        public string GetDescription => Description;
    }
}

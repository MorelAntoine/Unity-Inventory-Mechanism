using UnityEngine;

namespace UniCraft.InventoryMechanism
{
    public abstract class AInventoryItem : ScriptableObject
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

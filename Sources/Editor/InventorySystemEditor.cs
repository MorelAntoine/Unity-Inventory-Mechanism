using UnityEditor;
using UnityEngine;

namespace UniCraft.InventoryMechanism.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(InventorySystem))]
    public class InventorySystemEditor : UnityEditor.Editor
    {
        ///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////////////
		////////// Default setting //////////

		////////// Label //////////
		
		private const string InformationTitle = "Information";
		private const string InventoryTitle = "Inventory";
		private const string InventoryManagementEventTitle = "Inventory Management Event";
		private const string ItemManagementEventTitle = "Item Management Event";
		private const string SortItemsEventTitle = "Sort Items Event";
		
		////////// Value //////////
		
		private const float SpaceBetweenField = 6f;
		
		/////////////////////////////////////////
		////////// Serialized property //////////
		
		private SerializedProperty _capacity;
		private SerializedProperty _size;
		private SerializedProperty _items;
	    private SerializedProperty _onOpenInventoryEvents;
		private SerializedProperty _onCloseInventoryEvents;
		private SerializedProperty _onResizeInventoryEvents;		
	    private SerializedProperty _onAddItemEvents;
		private SerializedProperty _onRemoveItemEvents;
	    private SerializedProperty _onSortItemsEvents;

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////
		
		private void OnEnable()
		{
			_capacity = serializedObject.FindProperty("Capacity");
			_size = serializedObject.FindProperty("Size");
			_items = serializedObject.FindProperty("Items");
			_onOpenInventoryEvents = serializedObject.FindProperty("OnOpenInventoryEvents");
			_onCloseInventoryEvents = serializedObject.FindProperty("OnCloseInventoryEvents");
			_onResizeInventoryEvents = serializedObject.FindProperty("OnResizeInventoryEvents");
			_onAddItemEvents = serializedObject.FindProperty("OnAddItemEvents");
			_onRemoveItemEvents = serializedObject.FindProperty("OnRemoveItemEvents");
			_onSortItemsEvents = serializedObject.FindProperty("OnSortItemsEvents");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DrawInformation();
			DrawInventory();
			DrawInventoryManagementEvent();
			DrawItemManagementEvent();
			DrawSortItemsEvent();
			serializedObject.ApplyModifiedProperties();
		}

		/////////////////////////////
		////////// Drawing //////////

	    private void DrawInformation()
	    {
		    _size.intValue = _items.arraySize;
		    if ( _size.intValue > _capacity.intValue )
		    {
			    _capacity.intValue = _size.intValue;
		    }
		    GUILayout.Space(SpaceBetweenField);
		    EditorGUILayout.LabelField(InformationTitle, EditorStyles.boldLabel);
		    EditorGUILayout.IntSlider(_capacity, InventorySystem.MinCapacity, InventorySystem.MaxCapacity);
		    EditorGUI.BeginDisabledGroup(true);
		    EditorGUILayout.PropertyField(_size);
		    EditorGUI.EndDisabledGroup();
	    }

	    private void DrawInventory()
	    {
		    GUILayout.Space(SpaceBetweenField);
		    EditorGUILayout.LabelField(InventoryTitle, EditorStyles.boldLabel);
		    EditorGUILayout.PropertyField(_items, true);
	    }

	    private void DrawInventoryManagementEvent()
	    {
		    GUILayout.Space(SpaceBetweenField);
		    EditorGUILayout.LabelField(InventoryManagementEventTitle, EditorStyles.boldLabel);
		    EditorGUILayout.PropertyField(_onOpenInventoryEvents, true);
		    EditorGUILayout.PropertyField(_onCloseInventoryEvents, true);
		    EditorGUILayout.PropertyField(_onResizeInventoryEvents, true);
	    }

	    private void DrawItemManagementEvent()
	    {
		    GUILayout.Space(SpaceBetweenField);
		    EditorGUILayout.LabelField(ItemManagementEventTitle, EditorStyles.boldLabel);
		    EditorGUILayout.PropertyField(_onAddItemEvents, true);
		    EditorGUILayout.PropertyField(_onRemoveItemEvents, true);
	    }

	    private void DrawSortItemsEvent()
	    {
		    GUILayout.Space(SpaceBetweenField);
		    EditorGUILayout.LabelField(SortItemsEventTitle, EditorStyles.boldLabel);
		    EditorGUILayout.PropertyField(_onSortItemsEvents, true);
	    }
    }
}

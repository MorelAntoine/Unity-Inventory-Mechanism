using UnityEditor;
using UnityEngine;

namespace UniCraft.InventoryMechanism.Editor
{
	[CustomEditor(typeof(InventorySystem))]
	public class InventorySystemEditor : UnityEditor.Editor
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		/////////////////////////////////////
		////////// Default setting //////////

		////////// Label //////////
		
		private const string CapacityLabel = "Capacity";
		private const string InformationTitleLabel = "Information";
		private const string SizeLabel = "Size";
		
		////////// Value //////////
		
		private const int MinSliderValue = 0;
		private const int MaxSliderValue = 999;
		private const float SpaceBetweenField = 6f;
		
		////////// Width //////////
		
		private const float CapacityLabelWidth = 60f;
		private const float SizeLabelWidth = 60f;

		///////////////////////////////
		////////// Mechanism //////////

		private InventorySystem _inventorySystem;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////

		private void OnEnable()
		{
			_inventorySystem = target as InventorySystem;
		}

		public override void OnInspectorGUI()
		{
			DrawInventory();
			DrawInventoryInformation();
		}

		/////////////////////////////
		////////// Drawing //////////

		private void DrawInventoryInformation()
		{
			GUILayout.Space(SpaceBetweenField);
			EditorGUILayout.LabelField(InformationTitleLabel, EditorStyles.boldLabel);
			_inventorySystem.ResizeInventory(EditorGUILayout.IntSlider(CapacityLabel, _inventorySystem.GetCapacity,
				MinSliderValue, MaxSliderValue));
			EditorGUI.BeginDisabledGroup(true);
			EditorGUILayout.IntField(SizeLabel, _inventorySystem.GetSize);
			EditorGUI.EndDisabledGroup();
		}

		private void DrawInventory()
		{
			DrawDefaultInspector();
		}
	}
}
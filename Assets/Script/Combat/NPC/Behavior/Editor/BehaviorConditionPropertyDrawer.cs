using UnityEngine;
using UnityEditor;


namespace ProjectS.Combat.NPC.Behavior.Editors
{
    [CustomPropertyDrawer(typeof(BehaviorCondition))]
    public class BehaviorConditionPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //base.OnGUI(position, property, label);

            EditorGUI.BeginProperty(position, label, property);


            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            
            //Get the _conditionType property and convert to BehaviorConditionType
            SerializedProperty conditionTypeProperty = property.FindPropertyRelative("_conditionType");

            position.height = EditorGUI.GetPropertyHeight(conditionTypeProperty);
            EditorGUI.PropertyField(position, conditionTypeProperty, GUIContent.none);


            BehaviorConditionType conditionType = (BehaviorConditionType)conditionTypeProperty.enumValueIndex;
            
            SerializedProperty conditionOptionProperty = GetConditionOptionsProperty(conditionType, property);

            if (conditionOptionProperty != null)
            {
                position.y = EditorGUI.GetPropertyHeight(conditionTypeProperty) + 3f;
                position.height = EditorGUI.GetPropertyHeight(conditionOptionProperty);
                //Draw the conditionOptionProperty if it exists
                EditorGUI.PropertyField(position, conditionOptionProperty, true);
            }
            



            /*
            if (conditionOptionProperty == null)
            {
                Debug.LogError($"Condition options for {conditionType} not found in property: {property.name}");
                return;
            }
            Rect displayRect = new Rect(position.x + 30, position.y, position.width, EditorGUI.GetPropertyHeight(conditionOptionProperty));
            EditorGUI.PropertyField(displayRect, conditionOptionProperty);
            */
            EditorGUI.EndProperty();
        }

        private SerializedProperty GetConditionOptionsProperty(BehaviorConditionType conditionType, SerializedProperty property)
        {
            property = property.FindPropertyRelative(conditionType.ToString());

            return property;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty conditionTypeProperty = property.FindPropertyRelative("_conditionType");
            BehaviorConditionType conditionType = (BehaviorConditionType)conditionTypeProperty.enumValueIndex;
            float height = EditorGUI.GetPropertyHeight(conditionTypeProperty);

            
            SerializedProperty conditionOptionProperty = GetConditionOptionsProperty(conditionType, property);
            if (conditionOptionProperty != null)
            {
                height += EditorGUI.GetPropertyHeight(conditionOptionProperty, label) + 3f; // Add some space between the fields
            }
            return height;
        }
    }
}
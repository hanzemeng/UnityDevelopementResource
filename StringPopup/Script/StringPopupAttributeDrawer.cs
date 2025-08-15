#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;
using System.Text;

[CustomPropertyDrawer(typeof(StringPopupAttribute), true)]
public class StringPopupAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        StringPopupAttribute stringDropdownAttribute = attribute as StringPopupAttribute;
        string[] options = stringDropdownAttribute.GetOptions(property.serializedObject.targetObject);

        string oldStr = property.stringValue;
        int oldIndex = Array.FindIndex(options, i=>string.Equals(i, oldStr));

        bool oldIndexInvalid = false;
        if(oldIndex < 0)
        {
            oldIndexInvalid = true;
            oldIndex = 0;
            if(null != oldStr && 0 != oldStr.Length)
            {
                Component component = property.serializedObject.targetObject as Component;
                GameObject gameObject = component.gameObject;

                StringBuilder stringBuilder = new StringBuilder();
                Transform cur = gameObject.transform;
                while(null != cur)
                {
                    stringBuilder.Insert(0, $"{cur.name}/");
                    cur = cur.parent;
                }

                string componentPath = $"{stringBuilder}{component.GetType()}";
                string objectPath = gameObject.scene.path;
                if(null == objectPath || 0 == objectPath.Length) // a prefab asset
                {
                    objectPath = gameObject.scene.name + ".prefab";
                }

                Debug.LogWarning($"In {objectPath}, component {componentPath}, property {label.text}.\nIts value has been changed from \"{oldStr}\" to \"{options[oldIndex]}\".");
            }
        }

        EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
        int newIndex = EditorGUI.Popup(position, label.text, oldIndex, options);
        EditorGUI.showMixedValue = false;
        if(oldIndexInvalid || newIndex != oldIndex)
        {
            property.stringValue = options[newIndex];
        }
    }
}

#endif

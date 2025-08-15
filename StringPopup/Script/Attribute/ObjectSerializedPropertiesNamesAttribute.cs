using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSerializedPropertiesNamesAttribute : StringPopupAttribute
{
    protected string m_objectName;

    public ObjectSerializedPropertiesNamesAttribute(string objectName)
    {
        m_objectName = objectName;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        #if UNITY_EDITOR

        object obj = targetObject.GetType().GetField(m_objectName, BindingFlags)
        .GetValue(targetObject);

        if(!(obj is UnityEngine.Object))
        {
            Debug.LogError($"{nameof(ObjectSerializedPropertiesNamesAttribute)} requires object of type {nameof(UnityEngine.Object)}");
            throw new Exception();
        }

        UnityEditor.SerializedObject serializedObject = new UnityEditor.SerializedObject(obj as UnityEngine.Object);
        UnityEditor.SerializedProperty it = serializedObject.GetIterator();

        List<string> serializedPropertiesNames = new List<string>();
        bool enterChildren = true;
        while(it.Next(enterChildren))
        {
            serializedPropertiesNames.Add(it.propertyPath);
            enterChildren = it.propertyType != UnityEditor.SerializedPropertyType.String;
        }

        m_options = serializedPropertiesNames.ToArray();

        #endif
    }
}

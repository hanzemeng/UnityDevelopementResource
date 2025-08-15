using UnityEngine;

public class MaterialPropertiesNamesAttribute : StringPopupAttribute
{
    protected string m_materialName;

    public MaterialPropertiesNamesAttribute(string materialName)
    {
        m_materialName = materialName;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        object obj = targetObject.GetType().GetField(m_materialName, BindingFlags)
        .GetValue(targetObject);

        Shader shader;
        if(obj is Material)
        {
            shader = (obj as Material).shader;
        }
        else
        {
            shader = obj as Shader;
        }

        int n = shader.GetPropertyCount();
        m_options = new string[n];
        for(int i=0; i<n; i++)
        {
            m_options[i] = shader.GetPropertyName(i);
        }
    }
}

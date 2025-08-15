using System;

public class StringArrayElementsAttribute : StringPopupAttribute
{
    protected string m_stringArrayName;
    protected Type m_classType;

    public StringArrayElementsAttribute(string stringArrayName, Type classType=null)
    {
        m_stringArrayName = stringArrayName;
        m_classType = classType;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        if(null == m_classType)
        {
            m_classType = targetObject.GetType();
        }
        m_options = m_classType.GetField(m_stringArrayName, BindingFlags)
        .GetValue(targetObject) as string[];
    }
}

using System;

public class EnumMembersNamesAttribute : StringPopupAttribute
{
    protected Type m_classType;

    public EnumMembersNamesAttribute(Type classType)
    {
        m_classType = classType;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        m_options = Enum.GetNames(m_classType);
    }
}

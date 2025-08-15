using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class TypeMembersNamesAttribute : StringPopupAttribute
{
    public enum MemberType
    {
        EVENTS = 0,
        FIELD = 1,
        METHOD = 2,
        PROPERTY = 3,
    }

    protected Type m_type;
    protected MemberType m_memberType;

    public TypeMembersNamesAttribute(Type type, MemberType memberType=MemberType.FIELD)
    {
        m_type = type;
        m_memberType = memberType;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        IEnumerable<MemberInfo> memberInfos;
        switch(m_memberType)
        {
            case MemberType.EVENTS:
            {
                memberInfos = m_type.GetEvents(BindingFlags);
                break;
            }
            case MemberType.FIELD:
            {
                memberInfos = m_type.GetFields(BindingFlags);
                break;
            }
            case MemberType.METHOD:
            {
                memberInfos = m_type.GetMethods(BindingFlags);
                break;
            }
            case MemberType.PROPERTY:
            {
                memberInfos = m_type.GetProperties(BindingFlags);
                break;
            }
            default:
            {
                throw new Exception();
            }
        }

        m_options = memberInfos.Select(i=>i.Name).ToArray();
    }
}

using UnityEngine;

public class AnimatorParametersNamesAttribute : StringPopupAttribute
{
    protected string m_animatorName;

    public AnimatorParametersNamesAttribute(string animatorName)
    {
        m_animatorName = animatorName;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        object obj = targetObject.GetType().GetField(m_animatorName, BindingFlags)
        .GetValue(targetObject);

        Animator animator = obj as Animator;
        int n = animator.parameterCount;
        m_options = new string[n];
        for(int i=0; i<n; i++)
        {
            m_options[i] = animator.parameters[i].name;
        }
    }
}

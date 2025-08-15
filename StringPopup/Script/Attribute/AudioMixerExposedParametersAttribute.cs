using UnityEngine.Audio;

public class AudioMixerExposedParametersAttribute : StringPopupAttribute
{
    protected string m_audioMixerName;
    protected string m_audioMixerExposedParametersPropertyName;

    public AudioMixerExposedParametersAttribute(string audioMixerName, string audioMixerExposedParametersPropertyName="m_ExposedParameters")
    {
        m_audioMixerName = audioMixerName;
        m_audioMixerExposedParametersPropertyName = audioMixerExposedParametersPropertyName;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        #if UNITY_EDITOR

        object obj = targetObject.GetType().GetField(m_audioMixerName, BindingFlags)
        .GetValue(targetObject);

        AudioMixer audioMixer = obj as AudioMixer;
        UnityEditor.SerializedObject serializedObject = new UnityEditor.SerializedObject(audioMixer);
        UnityEditor.SerializedProperty serializedProperty = serializedObject.FindProperty(m_audioMixerExposedParametersPropertyName);

        m_options = new string[serializedProperty.arraySize];
        for(int i=0; i<serializedProperty.arraySize; i++)
        {
            m_options[i] = serializedProperty.GetArrayElementAtIndex(i).FindPropertyRelative("name").stringValue;
        }

        #endif
    }
}

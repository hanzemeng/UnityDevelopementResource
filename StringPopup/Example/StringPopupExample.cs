using UnityEngine;
using UnityEngine.Audio;

public class StringArrayContainer
{
    private const string SABER = nameof(SABER);
    private const string ARCHER = nameof(ARCHER);
    private const string LANCER = nameof(LANCER);
    private const string RIDER = nameof(RIDER);
    private const string CASTER = nameof(CASTER);
    private const string ASSASSIN = nameof(ASSASSIN);
    private const string BERSERKER = nameof(BERSERKER);

    public static string[] staticStringArray = new string[]
    {
        SABER,
        ARCHER,
        LANCER,
        RIDER,
        CASTER,
        ASSASSIN,
        BERSERKER,
    };
}

public class StringPopupExample : MonoBehaviour
{
    // Example of a popup for a static string array.
    [StringArrayElements(nameof(StringArrayContainer.staticStringArray), typeof(StringArrayContainer))] public string stringArrayElementsStatic;

    // Example of a popup for a string array. Note that the array and the attribute must be defined in the same class.
    private const string IMPACT = nameof(IMPACT);
    private const string SLASH = nameof(SLASH);
    private const string PUNCTURE = nameof(PUNCTURE);
    private const string FIRE = nameof(FIRE);
    private const string FREEZE = nameof(FREEZE);
    private const string ELECTRICITY = nameof(ELECTRICITY);
    private const string POISON = nameof(POISON);
    public string[] stringArray = new string[]
    {
        IMPACT,
        SLASH,
        PUNCTURE,
        FIRE,
        FREEZE,
        ELECTRICITY,
        POISON,
    };
    [StringArrayElements(nameof(stringArray))] public string stringArrayElements;

    // Example of a popup for the enum members names. The Enum can be defined anywhere.
    public enum Enum
    {
        EXPLOSION,
        CORROSIVE,
        GAS,
        MAGNETIC,
        RADIATION,
        VIRAL,
    }
    [EnumMembersNames(typeof(Enum))] public string enumMembersNames;

    // Example of a popup for the scene names in the build settings. After modifying the build settings, be sure to refresh the project so the popup can be updated.
    [BuildScenesNames] public string buildScenesNames;

    // Example of a popup for the reference names in a material's shader. Note that the material and the attribute must be defined in the same class.
    // Technically this attribute takes in the name of a shader, not the name of a material that uses the shader.
    public Material material;
    [MaterialPropertiesNames(nameof(material))] public string materialPropertiesNames;

    // Example of a popup for the states names in an animator. Note that the Animator and the attribute must be defined in the same class.
    // Technically this attribute takes in the name of an animator controller, not the name of an animator that uses the animator controller.
    // One may want to specify the delimiter between the state name and the layer number. If the delimiter is a control character, only the state name appears in the popup.
    public Animator animator;
    [AnimatorStatesNames(nameof(animator), ',')] public string animatorStatesNames;

    // Example of a popup for the parameters names in an animator. Note that the Animator and the attribute must be defined in the same class.
    [AnimatorParametersNames(nameof(animator))] public string animatorParametersNames;

    // Example of popups for the members names in MonoBehaviour.
    [TypeMembersNames(typeof(MonoBehaviour), TypeMembersNamesAttribute.MemberType.FIELD)] public string typeFieldsNames;
    [TypeMembersNames(typeof(MonoBehaviour), TypeMembersNamesAttribute.MemberType.PROPERTY)] public string typePropertiesNames;
    [TypeMembersNames(typeof(MonoBehaviour), TypeMembersNamesAttribute.MemberType.EVENTS)] public string typeEventsNames;
    [TypeMembersNames(typeof(MonoBehaviour), TypeMembersNamesAttribute.MemberType.METHOD, BindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)] public string typeMethodsNames;

    // Example of popups for the exposed parameters in audioMixer. Note that the AudioMixer and the attribute must be defined in the same class.
    public AudioMixer audioMixer;
    [AudioMixerExposedParameters(nameof(audioMixer))] public string audioMixerExposedParameters;

    // Example of popups for serialized properties names in UnityEngine.Object. Note that the UnityEngine.Object and the attribute must be defined in the same class.
    [ObjectSerializedPropertiesNames(nameof(audioMixer))] public string objectSerializedPropertiesNames;
}

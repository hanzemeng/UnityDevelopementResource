using System.IO;
using UnityEngine.SceneManagement;

public class BuildScenesNamesAttribute : StringPopupAttribute
{
    public BuildScenesNamesAttribute(){}

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        m_options = new string[SceneManager.sceneCountInBuildSettings];
        for(int i=0; i<SceneManager.sceneCountInBuildSettings; i++)
        {
            m_options[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }
}

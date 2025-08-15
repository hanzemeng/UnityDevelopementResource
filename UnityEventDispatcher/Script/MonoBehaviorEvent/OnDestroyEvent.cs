using UnityEngine;

public class OnDestroyEvent : MonoBehaviourEvent
{
    [SerializeField] private bool m_ignoreDuringSceneUnload;


    private void OnDestroy()
    {
        if(m_ignoreDuringSceneUnload && !gameObject.scene.isLoaded)
        {
            return;
        }
        MonoBehaviourEventDispatch();
    }
}

using UnityEngine;
using UnityEngine.Events;

public abstract class UnityEventDispatcher : MonoBehaviour
{
    [SerializeField] protected UnityEvent<object> m_event;


    protected void Dispatch(object parameter)
    {
        try
        {
            m_event?.Invoke(parameter);
        }
        catch
        {
            Debug.LogWarning("Exception thown when invoking UnityEvent.");
        }
    }
}

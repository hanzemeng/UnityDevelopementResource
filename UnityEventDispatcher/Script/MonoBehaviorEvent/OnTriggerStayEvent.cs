using UnityEngine;

public class OnTriggerStayEvent : MonoBehaviourEvent
{
    [SerializeField] private LayerMask m_includeLayer;

    private Collider m_collider;


    protected override void MonoBehaviourEventDispatch()
    {
        Dispatch((m_collider, this));
    }
    private void OnTriggerStay(Collider collider)
    {
        if(0 == (m_includeLayer & (1 << collider.gameObject.layer)))
        {
            return;
        }

        m_collider = collider;
        MonoBehaviourEventDispatch();
    }
}

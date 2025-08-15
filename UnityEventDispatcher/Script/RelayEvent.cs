using UnityEngine;

public class RelayEvent : UnityEventDispatcher
{
    [SerializeField] private int m_relayCount;
    [SerializeField] private float m_relayFrequency;

    private float m_lastRelayTime = float.MinValue;


    public void Relay(object parameters)
    {
        if(m_relayCount <= 0 || (Time.time-m_relayFrequency) < m_lastRelayTime)
        {
            return;
        }
        m_relayCount--;
        m_lastRelayTime = Time.time;

        Dispatch(parameters);
    }
}

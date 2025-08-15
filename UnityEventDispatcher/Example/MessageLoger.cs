using UnityEngine;

public class MessageLoger : MonoBehaviour
{
    [SerializeField] private string m_message;


    public void LogMessage()
    {
        Debug.Log(m_message);
    }
}

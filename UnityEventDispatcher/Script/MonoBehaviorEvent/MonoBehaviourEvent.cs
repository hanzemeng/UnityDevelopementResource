public class MonoBehaviourEvent : UnityEventDispatcher
{
    protected virtual void MonoBehaviourEventDispatch()
    {
        Dispatch(this);
    }
}

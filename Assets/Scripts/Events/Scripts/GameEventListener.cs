using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameEventListener : Event
{
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDestroy()
    {
        Event.UnregisterListener(this);
    }

    public override void OnEventRaised(GameEvent pass)
    {
         Invoker.InvokeDelayed(RaiseEvent, 0);
    }

    private void RaiseEvent()
    {
        Response.Invoke();
    }
}

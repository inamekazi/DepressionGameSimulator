using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Based on https://devansh.space/scriptable-objects-and-event-systems

public class GameEventListener : MonoBehaviour
{
    [Tooltip("The event to listen to")]
    public GameEvent Event;

    [Tooltip("The response once the event is raised")]
    public UnityEvent Response;
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void RaiseEvent()
    {
        Response.Invoke();
    }
}

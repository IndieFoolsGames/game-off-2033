using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuicktimeControler : MonoBehaviour
{
    public UnityEvent onQuicktimeEventStarts = new UnityEvent();
    public UnityEvent onQuicktimeEventEnds = new UnityEvent();

    public void OnQuicktimeEventStarts()
    {
        onQuicktimeEventStarts.Invoke();
    }

    public void OnQuicktimeEventEnds()
    {
        onQuicktimeEventEnds.Invoke();
    }
}

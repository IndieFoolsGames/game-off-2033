using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuicktimeEventBase : MonoBehaviour
{
    public KeyControler keyControler;
    [SerializeField]
    private QuicktimeEventControler quicktimeControler;

    public void StartQuicktimeEvent()
    {
        if (quicktimeControler == null)
            return;       
        quicktimeControler.StartQuicktimeEvent(this);
    }

    public void EndQuicktimeEvent()
    {
        quicktimeControler.EndQuicktimeEvent();
    }

    public abstract IEnumerator OnQuicktimeEventStart();
}

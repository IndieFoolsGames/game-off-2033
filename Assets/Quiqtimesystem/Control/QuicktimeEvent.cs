using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuicktimeEventBase : MonoBehaviour
{
    public QuicktimeUiControler quicktimeUiControler;
    public QuicktimeControler quicktimeControler;

    public void StartQuicktimeEvent()
    {
        StartCoroutine(OnQuicktimeEventStart());
        quicktimeControler.OnQuicktimeEventStarts();
    }

    public void EndQuicktimeEvent()
    {
        StopCoroutine(OnQuicktimeEventStart());
        quicktimeControler.OnQuicktimeEventEnds();
    }

    public abstract IEnumerator OnQuicktimeEventStart();
}

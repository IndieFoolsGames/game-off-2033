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

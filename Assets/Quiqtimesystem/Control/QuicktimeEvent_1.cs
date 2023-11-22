using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuicktimeEventControler : MonoBehaviour
{
    public UnityEvent onQuicktimeEventStarts = new UnityEvent();
    public UnityEvent onQuicktimeEventEnds = new UnityEvent();

    public UIManger uIManger;
    
    public float QTEStartDelay;
    private bool active;
    private QuicktimeEventBase quicktimeEvent; 

    public bool Active
    {
        get { return active; }
    }

   
    public void StartQuicktimeEvent(QuicktimeEventBase quicktimeEventBase)
    {       
        if (uIManger != null)
            return;

        quicktimeEvent = quicktimeEventBase;

        float quicktimeStartDelay = 0f;
        if(uIManger.uIGroups.Length > 0)
        {
            UIElement uIElement = uIManger.uIGroups[0];
            if (uIElement != null && uIElement.uIControl.UseAnimation)
            {
                quicktimeStartDelay = QTEStartDelay;
            }
        }

        active = true;

        ActivateQTEUi();
        StartCoroutine(OnStartQuicktimeEvent(quicktimeStartDelay));
    }

    public void EndQuicktimeEvent()
    {
        float quicktimeStartDelay = 0f;
        if (uIManger.uIGroups.Length > 0)
        {
            UIElement uIElement = uIManger.uIGroups[0];
            if (uIElement != null && uIElement.uIControl.UseAnimation)
            {
                quicktimeStartDelay = QTEStartDelay;
            }
        }

        active = false;

        DeactivateQTEUi();
        StartCoroutine(OnEndQuicktimeEvent(quicktimeStartDelay));
    }

    private void ActivateQTEUi()
    {
        uIManger.OppenPanell(0);
    }

    private void DeactivateQTEUi()
    {
        uIManger.CloseCurentPanel();
    }

    IEnumerator OnStartQuicktimeEvent(float startDelay) 
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(quicktimeEvent.OnQuicktimeEventStart());
    }

    IEnumerator OnEndQuicktimeEvent(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        onQuicktimeEventEnds.Invoke();
    }
}


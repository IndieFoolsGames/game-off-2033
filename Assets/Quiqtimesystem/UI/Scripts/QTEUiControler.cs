using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEUiControler : MonoBehaviour
{
    public UIManger uIManger;
    public QuicktimeEventControler quicktimeEventControler;

    // Start is called before the first frame update
    void Start()
    {
        if (quicktimeEventControler == null) 
        {
            quicktimeEventControler.onQuicktimeEventStarts.AddListener(ActivateUi);
            quicktimeEventControler.onQuicktimeEventEnds.AddListener(DeactivateUi);
        }
    }

    private void ActivateUi()
    {
        uIManger.OppenPanell(0);
    }

    private void DeactivateUi()
    {
        uIManger.CloseCurentPanel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuicktimeEvent : QuicktimeEventBase
{
    private void Update()
    {

    }

    public override IEnumerator OnQuicktimeEventStart()
    {

        keyControler.SetKeyAction("action");
        yield return null;
        EndQuicktimeEvent();
    }
}

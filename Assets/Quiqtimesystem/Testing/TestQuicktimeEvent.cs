using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuicktimeEvent : QuicktimeEventBase
{
    public override IEnumerator OnQuicktimeEventStart()
    {      
       yield return null;
       EndQuicktimeEvent();
    }
}

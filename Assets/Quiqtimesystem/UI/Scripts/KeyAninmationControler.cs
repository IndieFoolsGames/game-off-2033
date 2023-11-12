using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAninmationControler : MonoBehaviour
{
    public Animator keyUiAnimator;

    public void SetState(UiKeystate uikeystate)
    {
        switch (uikeystate)
        {
            case UiKeystate.None:
                SwitchAnimation("");
                break;
            case UiKeystate.Pressed:
                SwitchAnimation("");
                break;
            case UiKeystate.Released:
                SwitchAnimation("");
                break;
            case UiKeystate.ReaptingPress:
                SwitchAnimation("");
                break;
        }
    }


    private void SwitchAnimation(string triggerName)
    {
        keyUiAnimator.SetTrigger("reset");
    }

}

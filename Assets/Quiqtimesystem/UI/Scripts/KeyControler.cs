using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControler : MonoBehaviour
{
    [SerializeField]
    private KeyManager keyManager;
    [SerializeField]
    private KeyKeyUiControlerManager keyUiControl;
    [SerializeField]
    private KeyAnimationControler animationControler;
    [SerializeField]
    private FillControler fillControler;



    public void SetKey(KeyTypeCode keyTypeCode,KeyCode key,string actionId)
    {
        ResetFill();
        keyManager.SetKey(keyTypeCode);
        SetKeyCode(key);
        SetKeyAction(actionId);
    }

    public void SetKeyAction(string actionId)
    {

        animationControler.SetKeyAnimation(actionId);
    }

    public void SetKeyCode(KeyCode keyCode) 
    {

        keyUiControl.SetKey(keyCode);
    }

    public void SetFill(float fill)
    {
        fillControler.SetTargetFill(fill);
    }

    public void ResetFill()
    {
        fillControler.ResetFill();
    }
}

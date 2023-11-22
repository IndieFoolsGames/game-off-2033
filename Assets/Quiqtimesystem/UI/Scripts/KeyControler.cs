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
    [SerializeField]
    private QuicktimeEventControler quicktimeControler;

    private void Start()
    {
        if(quicktimeControler != null) 
        {
            quicktimeControler.onQuicktimeEventEnds.AddListener(ResetFill);          
        }
    }

    public void SetKey(KeyTypeCode keyTypeCode, KeyCode key, string actionId)
    {
        if (quicktimeControler.Active)
        {           
            keyManager.SetKey(keyTypeCode);
            SetKeyCode(key);
            SetKeyAction(actionId);
        }
    }

    public void SetKeyAction(string actionId)
    {
        if (quicktimeControler.Active)       
            animationControler.SetKeyAnimation(actionId);
    }

    public void SetKeyCode(KeyCode keyCode) 
    {
        if (quicktimeControler.Active)       
            keyUiControl.SetKey(keyCode);
    }

    public void SetFill(float fill)
    {       
        if (quicktimeControler.Active)       
            fillControler.SetTargetFill(fill);
    }

    public void ResetFill()
    {
        if (quicktimeControler.Active)          
            fillControler.ResetFill();
    }
}

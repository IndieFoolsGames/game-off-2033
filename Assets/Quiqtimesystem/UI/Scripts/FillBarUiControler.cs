using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBarUiControler : MonoBehaviour
{
    public UIManger uiManager;
    public FillControler fillControler;
    private bool barIsActive = false;
  
    void Update()
    {
        if (!barIsActive && fillControler.TargetFillState > 0)
        {
            uiManager.OppenPanell(0);
            barIsActive = true;
        }
        else if(barIsActive && fillControler.TargetFillState == 0)
        {
            uiManager.ClosetPanel(0);
            barIsActive = false;
        }
    }
}

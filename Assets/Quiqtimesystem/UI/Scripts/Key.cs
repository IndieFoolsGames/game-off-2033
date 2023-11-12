using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyUiControler keyManager;

    private KeyControlerBase keyControler;
    public KeyControlerBase KeyControler
    {
        get
        {
            return keyControler;
        }
    }

    private FillControler fillControler;
    public FillControler FillControler
    {
        get
        {
            return fillControler;
        }
    }

    private void Start()
    {
        if (keyManager != null)
            keyManager.onKeyChanged += UpdateValues;
    }

    private void UpdateValues(GameObject gameObject)
    {
        KeyControlerBase keyControler = gameObject.GetComponent<KeyControlerBase>();

        if(keyControler != null)
            this.keyControler = keyControler;

        FillControler fillControler = gameObject.GetComponent<FillControler>();

        if(fillControler != null)
            this.fillControler = fillControler;
    }
}

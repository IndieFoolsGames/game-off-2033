using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUiControlGeter : MonoBehaviour
{
    public KeyTypeManager keyManager;
    private KeyBehaviorControlerBase keyControler;

    public KeyBehaviorControlerBase KeyControler
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

    private KeyCodeUiControlerBase keyCodeControler;
    public KeyCodeUiControlerBase KeyCodeControler
    {
        get
        {
            return keyCodeControler;
        }
    }

    private void Start()
    {
        if (keyManager != null)
            keyManager.onKeyChanged += UpdateValues;
    }

    private void UpdateValues(GameObject gameObject)
    {
        KeyBehaviorControlerBase keyControler = gameObject.GetComponent<KeyBehaviorControlerBase>();

        if(keyControler != null)
            this.keyControler = keyControler;

        KeyCodeUiControlerBase keyCodeUi = gameObject.GetComponent<KeyCodeUiControlerBase>();

        if (keyCodeUi != null)
            this.keyCodeControler = keyCodeUi;

        FillControler fillControler = gameObject.GetComponent<FillControler>();

        if(fillControler != null)
            this.fillControler = fillControler;
    }


}

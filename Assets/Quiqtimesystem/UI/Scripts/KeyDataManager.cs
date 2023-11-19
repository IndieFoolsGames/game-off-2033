using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDataManager : MonoBehaviour
{
    public Transform sourceObjekt;
    Dictionary<KeyTypeCode, KeyData1> data = new Dictionary<KeyTypeCode, KeyData1>();

    public Dictionary<KeyTypeCode, KeyData1> Data
    {
        get { return data; }
    }

    private void Start()
    {
        InitilizeData();
    }

    private void InitilizeData()
    {
        for (int i = 0; i < sourceObjekt.childCount; i++)
        {
            KeyData1 rootObject = sourceObjekt.GetChild(i).GetComponent<KeyData1>();

            if (rootObject != null)
            {
                data.Add(rootObject.keyTypeCode,rootObject);
            }
        }
    }
}
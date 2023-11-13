using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Display : MonoBehaviour
{    
    public string listenValue;
    public Stats statsInfo;
    public TextMeshProUGUI text;
    public UnityAction <float> valueHasChangedEverntHandler;

    // Start is called before the first frame update
    void Start()
    {
        if (statsInfo != null)
        {
            Stat stat = statsInfo.GetStat(listenValue);     
            
            stat.ValueHasChanged += UpdateValue;
            UpdateValue(statsInfo.GetValue(listenValue));
        }
    }

    public void UpdateValue(string value)
    {
        if(text != null)
        {
            text.text = value;
        }     
    }
}

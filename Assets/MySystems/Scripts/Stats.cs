using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{     
    public List<Stat> stats;
    

    public void AddStat(Stat stat)
    {
        stats.Add(stat);    
    }

    public Stat GetStat(string name)
    {
        foreach (var item in stats)
        {
            if (item.Name == name)
                return item;
        }

        return null;
    }

    public Stat GetStat(int index)
    {
        try
        {
            return stats[index];
        }
        catch (System.Exception)
        {
            Debug.LogWarning("ValueNotFound");
            return null;
        }
    }


    public string GetValue(string name)
    {
        Stat info = GetStat(name);
        if(info != null)
        {
            return info.GetValue();
        }

        Debug.LogWarning("ValueNotFound");
        return "";
    }

    public string GetValue(int index)
    {
        return GetStat(index).GetValue();      
    }

    public void SetVAlue(int index, float value)
    {
        Stat info = GetStat(index);

        if(info != null)
        {
            info.ChangeValue(value);
        }
        else
        {
            return;
        }
    }

    public void SetValue(string name, float value)
    {
        Stat info = GetStat(name);

        if (info != null)
        {
            info.ChangeValue(value);
        }
        else
        {
            return;
        }
    }
}

[System.Serializable]
public class Stat
{
    public string Name;
    [SerializeField]
    private string Value;
    public float maxValue;
    
    public event UnityAction<string> ValueHasChanged;
    
    public Stat()
    {

    }

    public Stat(string _name,string _value)
    {
        Name = _name;
        Value = _value;
    }

    public Stat(string _name, string _value,float _maxValue)
    {
        Name = _name;
        Value = _value;
        maxValue = _maxValue;
    }

    void OnValueHasChanged()
    {
        if (ValueHasChanged != null)
            ValueHasChanged.Invoke(Value);
    }

    public void ChangeValue(float value)
    {
        if(maxValue > 0)
        {
            Value = Mathf.Clamp(value, 0, maxValue).ToString();
        }
        else
        {
            Value = value.ToString();
        }

        OnValueHasChanged();
    }

    public void ChangeValue(string value)
    {                  
        Value = value;
        
        OnValueHasChanged();
    }


    public string GetValue()
    {
        return Value;
    }

    public void Reset()
    {       
        Value = "";
        maxValue = 0;
    }
}

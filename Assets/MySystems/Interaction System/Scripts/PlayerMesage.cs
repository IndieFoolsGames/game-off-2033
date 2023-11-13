using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMesage : MonoBehaviour
{
    public Animator animator;
    public Stats Stats;
    public string statName;
    private Stat mesageStat;

    private void Start()
    {
        mesageStat = Stats.GetStat(statName);
    }

    public void Mesage(string mesage)
    {
        mesageStat.ChangeValue(mesage);
        animator.SetBool("mesage",true);
    }

    public void Mesage(bool state)
    {        
        animator.SetBool("mesage", state);
    }
}

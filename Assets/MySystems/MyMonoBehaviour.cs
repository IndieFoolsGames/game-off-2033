using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected GameState gameState;

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();

        if (!gameState)
        {
           // gameState = CreateGameStat();
        }
    }

   
}

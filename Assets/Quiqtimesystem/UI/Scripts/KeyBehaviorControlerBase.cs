using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyBehaviorControlerBase : MonoBehaviour
{
    public abstract void SetKeyCode(KeyCode keyCode);
    public abstract void SetState(string action);
}

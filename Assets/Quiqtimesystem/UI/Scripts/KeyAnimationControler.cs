using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KeyAnimationControler : MonoBehaviour
{
    public KeyManager typeSeter;
    private Animator m_Animator;

    private void Start()
    {
        if (typeSeter != null)
        {
            typeSeter.onKeyHasChanged += UpdateAnimationControler;
        }
    }

    public void SetKeyAnimation(string animationId)
    {
        m_Animator.SetTrigger("reset");
        m_Animator.SetTrigger(animationId);
    }

    private void UpdateAnimationControler(KeyData1 keyData1) 
    {
        m_Animator = keyData1.keyAnimator;
    }
}

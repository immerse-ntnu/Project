using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimator : MonoBehaviour
{
    private Animator _mAnimator;
    private static readonly int TrRight = Animator.StringToHash("TrRight");
    private static readonly int TrLeft = Animator.StringToHash("TrLeft");
    private static readonly int TrUp = Animator.StringToHash("TrUp");
    private static readonly int TrDown = Animator.StringToHash("TrDown");
    private bool _ismAnimatorNotNull;

    private void Start()
    {
        _ismAnimatorNotNull = _mAnimator != null;
        _mAnimator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!_ismAnimatorNotNull) return;
        if (Input.GetKeyDown(KeyCode.D))
        {
            _mAnimator.SetTrigger(TrRight);
        }
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            _mAnimator.SetTrigger(TrLeft);
        }
            
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mAnimator.SetTrigger(TrUp);
        }
            
        if (Input.GetKeyDown(KeyCode.S))
        {
            _mAnimator.SetTrigger(TrDown);
        }
    }
}

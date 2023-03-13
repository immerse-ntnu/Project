using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Chest : MonoBehaviour
{
    // Be inside certain radius to open check
    [SerializeField] private int chestRadius;
    public Transform player;
    private Animator _mAnimator; // for animation of chest

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (chestRadius <= distanceToPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            OpenChest();
        }

    }

    private void Start()
    {
        _mAnimator = GetComponent<Animator>();
    }

    private static void OpenChest()
    {
        // _mAnimator.Play("ChestOpen"); Play chest animation
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chestRadius);
    }

}
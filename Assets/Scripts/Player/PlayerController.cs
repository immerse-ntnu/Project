using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private PlayerScriptableObject playerScriptableObject;

    [SerializeField] 
    private AudioSource audioSource;

    private Animator animator;

    private int playerIdleAnimation,
        playerWalkAnimation,
        playerJumpAnimation,
        playerAttackAnimation,
        playerDeathAnimation;

    private WaitForSeconds waitForSeconds = new WaitForSeconds(3);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerIdleAnimation = Animator.StringToHash("Player_Idle");
        playerWalkAnimation = Animator.StringToHash("Player_Walk");
        playerJumpAnimation = Animator.StringToHash("Player_Jump");
        playerAttackAnimation = Animator.StringToHash("Player_Attack");
        playerDeathAnimation = Animator.StringToHash("Player_Death");
    }

    private void Start()
    {
        audioSource.clip = playerScriptableObject.playerAttackType.attackSound;
        StartCoroutine(PlayerMoveTowards());
    }

    
}

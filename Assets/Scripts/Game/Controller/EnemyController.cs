using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float chaseRadius = 10f;
    public float speed = 2f;
    private bool _isChasing;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);

        _isChasing = distanceToPlayer < chaseRadius;

        // inside the radius do this:
        if (!_isChasing) return;
        var transform1 = transform;
        var position = transform1.position;
        var direction = (player.position - position).normalized;
        position += direction * (speed * Time.deltaTime);
        transform1.position = position;
    }

    // Visualize radius in inspector unity 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
    
}
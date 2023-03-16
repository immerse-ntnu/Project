using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{

    [SerializeField] private float checkRadius;
    private bool _inRange;
    private Transform _target;
    public LayerMask whatIsPlayer;
    public Button enter;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, checkRadius);
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(true);
        _target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        var position = transform.position;
        _inRange = Physics2D.OverlapCircle(position, checkRadius, whatIsPlayer.value);

        enter.gameObject.SetActive(_inRange);
    }
}

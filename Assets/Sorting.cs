using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Sorting : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Item"))
        {
            // Set player's sprite sorting order to be lower than the tree's
            GetComponent<SpriteRenderer>().sortingOrder = collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Item"))
        {
            // Reset player's sprite sorting order
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}

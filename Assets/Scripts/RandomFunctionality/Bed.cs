using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>())
        {
            FindAnyObjectByType<DayManager>().NewDay();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SabreGauche : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SabreD")
        {
            print("p");
        }
    }
}

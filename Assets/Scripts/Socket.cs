using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D idk = collision.GetComponentInChildren<Rigidbody2D>();
            idk.simulated = false;
            isEmpty = false;
            Debug.Log(isEmpty);
        }
    }
}

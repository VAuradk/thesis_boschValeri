using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    [SerializeField] public float enemySpeed;
    [SerializeField] public float timeAFK;
    [HideInInspector] public Rigidbody2D enemyRB;
    [HideInInspector] public bool isMoving;


    public virtual void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    public virtual void Start()
    {
        isMoving = true;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(collision);
            isMoving = false;
            StartCoroutine(waitTime());
        }

    }

    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(timeAFK);
        isMoving = true;
    }
}

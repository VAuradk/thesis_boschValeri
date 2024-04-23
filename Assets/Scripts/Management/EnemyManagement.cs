using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public float enemySpeed;
    public float timeAFK;
    [HideInInspector] public Rigidbody2D enemyRB;
    // [HideInInspector] public Transform enemyTransform;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public TagManagement tagManager;

    public virtual void Awake()
    {
        // enemyTransform = GetComponent<Transform>();
        enemyRB = GetComponent<Rigidbody2D>();
        tagManager = FindObjectOfType<TagManagement>();
    }

    public virtual void Start()
    {
        isMoving = true;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log(collision);
            isMoving = false;
            // enemyRB.velocity *= 2;
            StartCoroutine(waitTime());
        }
    }

    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(timeAFK);
        isMoving = true;
    }
}


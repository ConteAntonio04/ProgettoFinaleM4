using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + Vector3.right * Mathf.Sin(Time.time * speed) * distance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }
}

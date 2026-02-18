using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField]
    private int points = 10;
   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}

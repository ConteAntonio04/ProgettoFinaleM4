using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField]
    private float timeBonus = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddTime(timeBonus);
            Destroy(gameObject);
        }
    }
}

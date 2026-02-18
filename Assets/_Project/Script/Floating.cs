using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [Header("Floating Settings")]
    [SerializeField]
    private float floatHeight = 0.3f;
    [SerializeField]
    private float floatSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatHeight, 0);
    }
}

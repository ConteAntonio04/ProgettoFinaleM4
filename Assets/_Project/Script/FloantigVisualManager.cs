using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloantigVisualManager : MonoBehaviour
{
    [Header("Visual Float Setting")]
    [SerializeField] 
    private Transform Visual;
    [SerializeField] 
    private float floatAmount = 0.25f;
    [SerializeField] 
    private float floatSpeed = 1.5f;

    private Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = Visual.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        Visual.localPosition = startLocalPos + new Vector3(0, newY, 0);
    }
}

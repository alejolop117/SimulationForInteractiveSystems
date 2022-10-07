using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField, Range(0, 1)] float normalizedTime;
    [SerializeField] float duration = 1;

    Vector3 inicialPos;
    float currentTime = 0;

    void Start()
    {
        inicialPos = transform.position;   
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(inicialPos, targetTransform.position, normalizedTime);
        currentTime += Time.deltaTime;
    }
}

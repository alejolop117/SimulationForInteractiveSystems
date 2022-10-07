using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour {
    [SerializeField] Transform targetTransform;
    [SerializeField, Range(0, 1)] float normalizedTime;
    [SerializeField] float duration = 1;
    [SerializeField] Color initialColor;
    [SerializeField] Color finalColor;
    [SerializeField] AnimationCurve curve;

    Vector3 inicialPos;
    Vector3 finalPos;
    SpriteRenderer spriteR;
    float currentTime = 0;

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        StartTween();
    }

    
    void Update()
    {
        normalizedTime = currentTime / duration;
        //transform.position = Vector3.Lerp(inicialPos, finalPos, EaseInQuad(normalizedTime));
        transform.position = Vector3.Lerp(inicialPos, finalPos, curve.Evaluate(normalizedTime));
        spriteR.color = Color.Lerp(initialColor, finalColor, EaseInCubic(normalizedTime));
        currentTime += Time.deltaTime;

        if (normalizedTime >= 1) {
            Debug.Log("Se acabó :c");
        }

        if (Input.GetKeyDown(KeyCode.Space)) StartTween();
    }

    void StartTween() {
        currentTime = 0;
        inicialPos = transform.position;
        finalPos = targetTransform.position;
    }

    float EaseInCubic(float x) {
        return x * x * x;
    }
}

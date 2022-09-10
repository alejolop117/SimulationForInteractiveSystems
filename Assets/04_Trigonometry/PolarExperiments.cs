using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;
    [SerializeField] float angleDegSpeed = 0.1f;
    [SerializeField] float radiusSpeed = 0.001f;
    [SerializeField] float radiusLimitCam = 5f;
    [SerializeField] Transform objectTarget;
   
    void Start()
    {
        Assert.IsNotNull(objectTarget, " Object Target is requiered");
    }


    void Update()
    {
        LimitsCamera();
        angleDeg += angleDegSpeed * Time.deltaTime;
        radius += radiusSpeed * Time.deltaTime;

        objectTarget.position = PolarToCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, PolarToCartesian(radius, angleDeg));
               
    }

    private Vector3 PolarToCartesian(float radius, float angle) {

        //Se convierten las coordenadas cartesianas a polares
        float x = radius * Mathf.Cos(angleDeg * Mathf.Deg2Rad); // x = r.cos(a)
        float y = radius * Mathf.Sin(angleDeg * Mathf.Deg2Rad); // y = r.sin(a)

        return new Vector3(x, y, 0);
    }

    private void LimitsCamera() {

        if(radius >= radiusLimitCam) {
            radiusSpeed *= -1;
        }
    }
}

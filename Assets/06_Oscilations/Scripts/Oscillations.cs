using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    enum OscilationMode { diagonal, chaos }
    [SerializeField] OscilationMode oscilationMode;
    [SerializeField] float amplitude = 1;
    [SerializeField] float period = 1;
    Vector3 initialPos;
    

    private void Start() {
        initialPos = transform.position;
    }

    void Update()
    {
        if(oscilationMode == OscilationMode.diagonal) {
            DiagonalOscilation();
        }
        else if(oscilationMode == OscilationMode.chaos) {
            ChaosOscilation();
        }
    }

    void DiagonalOscilation() {
        float x = amplitude * Mathf.Sin(2f * Mathf.PI * (Time.time / period)); //Se define el comportamiento
        transform.position = initialPos + new Vector3(x, x, 0); // Direcci�n donde se va a aplicar-> x,y = diagonal
    }

    void ChaosOscilation() {
        float x = Mathf.Sin(Time.time) + Mathf.Sin(2*Time.time) + Mathf.Sin(4*Time.time)+Mathf.Cos(3*Time.time)+
            Mathf.Cos(10 * Time.time); //Comportamiento random
        transform.position = initialPos + new Vector3(x, 0, 0); // Solo en x
    }
}
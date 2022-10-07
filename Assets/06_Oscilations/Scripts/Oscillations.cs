using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    enum OscillationMode { horizontal, vertical, diagonal, chaos1, chaos2, chaos3 }

    [SerializeField] OscillationMode oscilationMode;
    [SerializeField] float amplitude = 1;
    [SerializeField] float period = 1;
    Vector3 initialPos;
    

    private void Start() {
        initialPos = transform.position;
    }

    void Update()
    {
        if(oscilationMode == OscillationMode.diagonal) {
            DiagonalOscillation();
        }
        else if(oscilationMode == OscillationMode.chaos1) {
            ChaosOscillation();
        }
        else if (oscilationMode == OscillationMode.chaos2) {
            ChaosOscillation2();
        }

        else if (oscilationMode == OscillationMode.chaos3) {
            ChaosOscillation3();
        }

        else if (oscilationMode == OscillationMode.horizontal) {
            HorizontalOscillation();
        }

        else if (oscilationMode == OscillationMode.vertical) {
            VerticalOscillation();
        }
    }

    void HorizontalOscillation() {
        float x = amplitude * Mathf.Sin(2f * Mathf.PI * (Time.time / period)); //Se define el comportamiento
        transform.position = initialPos + new Vector3(x, 0, 0);
    }

    void VerticalOscillation() {
        float x = amplitude * Mathf.Sin(2f * Mathf.PI * (Time.time / period)); //Se define el comportamiento
        transform.position = initialPos + new Vector3(0, x, 0);
    }
    void DiagonalOscillation() {
        float x = amplitude * Mathf.Sin(2f * Mathf.PI * (Time.time / period)); //Se define el comportamiento
        transform.position = initialPos + new Vector3(x, x, 0); // Dirección donde se va a aplicar-> x,y = diagonal
    }

    void ChaosOscillation() {
        float x = Mathf.Sin(Time.time) + Mathf.Sin(2*Time.time) + Mathf.Sin(4*Time.time)+Mathf.Cos(3*Time.time)+
            Mathf.Cos(10 * Time.time); //Comportamiento random
        transform.position = initialPos + new Vector3(x, 0, 0); // Solo en x
    }

    void ChaosOscillation2() {
        float x = Mathf.Cos(Time.time) + Mathf.Tan(2 * Time.time) + Mathf.Cos(4 * Time.time) + Mathf.Sin(3 * Time.time) +
            Mathf.Sin(10 * Time.time); //Comportamiento random
        transform.position = initialPos + new Vector3(x, 0, 0); // Solo en x
    }

    void ChaosOscillation3() {
        float x = Mathf.Sin(Time.time)  + Mathf.Cos(4 * Time.time) + Mathf.Cos(3 * Time.time) +
            Mathf.Cos(10 * Time.time) + Mathf.Tan(3 * Time.time); //Comportamiento random
        transform.position = initialPos + new Vector3(x, x, 0); // Solo en x
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    enum OscilationMode { horizontal, vertical, diagonal, chaos }
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
            DiagonalOscillation();
        }
        else if(oscilationMode == OscilationMode.chaos) {
            ChaosOscillation();
        }

        else if (oscilationMode == OscilationMode.horizontal) {
            HorizontalOscillation();
        }

        else if (oscilationMode == OscilationMode.vertical) {
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
}

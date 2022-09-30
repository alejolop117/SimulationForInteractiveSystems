using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphs : MonoBehaviour
{
    [SerializeField] GameObject m_prefab;
    [SerializeField] int m_totalPoints = 10;
    [SerializeField] float distanceFactor = 1;
    [SerializeField] float amplitude = 1;
    GameObject[] allPoints;

    void Start()
    {
        allPoints = new GameObject[m_totalPoints];
        for(int i =0; i < m_totalPoints; i++) {
            allPoints[i] = Instantiate(m_prefab, transform);
        }
    }

    
    void Update()
    {
        
        for (int i = 0; i < allPoints.Length; i++) {
            float x = i * distanceFactor; //Crear las bolitas en posici�n distinta
            //Se suma el Time.time para generar el movimiento de la gr�fica
            float y = Mathf.Sin(x + Time.time) * amplitude; //En Y se define el comportamiento de la funci�n
            allPoints[i].transform.localPosition = new Vector3(x, y, 0);
            //El localPos se referencia con respecto al padre.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphs : MonoBehaviour
{
    [SerializeField] GameObject m_prefab;
    [SerializeField] int m_totalPoints = 10;
    [SerializeField] float distanceFactor = 1;
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
            float x = i * distanceFactor; //Crear las bolitas en posición distinta
            //Se suma el Time.time para generar el movimiento de la gráfica
            float y = Mathf.Sin(x + Time.time); //En Y se define el comportamiento de la función
            allPoints[i].transform.position = new Vector3(x, y, 0);
        }
    }
}

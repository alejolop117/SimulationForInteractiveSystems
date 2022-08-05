using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    [SerializeField] MyVector2D vectorOne;
    MyVector2D a = new MyVector2D(2, 3);
    MyVector2D b = new MyVector2D(4, 5);
    MyVector2D r;
    
   
    void Start()
    {
        r = a + b;

        Debug.Log(r);
    }

 
    void Update()
    {
        vectorOne.Draw(Color.blue);
        r.Draw(Color.red);
    }
}

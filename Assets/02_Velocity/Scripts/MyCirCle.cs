using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCirCle : MonoBehaviour
{
    [SerializeField] MyVector2D displacement;
    [SerializeField] Camera mycamera;
    MyVector2D position;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }


    void Update()
    {
        position.Draw(Color.black);
        displacement.Draw(position, Color.red);
    }

    public void Move() { // Evita que el objeto se salga de los límites de la cámara.
        position = position + displacement;
        
        if(position.x > mycamera.orthographicSize) {
            displacement.x *= -1; //Para cambiar la dirección
            position.x = mycamera.orthographicSize; //re ubica al objeto en el límite de la cámara.
        }

        else if(position.x < -mycamera.orthographicSize) {
            displacement.x *= -1;
            position.x = -mycamera.orthographicSize;
        }

        else if (position.y > mycamera.orthographicSize) {
            displacement.y *= -1;
            position.y = mycamera.orthographicSize;
        }

        else if (position.y < -mycamera.orthographicSize) {
            displacement.y *= -1;
            position.y = -mycamera.orthographicSize;
        }

        transform.position = new Vector3(position.x, position.y);
    }
}

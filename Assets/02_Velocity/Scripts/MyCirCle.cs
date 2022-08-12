using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCirCle : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    [SerializeField] MyVector2D velocity;
    MyVector2D position;
    MyVector2D displacement;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }


    void Update()
    {
        position.Draw(Color.black);
        velocity.Draw(position, Color.red);
        Move();
    }

    public void Move() { 
        position = position + velocity * Time.deltaTime; // Time.deltaTime(1 s/ x FPS)
        // Evita que el objeto se salga de los límites de la cámara.
        if (position.x > mycamera.orthographicSize) { 
            velocity.x *= -1; //Para cambiar la dirección
            position.x = mycamera.orthographicSize; //re ubica al objeto en el límite de la cámara.
        }

        else if(position.x < -mycamera.orthographicSize) {
            velocity.x *= -1;
            position.x = -mycamera.orthographicSize;
        }

        else if (position.y > mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = mycamera.orthographicSize;
        }

        else if (position.y < -mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = -mycamera.orthographicSize;
        }

        transform.position = new Vector3(position.x, position.y);
    }
}

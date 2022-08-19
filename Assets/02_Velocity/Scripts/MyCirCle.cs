using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCirCle : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    [SerializeField] MyVector2D  aceleration;
    [SerializeField] MyVector2D velocity;
    [SerializeField, Range(0.0f, 1.0f)] float dampingFactor = 0.9f;
    MyVector2D position;
    //MyVector2D displacement;
    int currentAceleration = 0;
    readonly MyVector2D[] directions = new MyVector2D[4] { 
        new MyVector2D(0, -9.8f), new MyVector2D(9.8f, 0),
        new MyVector2D(0, 9.8f), new MyVector2D(-9.8f, 0),

    };

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);

    }

    private void FixedUpdate() {
        Move();
    }


    void Update()
    {
        position.Draw(Color.black);
        velocity.Draw(position, Color.red);
        aceleration.Draw(position, Color.green);

        if (Input.GetKeyDown(KeyCode.Space)) { // Cambiar la dirección de la aceleración.
            aceleration = directions[(currentAceleration++) % directions.Length];
            velocity *= 0;
        }
        
    }

    public void Move() {

        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; // Time.deltaTime(1 s/ x FPS)


        // Evita que el objeto se salga de los límites de la cámara.
        if (position.x > mycamera.orthographicSize) { 
            velocity.x *= -1; //Para cambiar la dirección
            position.x = mycamera.orthographicSize; //re ubica al objeto en el límite de la cámara.
            velocity *= 0.9f; //damping factor
        }

        else if(position.x < -mycamera.orthographicSize) {
            velocity.x *= -1;
            position.x = -mycamera.orthographicSize;
            velocity *= 0.9f; //damping factor
        }

        else if (position.y > mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = mycamera.orthographicSize;
            velocity *= 0.9f; //damping factor
        }

        else if (position.y < -mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = -mycamera.orthographicSize;
            velocity *= 0.9f; //damping factor
        }

        

        transform.position = new Vector3(position.x, position.y);
    }
}

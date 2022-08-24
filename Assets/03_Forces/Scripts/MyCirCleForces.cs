using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCirCleForces : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    [SerializeField] MyVector2D  aceleration;
    [SerializeField] MyVector2D velocity;
    [SerializeField] MyVector2D force;
    [SerializeField] float mass = 1f;
    [SerializeField, Range(0.0f, 1.0f)] float dampingFactor = 0.9f;
    MyVector2D position;
    MyVector2D weight;

    [Header ("Forces")]
    [SerializeField] MyVector2D wind;
    [SerializeField] MyVector2D gravity;
    MyVector2D netForce;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);

    }

    private void FixedUpdate() {
        //netForce = new MyVector2D(0, 0);
        aceleration = new MyVector2D(0, 0); // Para q no se acumulen las Fuerzas
        weight = mass * gravity;
        ApplyForce(wind);
        ApplyForce(weight);
        Move();
    }


    void Update()
    {
        position.Draw(Color.black);
        velocity.Draw(position, Color.red); //Pos para q no dibuje desde V0 sino desde el vector.
        aceleration.Draw(position, Color.green);
        
    }

    public void Move() {

        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; // Time.deltaTime(1 s/ x FPS)


        // Evita que el objeto se salga de los límites de la cámara.
        if (position.x > mycamera.orthographicSize) { 
            velocity.x *= -1; //Para cambiar la dirección
            position.x = mycamera.orthographicSize; //re ubica al objeto en el límite de la cámara.
            velocity *= dampingFactor; 
        }

        else if(position.x < -mycamera.orthographicSize) {
            velocity.x *= -1;
            position.x = -mycamera.orthographicSize;
            velocity *= dampingFactor; 
        }

        else if (position.y > mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = mycamera.orthographicSize;
            velocity *= dampingFactor; 
        }

        else if (position.y < -mycamera.orthographicSize) {
            velocity.y *= -1;
            position.y = -mycamera.orthographicSize;
            velocity *= dampingFactor; 
        }

        

        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force) { //7:04 y 7:33
        aceleration += force / mass;
    }
}

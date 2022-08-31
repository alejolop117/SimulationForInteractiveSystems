using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidFriction : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    [SerializeField] MyVector2D  acceleration;
    [SerializeField] MyVector2D velocity;
    [SerializeField] float mass = 1f;
    [SerializeField] float rho = 1; //Densidad
    [SerializeField] float fluidDragK = 1; //Coeficiente de Fricción
    [SerializeField, Range(0.0f, 1.0f)] float dampingFactor = 0.9f;
    MyVector2D position;
    MyVector2D weight;

    [Header ("Forces")]
    [SerializeField] MyVector2D wind;
    [SerializeField] MyVector2D gravity;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate() {
        //netForce = new MyVector2D(0, 0);
        acceleration = new MyVector2D(0, 0); // Para q no se acumulen las Fuerzas -> Reset acc.
        // Peso
        weight = mass * gravity;
        ApplyForce(weight);
        //Aire
        ApplyForce(wind);

        ApplyFluidFriction();

        Move();
    }


    void Update()
    {
        position.Draw(Color.black);
        velocity.Draw(position, Color.red); //Pos para q no dibuje desde V0 sino desde el vector.
        acceleration.Draw(position, Color.green);
    }

    public void Move() {

        velocity = velocity + acceleration * Time.fixedDeltaTime;
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

    private void ApplyForce(MyVector2D force) { 
        acceleration += force / mass;
    }

    private void ApplyFluidFriction() {
        if (transform.localPosition.y <= 0) {
            float frontalArea = transform.localScale.x; // SOLO Por que coincide con la escala del mundo
            float velocityMagnitude = velocity.magnitude;
            float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude * frontalArea * fluidDragK;
            MyVector2D frictionF = scalarPart * velocity.normalized;
            ApplyForce(frictionF);
        }
    }
}

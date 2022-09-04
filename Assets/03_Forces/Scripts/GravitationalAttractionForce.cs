using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttractionForce : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] MyVector2D  acceleration;
    [SerializeField] MyVector2D velocity;
    public MyVector2D position;
    [SerializeField] float mass = 1f;

    [SerializeField] GravitationalAttractionForce planetTwo;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);

    }

    private void FixedUpdate() {
        //netForce = new MyVector2D(0, 0);
        acceleration = new MyVector2D(0, 0); // Para q no se acumulen las Fuerzas -> Reset acc.

        ApplyForce(AttractionForce());

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

        if(velocity.magnitude >= 10f) {
            velocity.Normalize();
            velocity *= 10;
        }
        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force) { 
        acceleration += force / mass;
    }

    private MyVector2D AttractionForce() {
        MyVector2D r = planetTwo.position - position; // r: distancia que separa las masas
        float rMagnitude = r.magnitude; // En la ecuación, es la magnitud de ese V^2
        MyVector2D f = r.normalized * (planetTwo.mass * mass / rMagnitude * rMagnitude); // Fg = Ur * ((m1*m2/r^2)
        // r.normalized, es un vector unitario que posee la misma dirección de actuación de la fuerza aunque de sentido contrario
        // r.normalized = Ur
        return f;
    }
}

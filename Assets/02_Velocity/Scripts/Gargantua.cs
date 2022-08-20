using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargantua : MonoBehaviour
{
    [SerializeField] MyVector2D velocity;
    [SerializeField] Transform gargantuaLocator;//6:48
    [SerializeField] Camera myCam;
    MyVector2D position;
    MyVector2D accelaration;
    
    

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
        velocity.Draw(position, Color.blue); //Pos para q no dibuje desde V0 sino desde el vector.
        accelaration.Draw(position, Color.green);

        MyVector2D myPos = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D gargantuaPos = new MyVector2D(gargantuaLocator.position.x, gargantuaLocator.position.y);
        accelaration = gargantuaPos - myPos;
     
    }

    public void Move() {

        velocity = velocity + accelaration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; // Time.deltaTime(1 s/ x FPS)
        transform.position = new Vector3(position.x, position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargantua : MonoBehaviour
{
    [SerializeField] MyVector2D velocity;
    [SerializeField] Transform gargantuaPos;//6:48
    MyVector2D position;
    

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
     
    }

    public void Move() {

        position = position + velocity * Time.fixedDeltaTime; // Time.deltaTime(1 s/ x FPS)
    }
}

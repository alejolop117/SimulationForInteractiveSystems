using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public struct MyVector2D { //Se puede usar Class o Struct

    public float x;
    public float y;

    public MyVector2D(float x, float y) {
        this.x = x;
        this.y = y;
    }


    public static MyVector2D operator +(MyVector2D a, MyVector2D b) { //Suma

        return new MyVector2D(a.x + b.x, a.y + b.y);
    }

    /*public MyVector2D Sub(MyVector2D a) { // Nuestra X,Y menos el X,Y q recibimos -> Resta

        return new MyVector2D(x - a.x, y - a.y);       
    }*/

    public  static MyVector2D operator -(MyVector2D a, MyVector2D b) { //Resta

        return new MyVector2D(a.x - b.x, a.y - b.y);
    }

    /*public MyVector2D Scale(float a) {  // Vector * escalar  -> a<x,y>

        return new MyVector2D(x * a, y * a);
    }*/

    public static MyVector2D operator *(MyVector2D a, float b) {
        return new MyVector2D(a.x * b, a.y * b);
    }

    public static MyVector2D operator *(float b, MyVector2D a) {
        return new MyVector2D(a.x * b, a.y * b);
    }


    public MyVector2D Mult(MyVector2D a) { //Producto punto

        return new MyVector2D(x * a.x, y * a.y);
    }

    public static MyVector2D operator /(MyVector2D a, float b) {
        return new MyVector2D(a.x / b, a.y / b);
    }

    public override string ToString() {

        return $"[{x}, {y}]";  //TO convert our data on text.
    }

    public void Draw(Color color) {
        Debug.DrawLine(Vector3.zero, new Vector3(x,y,0), color); // Vector inicial, mi vector, color del vector
    }

    public void Draw(MyVector2D newOrigin, Color color) {

        Vector3 start = new Vector3(newOrigin.x, newOrigin.y);
        Vector3 end = new Vector3(newOrigin.x + x, newOrigin.y + y);
        Debug.DrawLine(start, end, color);
            
    }

}



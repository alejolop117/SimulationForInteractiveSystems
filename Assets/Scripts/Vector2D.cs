using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2D : MonoBehaviour
{
    [SerializeField] MyVector2D vectorOne, vectorTwo;
    [Range(0f, 1f)] public float range;

    //[SerializeField] Color colorOne, colorTwo;

    void Update() {

        vectorOne.Draw(Color.red);
        //vectorTwo.Draw(vectorOne, Color.green);
        vectorTwo.Draw(Color.green);

        MyVector2D vectorThree = (vectorTwo - vectorOne) * range;
        MyVector2D vectorFour = vectorOne + vectorThree;
        //MyVector2D vectorThree = (vectorOne + vectorTwo) *range;

        vectorThree.Draw(Color.yellow);
        vectorThree.Draw(vectorOne,Color.yellow);
        vectorFour.Draw(Color.white);
    }
}

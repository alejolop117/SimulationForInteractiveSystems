using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
   

    void Update()
    {
        Vector3 mosuePos = GetWorldMousePosition();
        //Los objetos miran al puntero desde <0,0>
        /*float angle = Mathf.Atan2(mosuePos.y, mosuePos.x) - Mathf.PI / 2;
        transform.rotation = Quaternion.Euler(0, 0, 0);*/

        //Los objetos miran al puntero de manera independiente:
        Vector3 lookAtMouse = mosuePos - transform.position;
        float angle = Mathf.Atan2(lookAtMouse.y, lookAtMouse.x) - Mathf.PI / 2;
        RotateZ(angle);
    }

    private Vector4 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians) {

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}

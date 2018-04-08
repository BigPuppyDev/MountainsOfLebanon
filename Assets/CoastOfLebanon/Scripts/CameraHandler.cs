using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{    
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] float shiftSpeed = 10f;
    float speed;
    Vector3 direction;

    void Start()
    {
        direction = new Vector3(0.0f, 0.0f, 0.0f);
        speed = baseSpeed;
    }

    void Update ()
    {
        MoveCamera();
        HandleTransparency();
	}

    private void HandleTransparency()
    {
        if(gameObject != Camera.main.gameObject)
        {
            
        }
    }

    private void MoveCamera()
    {
        CheckShift();
        MoveHorizontalAxis();
        MoveVerticalAxis();
    }

    private void CheckShift()
    {
        speed = Input.GetKey(KeyCode.LeftShift) ? shiftSpeed : baseSpeed;
    }

    private void MoveHorizontalAxis()
    {
        direction.x = Input.GetAxis("Horizontal") * transform.forward.z * speed;
        direction.y = 0f;
        direction.z = -Input.GetAxis("Horizontal") * transform.forward.x * speed;
        transform.position += direction;
    }

    private void MoveVerticalAxis()
    {
        direction.x = Input.GetAxis("Vertical") * transform.forward.x * speed;
        direction.y = 0f;
        direction.z = Input.GetAxis("Vertical") * transform.forward.z * speed;        
        transform.position += direction;
    }
}

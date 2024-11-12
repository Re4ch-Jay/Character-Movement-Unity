using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRotation;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;    
    [SerializeField] private float JumpForce;

    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayerCamera();
        MovePlayer();
    }

    void MovePlayer(){
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if(Input.GetKeyDown(KeyCode.Space)){
            PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void MovePlayerCamera(){
        xRotation -= PlayerMouseInput.y * Sensitivity;
        transform.Rotate(0, PlayerMouseInput.x * Sensitivity, 0);
        PlayerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}

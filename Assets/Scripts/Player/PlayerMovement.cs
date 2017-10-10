using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody rigid;

    private Vector3 movementVertical;
    private Vector3 movementHorizontal;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = InputManager.Get_MovementInput.x;
        float vertical = InputManager.Get_MovementInput.y;
        
        Vector3 movement_vertical = transform.forward * vertical;
        Vector3 movement_horizontal = transform.right * horizontal;

        movementVertical = movement_vertical;
        movementHorizontal = movement_horizontal;

    }

    private void FixedUpdate()
    {
        horizontalMovement();
        verticalMovement();
    }

    private void verticalMovement()
    {
        movementVertical = movementVertical * movementSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + movementVertical);
    }

    private void horizontalMovement()
    {
        movementHorizontal = movementHorizontal * movementSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + movementHorizontal);
        
    }
}

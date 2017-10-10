using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static Vector3 movementInput;
    public static Vector3 Get_MovementInput { get { return movementInput; } }

    private static float mouseInputX;
    public static float Get_MouseInputX { get { return mouseInputX; } }

    private static float mouseInputY;
    public static float Get_MouseInputY { get { return mouseInputY; } }

    private static bool key_e;
    public static bool Get_KeyE { get { return key_e; } }

    private KeyCode keyE = KeyCode.E;

    private void Update()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        key_e = Input.GetKeyDown(keyE);

        if (Input.GetKey(KeyCode.Space))
            Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.V))
            Cursor.lockState = CursorLockMode.None;
    }
}

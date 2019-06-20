using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//clase creada para que pueda administrar varias plataformas solo hay que agregar los inputs de cada plataforma(Consolda,PC,Movil)
public static class InputManager
{
    public static float GetAxisHorizontal() {

        float x = Input.GetAxis("Horizontal");

        return x;
    }

    public static float GetAxisVertical()
    {

        float y = Input.GetAxis("Vertical");

        return y;
    }

    public static Vector3 MousePosition() {

        return Input.mousePosition;
    }

    public static bool MouseButtonDown(int i) {

        if (i == 0 || i == 1)
        {
            return Input.GetMouseButton(i);
        }

        else
            return false;
    }

    public static bool GetKey(string c)
    {
        if (c.Length == 1)
        {
            return Input.GetKeyDown(c.ToString());
        }

        else
            return false;
    }

    public static float MouseX() {

        return Input.GetAxis("Mouse X");
    }

    public static float MouseY()
    {

        return Input.GetAxis("Mouse Y");
    }
}

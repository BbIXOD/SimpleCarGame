using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInput : MonoBehaviour, IInput
{
    public int Acceleration => (int)Input.GetAxis("Horizontal");
    public bool LeftPressed { get; private set; }
    public bool RightPressed { get; private set; }

    private void Update() {
        LeftPressed = Input.GetKey(KeyCode.A);
        RightPressed = Input.GetKey(KeyCode.D);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneInput : MonoBehaviour, IInput
{
    public int Acceleration => (LeftPressed ? -1 : 0) + (RightPressed ? 1 : 0);
    public bool LeftPressed { get; private set; }
    public bool RightPressed { get; private set; }

    private void Update() {
        LeftPressed = RightPressed = false;

        for (int i = 0; i < Input.touchCount; i++) {
            var touch = Input.GetTouch(i);

            if (touch.position.x < Screen.width / 2) {
                LeftPressed = true;
            }
            else {
                RightPressed = true;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMover : MonoBehaviour
{
    //place object with on place from which you want to move the wheels
    private Rigidbody2D _rb;
    private IInput _input;
    private EngineData _carData;

    private void Start() {
        _carData = GetComponentInParent<EngineData>();
        _rb = GetComponent<Rigidbody2D>();
        _input = Boot.Instance.input;
    }

    private void FixedUpdate() {
        _rb.AddTorque(-_input.Acceleration * _carData.acceleration * Time.fixedDeltaTime);
        _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, -_carData.speed, _carData.speed);
    }
}

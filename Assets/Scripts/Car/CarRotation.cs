using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private IInput _input;
    [SerializeField]private float rotationAmount;
    private AirChecker _checker;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _input = Boot.Instance.input;
        _checker = Boot.Instance.airChecker;
    }

    private void FixedUpdate() {
        if (_checker.IsOnGround()) return;
        _rb.AddTorque(_input.Acceleration * rotationAmount * Time.fixedDeltaTime);
    }
}

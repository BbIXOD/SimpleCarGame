using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flips : MonoBehaviour
{
    private const int ControlRotation = 1;

    [SerializeField]private int value = 1000;

    private int _state = 0;
    private bool _flipStarted;

    private Transform _player;

    private void Awake() {
        _player = transform;
    }

    private void FixedUpdate() {
        var next = Math.Sign((int)_player.rotation.y / ControlRotation);

        if (_flipStarted && next == 0) {
            Score.score += value;
            _flipStarted = false;
        }

        _flipStarted = _state == -next && next != 0;
        _state = next;

    }
}

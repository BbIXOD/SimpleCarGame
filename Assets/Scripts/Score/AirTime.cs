using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTime : MonoBehaviour
{
    [SerializeField]private int value = 10;
    [SerializeField]private float startDelay = 2;
    [SerializeField]private float delay = 1; //TODO: add big and insane air time

    private AirChecker _checker;

    private float _curTime;
    private bool _starPassed;

    private void Start() {
        _checker = Boot.Instance.airChecker;
    }

    private void FixedUpdate() {
        if (_checker.IsOnGround()) {
            _starPassed = false;
            _curTime = 0;
            return;
            }
        _curTime += Time.fixedDeltaTime;

        if (_curTime < (_starPassed ? startDelay : delay)) return;

        Score.score += value;
        _starPassed = true;
    }
}

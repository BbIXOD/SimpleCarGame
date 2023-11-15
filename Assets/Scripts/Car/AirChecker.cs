using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirChecker : MonoBehaviour
{
    [SerializeField]private Rigidbody2D[] collCheckers;

    public bool IsOnGround() {
        foreach (var checker in collCheckers) {
            if (!checker.IsTouchingLayers(1)) continue;
            return true;
        }
        return false;
    }
}

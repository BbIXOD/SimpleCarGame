using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Vector2 offset;
    private Vector3 _realOffset;
    public float speed;
    public Transform follower, followed;
    private float zPos;

    private void Awake() {
        zPos = follower.position.z; //i decided to keep it by default mostly because of camera
        _realOffset = (Vector3)offset;
    }
    void Update()
    {
        var newPos = followed.position + _realOffset;
        newPos.z = zPos;
        follower.position = Vector3.Lerp(follower.position, newPos, speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private const float 
    Height = 5,
    MaxHitDistance = 5;

    [SerializeField]private float outerDistance;
    [SerializeField]private float innerDistance;
    [SerializeField]private float heightOffset;
    [SerializeField]private GameObject[] collectables; // TODO: make function which will tell how many collectables to put
    [SerializeField]private float startXPos;
    private Vector3 _lastPos = Vector3.zero;

    private void Start() {
        _lastPos.y = Height;
        _lastPos.x = startXPos;
    }

    //puts money in front of last position
    //TODO: make it work also if car moves backward
    public void Put() {
        while (true) {
            if(!IsGenerated(_lastPos) 
                || !IsGenerated(_lastPos + new Vector3(innerDistance * collectables.Length, 0, 0))) break;
            
            foreach (var collectable in collectables) {
                var hitInfo = Physics2D.Raycast(_lastPos, Vector2.down, MaxHitDistance);

                var spawnPos = hitInfo.point;
                spawnPos.y += heightOffset;

                Instantiate(collectable, spawnPos, Quaternion.identity);

                _lastPos.x += innerDistance;
            }

            _lastPos.x += outerDistance;
        }
    }

    private bool IsGenerated(Vector3 pos) {
        return Physics2D.Raycast(pos, Vector2.down, MaxHitDistance).collider != null;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteShapeController), typeof(EdgeCollider2D))]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private int length;
    [SerializeField, Range(0, 10)] private float scaleY; //i decided to remove scaleX to simplify code
    [SerializeField, Range(0, 1)] private float smoothness;
    [SerializeField, Range(0, 2)] private float perlinScale;
    [SerializeField, Range(0, 1000)] float offset;
    [SerializeField]private bool usePosition;
    [SerializeField] private float height;

    private Vector3 
    _lastPos,
    _objectPos;
    private Transform _myTransform;
    private float _noise;
    private EdgeCollider2D _collider;

    private void Awake() {
        _myTransform = transform;
        _objectPos = _myTransform.position;
        _collider = GetComponent<EdgeCollider2D>();

        spriteShapeController.spline.Clear();

        for (int i = 0; i < length; i++) {
            _noise = Mathf.PerlinNoise(0, (i + (usePosition ? _objectPos.x : 0)) * perlinScale + offset);
            _lastPos = Vector3.zero;
            _lastPos.x += i;
            _lastPos.y +=  _noise * scaleY;
            
            spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if ( i != 0 && i != length - 1) {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, scaleY * smoothness * Vector3.left);
                spriteShapeController.spline.SetRightTangent(i, scaleY * smoothness * Vector3.right);
            }
        }

        spriteShapeController.spline.InsertPointAt(length, new Vector3(_lastPos.x, _objectPos.y - height));
        spriteShapeController.spline.InsertPointAt(length + 1, new Vector3(0, _objectPos.y - height));

        UpdateEdgeCollider();
    }

    private void UpdateEdgeCollider() //or make it in same function?
    {
        _collider.Reset();

        Vector2[] points = new Vector2[spriteShapeController.spline.GetPointCount()];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = spriteShapeController.spline.GetPosition(i);
        }

        _collider.points = points;
    }

}

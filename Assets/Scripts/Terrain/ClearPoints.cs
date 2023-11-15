using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class ClearPoints : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;

    private void OnValidate() {
        spriteShapeController.spline.Clear();
    }
}

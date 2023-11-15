using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelShower : MonoBehaviour
{
    private FuelHandler _fuel;
    [SerializeField]private GameObject fillSquare;
    private Image _fillRenderer;
    private Transform _fillTransform;

    [SerializeField]private Gradient fillColor;

    private void Start() {
        _fuel = Boot.Instance.fuelHandler;

        _fillRenderer = fillSquare.GetComponent<Image>();
        _fillTransform = fillSquare.transform;
    }

    private void Update() {
        _fillRenderer.color = fillColor.Evaluate(_fuel.Fuel);
        _fillTransform.localScale = new Vector3(_fuel.Fuel, 1, 1);
    }
}

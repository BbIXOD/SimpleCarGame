using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelHandler : MonoBehaviour
{
    public static UnityEvent OnFuelGet = new();

    // value might be from 0 to 1
    public const float MaxFuel = 1;
    public float Fuel { get; private set; } = 1;
    [SerializeField]private float fuelDecreaseRate;

    private void Awake() {
        OnFuelGet.AddListener(Refill);
    }

    private void FixedUpdate() {
        Fuel -= fuelDecreaseRate * Time.fixedDeltaTime;

        if (Fuel >= 0) return;

        GameEnder.OnEndGame.Invoke();
    }

    public void Refill() {
        Fuel = MaxFuel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalManager : MonoBehaviour
{
    private IInput _input;
    [SerializeField]private PedalAppearence accel;
    [SerializeField]private PedalAppearence brake;

    private void Start()
    {
        _input = Boot.Instance.input;
    }

    // Update is called once per frame
    void Update()
    {
        brake.SetState(_input.LeftPressed);
        accel.SetState(_input.RightPressed);
    }
}

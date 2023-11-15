using System;
using UnityEngine;

public class Boot : MonoBehaviour // i am trying to not to make it a god object
{                                 //also this is singleton handler
    [SerializeField]private Vector3 startPos;

    public GameObject player;
    [NonSerialized]public IInput input;
    [NonSerialized]public FuelHandler fuelHandler;
    [NonSerialized]public Score score;
    [NonSerialized]public AirChecker airChecker;

    public static Boot Instance { get; private set; }

    private void Awake() { //zenject would be better
        Instance = this;
        input = Input.touchSupported ? gameObject.AddComponent<PhoneInput>() :
            gameObject.AddComponent<ComputerInput>();
        fuelHandler = GetComponent<FuelHandler>();
        score = new Score();
        
        player = Instantiate(player, startPos, Quaternion.identity);

        airChecker = player.GetComponent<AirChecker>();
        GetComponent<Follow>().followed = player.transform;
    }
}

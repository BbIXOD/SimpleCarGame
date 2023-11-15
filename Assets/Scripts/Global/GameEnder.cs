using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEnder : MonoBehaviour //definatly not a T4 arthy from sc. ok, no more jokes
{
    [SerializeField]private GameObject endScreen;

    public static UnityEvent OnEndGame = new();  //it is mixing of singleton and events which is not good for real project

    private void Awake() {
        OnEndGame.AddListener(EndGame);
    }

    public void EndGame() {
        endScreen.SetActive(true);
        Time.timeScale = 0;
    }
}

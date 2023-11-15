using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedalAppearence : MonoBehaviour
{
    [SerializeField]private Sprite idle;
    [SerializeField]private Sprite pressed;
    private Image _image;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    public void SetState(bool isPressed) {
        _image.sprite = isPressed ? pressed : idle;
    }
}

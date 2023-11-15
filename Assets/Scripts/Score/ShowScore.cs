using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowScore : MonoBehaviour
{
    private void OnEnable() {
        GetComponent<TextMeshProUGUI>().text += Score.score.ToString();
    }
}

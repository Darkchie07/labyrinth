using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitCountText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    // Update is called once per frame
    public void UpdateText(int value)
    {
        text.text = "wait: " + value + "s";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnTriggerEnter(Collider other)
    {
        button.targetGraphic.color = button.colors.highlightedColor;
    }

    private void OnTriggerExit(Collider other)
    {
        button.targetGraphic.color = button.colors.normalColor;
    }
}

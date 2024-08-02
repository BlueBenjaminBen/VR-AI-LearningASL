using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Changes the color of the buttons whenever it is pressed. There are little spheres in the index fingertips of the OVRHands. There are objects in the project in the layer XRUI and anything with the layer XRUI can only interact with 
/// other objects that have the same XRUI layer. I believe only the buttons and the spheres in the fingertips are the only things in the XRUI layer
/// </summary>
public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnTriggerEnter(Collider other)
    {
        button.targetGraphic.color = button.colors.pressedColor;
        button.onClick.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        button.targetGraphic.color = button.colors.normalColor;
    }
}

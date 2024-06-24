using Samples.Whisper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MicDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == dropdown.gameObject)
        {
            var colors = dropdown.colors;
            dropdown.captionText.color = colors.pressedColor;
            ShowDropdown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == dropdown.gameObject)
        {
            var colors = dropdown.colors;
            dropdown.captionText.color = colors.highlightedColor;
        }
    }

    private void ShowDropdown()
    {
        if (dropdown != null)
        {
            dropdown.Show();
        }
    }
}

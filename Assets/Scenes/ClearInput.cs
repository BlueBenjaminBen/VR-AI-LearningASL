using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public void ClearField()
    {
        inputField.text = "";
    }
}

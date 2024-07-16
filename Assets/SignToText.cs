using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignToText : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The TMP_InputField to append text to.")]
    TMP_InputField inputField;

    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;
        string gestureName = data.gestureName;
        char gestureChar = gestureName[0];
        if (gestureID >=0)
        {
            //If first letter, uppercase
            if (string.IsNullOrEmpty(inputField.text))
            {
                char upperChar = char.ToUpper(gestureChar);
                inputField.text = upperChar.ToString();
            }
            else
            {
                inputField.text += gestureChar;
            }
            //Set caret position to the end of the text
            inputField.caretPosition = inputField.text.Length;
            inputField.Select();
        }
        else
        {
            Debug.LogError("Gesture Not Found!");
        }
    }
}

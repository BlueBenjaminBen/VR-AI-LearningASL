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

    //Runs whenever a gesture is completed (whenever the gesture trigger passes the threshold and leaves it)
    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;     
        string gestureName = data.gestureName;
        char gestureChar = gestureName[0];  //Gets the first character of the gesture name in the ASLGesture.dat database
        if (gestureID >=0)                  //Checks if gestureID is non-negative; non-negative integer represent an error.
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

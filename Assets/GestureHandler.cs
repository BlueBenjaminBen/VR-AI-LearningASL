using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestureHandler : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The TMP_InputField to append text to.")]
    TMP_InputField m_InputField;

    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;
        string gestureName = data.gestureName;
        char gestureChar = gestureName[0];
        if (gestureID >=0)
        {
            //If first letter, uppercase
            if (m_InputField.text == null)
            {
                char upperChar = char.ToUpper(gestureChar);
                m_InputField.text += upperChar;
            }
            else
            {
                m_InputField.text += gestureChar;
            }
        }
    }
}

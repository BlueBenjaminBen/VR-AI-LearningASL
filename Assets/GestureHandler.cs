using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestureHandler : MonoBehaviour
{
    private Dictionary<int, string> gestureToWordMap;

    [SerializeField]
    [Tooltip("The TMP_InputField to append text to.")]
    TMP_InputField m_InputField;

    //Initializes the dictionary
     void Start()
    {
        gestureToWordMap = new Dictionary<int, string>
        {
            {0, "hello" }
        };
    }
    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;
        Debug.Log(gestureID);

        //Check if gesture ID exists in the dictionary
        if (gestureToWordMap.ContainsKey(gestureID))
        {   //Gets the word or phrase
            string word = gestureToWordMap[gestureID];
            if (!string.IsNullOrEmpty(m_InputField.text))
            {
                m_InputField.text += " " + word;
            }
            else
            {
                word = char.ToUpper(word[0]) + word.Substring(1);
                m_InputField.text = word;
            }
        }
    }
}

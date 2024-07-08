using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestureHandler : MonoBehaviour
{
    public MivryQuestHands gestureManager;
    private Dictionary<int, string> gestureToWordMap;

    [SerializeField]
    [Tooltip("The TMP_InputField to append text to.")]
    TMP_InputField m_InputField;

    [SerializeField]
    [Tooltip("Button to start the gesture recording")]
    private Button recordButton;

    public float recordingDuration = 2.5f;
    private bool isRecording = false;
    
    public void StartGestureRecording()
    {
        if (gestureManager != null)
        {
            gestureManager.leftGestureTriggerValue = 1.0f;
        }
        else
        {
            Debug.Log("gesture manager null");
        }
    }
    public void StopGestureRecording()
    {
        if (gestureManager != null)
        {
            gestureManager.leftGestureTriggerValue = 0.0f;
            gestureManager.rightGestureTriggerValue = 0.0f;
        }
        
    }
    private IEnumerator StartTimedRecording(float duration)
    {
        isRecording = true;
        StartGestureRecording(); //Start recording

        yield return new WaitForSeconds(duration);

        StopGestureRecording(); //Stop recording
        isRecording = false;
    }
    public void OnButtonClick()
    {
        if (!isRecording)
        {
            StartCoroutine(StartTimedRecording(recordingDuration));
        }
    }
    //Initializes the dictionary
     void Start()
    {
        gestureToWordMap = new Dictionary<int, string>
        {
            {0, "hello" },
            {1, "a" }
        };

        if (recordButton != null)
        {
            recordButton.onClick.AddListener(OnButtonClick);
        }
        if (gestureManager != null)
        {
            gestureManager.OnGestureCompletion.AddListener(OnGestureCompleted);
        }
    }
    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;
        Debug.Log(gestureID);

        //Check if gesture ID exists in the dictionary
        if (gestureToWordMap.ContainsKey(gestureID))
        {   
            //Gets the word or phrase
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
        else
        {
            Debug.Log("No gesture detected");
        }
    }
}

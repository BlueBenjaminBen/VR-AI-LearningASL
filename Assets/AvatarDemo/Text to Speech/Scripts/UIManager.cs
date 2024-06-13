using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CognitiveServicesTTS;
using System;
using System.Threading.Tasks;
using TMPro;

public class UIManager : MonoBehaviour
{

    public SpeechManager speech;
    public GameObject avatar;


    /*
     * Calls, creates, and plays audioclip of TTS
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public async void SpeechPlayback(string input) //GPT response
    {
        if (speech.isReady)
        {
            speech.VoicePitch = 0;
            await Task.Run(() => speech.SpeakWithSDKPlugin(input));
            
        }
        else
        {
            Debug.Log("SpeechManager is not ready. Wait until authentication has completed.");
        }
    }

}

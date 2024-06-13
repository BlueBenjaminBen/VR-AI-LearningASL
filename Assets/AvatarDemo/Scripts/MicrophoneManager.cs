using Samples.Whisper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private List<string> microphones = new List<string>();
    public Whisper STT;

    public void Start()
    {

        dropdown.ClearOptions();


        string[] deviceNames = Microphone.devices;
        foreach (string deviceName in deviceNames)
        {
            microphones.Add(deviceName);
        }

        dropdown.AddOptions(microphones);
    }
    public void Update()
    {
        STT.microphone = dropdown.value;
    }
}

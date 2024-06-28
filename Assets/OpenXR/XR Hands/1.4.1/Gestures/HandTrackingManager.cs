using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HandTrackingManager : MonoBehaviour
{
    private List<Vector3> currentGesture = new List<Vector3>();
    private bool isRecording = false;

    void Start()
    {
        // Initialize any necessary setup here
    }

    void Update()
    {
        if (isRecording)
        {
            RecordHandMovement(XRNode.LeftHand);
            RecordHandMovement(XRNode.RightHand);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopRecordingAndRecognize();
        }
    }

    void StartRecording()
    {
        currentGesture.Clear();
        isRecording = true;
    }

    void StopRecordingAndRecognize()
    {
        isRecording = false;
        // Process the recorded gesture (convert currentGesture to a Point array and use it in PDollar recognizer)
        // Example: Gesture newGesture = new Gesture(currentGesture.Select(pos => new Point(pos.x, pos.y, pos.z)).ToArray());
        // string recognizedGesture = PointCloudRecognizer.Classify(newGesture, gestureTemplates.ToArray());
        // Debug.Log("Recognized Gesture: " + recognizedGesture);
    }

    void RecordHandMovement(XRNode handNode)
    {
        InputDevice handDevice = InputDevices.GetDeviceAtXRNode(handNode);
        if (handDevice != null && handDevice.isValid)
        {
            Hand hand;
            if (handDevice.TryGetFeatureValue(CommonUsages.handData, out hand))
            {
                foreach (HandFinger finger in Enum.GetValues(typeof(HandFinger)))
                {
                    List<Bone> fingerBones = new List<Bone>(); // Initialize the list here
                    if (hand.TryGetFingerBones(finger, fingerBones))
                    {
                        foreach (Bone bone in fingerBones)
                        {
                            Vector3 position;
                            if (bone.TryGetPosition(out position))
                            {
                                currentGesture.Add(position);
                            }
                        }
                    }
                }
            }
        }
    }
}

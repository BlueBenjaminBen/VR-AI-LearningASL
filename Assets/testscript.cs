using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public void OnGestureCompleted(GestureCompletionData data)
    {
        Debug.Log(data.gestureID);
        if(data.gestureID >= 0)
        {
            Debug.Log(data.gestureID);
            Debug.Log("Gesture Found ID: " +  data.gestureID);
        }
        else
        {
            Debug.Log("gesture not found");
        }
    }
}

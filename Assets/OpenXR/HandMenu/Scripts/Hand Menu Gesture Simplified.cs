using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;


public class HandMenuGestureSimplified : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The han tracking events component to subscribe to receive updated joint data to be used for gesture detection.")]
    private XRHandTrackingEvents handTrackingEvents;

    [SerializeField]
    [Tooltip("The hand shape or pose that must be detected for the gesture to be performed.")]
    private ScriptableObject handShapeOrPose;

    [SerializeField]
    [Tooltip("The target Transform to user for target conditions in the hand shape or pose.")]
    private Transform targetTransform;

    [SerializeField]
    [Tooltip("The event fired when the gesture is performed.")]
    private UnityEvent gesturePerformed;

    [SerializeField]
    [Tooltip("The event fired when the gesture is ended.")]
    private UnityEvent gestureEnded;

    [SerializeField]
    [Tooltip("The minimum amount of time the hand must be held in the required shape and orientation for the gesture for to be perfomed.")]
    private float minimumHoldTime = 0.2f;

    [SerializeField]
    [Tooltip("The interval at which the gesture detection is performed.")]
    private float gestureDetectionInterval = 0.1f;

    private XRHandShape handShape;
    private XRHandPose handpose;
    private bool wasDetected;
    private bool performedTriggered;
    private float timeofLastConditionCheck;
    private float holdStartTime;

    private void OnEnable()
    {
        handTrackingEvents.jointsUpdated.AddListener(OnJointsUpdated);
    }

    private void OnJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        if (!isActiveAndEnabled || Time.timeSinceLevelLoad < timeofLastConditionCheck + gestureDetectionInterval)
            return;

        var detected =
            handTrackingEvents.handIsTracked &&
            handShape != null && handShape.CheckConditions(eventArgs) ||
            handpose != null && handpose.CheckConditions(eventArgs);

        if(!wasDetected && detected)
        {
            holdStartTime = Time.timeSinceLevelLoad;

        }
        else if(wasDetected && !detected)
        {
            Debug.Log("Gesture Ended!");
            performedTriggered = false;
            gestureEnded?.Invoke();
        }

        wasDetected = detected;

        if(!performedTriggered && detected)
        {
            var holdTimer = Time.timeSinceLevelLoad - holdStartTime;
            if(holdTimer > minimumHoldTime)
            {
                Debug.Log("Gesture Started!");
                gesturePerformed?.Invoke();
                performedTriggered = true;
            }
        }

        timeofLastConditionCheck = Time.timeSinceLevelLoad;
    }

}

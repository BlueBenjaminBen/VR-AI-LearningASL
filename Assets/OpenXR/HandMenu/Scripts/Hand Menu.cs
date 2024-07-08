using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    private GameObject head;
    private Transform leftHandPalm;



    private void Start()
    {
        // Find the head and hand game objects
        head = GameObject.Find("CenterEyeAnchor");
        leftHandPalm = transform.parent;

        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        if (head != null && leftHandPalm != null)
        {
            //Calculate directoin from head to palm
            Vector3 headToPalm = leftHandPalm.position - head.transform.position;
            Vector3 headForward = head.transform.forward;

            //Normalize Vectors for dot product calculatoin
            headToPalm.Normalize();
            headForward.Normalize();

            //Calculate dot product to determine alignment
            float dotProduct = Vector3.Dot(headForward, headToPalm);


            // This makes sure that the left palm is mostly looking towards the face
            if (dotProduct > 0.9)
            {
                if (!menuCanvas.activeSelf)
                {
                    menuCanvas.SetActive(true);
                }
            }
            else if (menuCanvas.activeSelf)
            {
                menuCanvas.SetActive(false);
            }
        }
    }
}

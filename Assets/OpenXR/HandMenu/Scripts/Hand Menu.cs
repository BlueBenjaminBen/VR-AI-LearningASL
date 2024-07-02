using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{

    [SerializeField] private GameObject menuCanvas;

    private GameObject head;
    private GameObject leftHandPalm;

    private Vector3 dirFromAtoB = Vector3.zero;
    private float dotProd = 0f;

    private void Start()
    {
        head = GameObject.Find("CenterEyeAnchor");
        leftHandPalm = GameObject.Find("LeftHandAnchor");
        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        if (head != null && leftHandPalm != null)
        {
            dirFromAtoB = (head.transform.position - leftHandPalm.transform.position).normalized;
            dotProd = Vector3.Dot(dirFromAtoB, (-1) * leftHandPalm.transform.up);

            //This makes sure that the left palm is mostly looking towards the face
            if (dotProd > 0.9)
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

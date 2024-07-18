using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandInput : MonoBehaviour
{
    public LayerMask uiLayerMask;
    private Collider handCollider;

    private void Start()
    {
        handCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        CheckForUIInteraction();
    }

    void CheckForUIInteraction()
    {
        Collider[] hitColliders = Physics.OverlapBox(handCollider.bounds.center, handCollider.bounds.extents, handCollider.transform.rotation, uiLayerMask);

        foreach (var hitCollider in hitColliders)
        {
            if(IsInUILayer(hitCollider.gameObject))
            {
                PointerEventData pointer = new PointerEventData(EventSystem.current)
                {
                    position = Camera.main.WorldToScreenPoint(hitCollider.transform.position)
                };
                ExecuteEvents.Execute(hitCollider.gameObject, pointer, ExecuteEvents.pointerClickHandler);
            }
        }
    }
    bool IsInUILayer(GameObject obj)
    {
        return ((1 << obj.layer) & uiLayerMask) != 0;
    }
}

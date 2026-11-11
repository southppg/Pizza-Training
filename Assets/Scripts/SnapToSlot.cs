using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToSingleSlot : MonoBehaviour
{
    public Transform slotMiddle; // Assign the middle slot
    public float snapDistance = 0.2f; // Distance to trigger snapping
    private XRGrabInteractable grabInteractable;
    private bool isPlaced = false;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (isPlaced) return;

        float distance = Vector3.Distance(transform.position, slotMiddle.position);
        if (distance <= snapDistance)
        {
            transform.position = slotMiddle.position;
            transform.rotation = slotMiddle.rotation;

            // Optional: make Rigidbody kinematic so it stays in place
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = true;

            isPlaced = true;
        }
    }
}


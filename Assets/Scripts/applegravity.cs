using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class appleGravity : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Başlangıçta yerçekimi kapalı
        rb.useGravity = false;
        rb.isKinematic = true;

        // Elma grab edildiğinde yerçekimini aç
        grabInteractable.selectEntered.AddListener(OnSelectEntered);

        // Elma bırakıldığında yerçekimini kapat
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }
}
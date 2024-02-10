using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabEnter);
        }
    }

    void OnGrabEnter(XRBaseInteractor interactor)
    {
        Debug.Log("Grabbed!");
    }
}

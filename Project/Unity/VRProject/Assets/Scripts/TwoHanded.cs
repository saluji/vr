using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHanded : MonoBehaviour
{
    public XRBaseInteractor leftHand;
    public XRBaseInteractor rightHand;

    private bool leftHandNear;
    private bool rightHandNear;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Attach event listeners
        grabInteractable.onSelectEntered.AddListener(OnGrabEnter);
        grabInteractable.onSelectExited.AddListener(OnGrabExit);
    }

    void Update()
    {
        // Custom logic to check if hands are near the sides of the barbell
        leftHandNear = CheckHandProximity(leftHand);
        rightHandNear = CheckHandProximity(rightHand);

        // If both hands are near, allow grabbing
        grabInteractable.interactionLayerMask = leftHandNear && rightHandNear ? -1 : 0;
    }

    bool CheckHandProximity(XRBaseInteractor hand)
    {
        // Custom logic to check if the hand is near the side of the barbell
        // You might use trigger colliders or other methods to detect hand proximity
        // Return true if the hand is near, false otherwise
        return false;
    }

    void OnGrabEnter(XRBaseInteractor interactor)
    {
        // Custom logic when the barbell is grabbed
    }

    void OnGrabExit(XRBaseInteractor interactor)
    {
        // Custom logic when the barbell is released
    }
}

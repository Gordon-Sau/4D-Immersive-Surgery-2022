using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerInteract: MonoBehaviour
{

    [SerializeField]
    private GameObject dotPrefab = null;

    [SerializeField]
    private MakeLine lineMaker = null;

    public void TriggerClick(ActivateEventArgs arg) {
        IXRInteractor interactor = arg.interactorObject;
        if (interactor is XRRayInteractor) {
            XRRayInteractor rayInteractor = (XRRayInteractor)interactor;
            RaycastHit hit;
            Transform parentTransform = arg.interactableObject.transform;
            GameObject parentGameObject = parentTransform.gameObject;
            if (rayInteractor.TryGetCurrent3DRaycastHit(out hit)) {
                if (hit.transform.gameObject == parentGameObject) {
                    Debug.Log("get clicked by pointer");
                    // create dot
                    ClickDot.createDot(dotPrefab, hit.point, Quaternion.identity, parentTransform, lineMaker);
                }
            }
        }
    }
}

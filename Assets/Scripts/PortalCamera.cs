using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;


    void LateUpdate()
    {
        PortalCameraController();
    }
    
    void PortalCameraController()
    {
        Vector3 playerOffset = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffset;
        float angularDiffrence =
            Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference =
            Quaternion.AngleAxis(angularDiffrence, Vector3.up);
        Vector3 newCameraDirection =
            portalRotationalDifference * playerCamera.forward;

        newCameraDirection = new Vector3(
            newCameraDirection.x * -1,
            newCameraDirection.y,
            newCameraDirection.z * -1
            );

        transform.rotation = 
            Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;

    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    Vector3 desiredPosition = playerTransform.position + new Vector3(0, 0, -10);
    float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, maxCameraPosition.x);
    float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, maxCameraPosition.y);
    
    Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);
    
    transform.position = clampedPosition;
}

}

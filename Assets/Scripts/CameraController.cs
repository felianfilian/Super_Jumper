using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    

    [Header("Position")]
    public bool freezeVertical;
    public bool freezeHorizontal;
    public bool clampPosition;
    public Transform clampMin;
    public Transform clampMax;

    private Camera cam;
    private Vector3 positionStore;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        cam = GetComponent<Camera>();
        positionStore = transform.position;

        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        Clamping();
        CameraFreeze();
        
    }

    public void CameraFreeze()
    {
        if (freezeVertical)
        {
            transform.position = new Vector3(transform.position.x, positionStore.y, transform.position.z);
        }
        if (freezeHorizontal)
        {
            transform.position = new Vector3(positionStore.x, transform.position.y, transform.position.z);
        }
    }

    public void Clamping()
    {
        if (clampPosition) 
        {
            float positionX = Mathf.Clamp(transform.position.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
            float positionY = Mathf.Clamp(transform.position.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);
            transform.position = new Vector3(
            positionX,
            positionY,
            transform.position.z
            );
        }
        
    }

    private void OnDrawGizmos()
    {
        if (clampPosition)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(clampMin.position, new Vector3(clampMin.position.x, clampMax.position.y, 0));
            Gizmos.DrawLine(clampMin.position, new Vector3(clampMax.position.x, clampMin.position.y, 0));
            Gizmos.DrawLine(clampMax.position, new Vector3(clampMin.position.x, clampMax.position.y, 0));
            Gizmos.DrawLine(clampMax.position, new Vector3(clampMax.position.x, clampMin.position.y, 0));
        }
    }
}

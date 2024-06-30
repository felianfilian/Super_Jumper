using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public bool freezeVertical;
    public bool freezeHorizontal;

    private Vector3 positionStore;

    void Start()
    {
        positionStore = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);

        Destroy(this.gameObject, 3);
    }
}

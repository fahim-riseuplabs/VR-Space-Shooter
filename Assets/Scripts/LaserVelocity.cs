using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserVelocity : MonoBehaviour
{
    private Rigidbody _laserRigidbody;
    [SerializeField] private int _thrust;

    // Start is called before the first frame update
    void Start()
    {
        _laserRigidbody = GetComponent<Rigidbody>();
    }

    // Fixed Update is called once in a fixed time frame
    void FixedUpdate()
    {
        _laserRigidbody.velocity = transform.forward * _thrust;
        Destroy(this.gameObject, 2f);
    }
}

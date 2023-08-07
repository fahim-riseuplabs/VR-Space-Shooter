using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteriodRotate : MonoBehaviour
{
    [SerializeField] private float _rotationMinSpeed;
    [SerializeField] private float _rotationMaxSpeed;

    private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        _rotationSpeed = Random.Range(_rotationMinSpeed, _rotationMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }
}

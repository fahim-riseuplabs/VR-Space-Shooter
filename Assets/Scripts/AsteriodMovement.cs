using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private float _movementSpeed;

    private void Start()
    {
        _movementSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveDirection * Time.deltaTime * _movementSpeed);
    }
}

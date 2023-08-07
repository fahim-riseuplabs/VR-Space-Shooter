using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerAsteriod : MonoBehaviour
{
    [SerializeField] private Vector3 _size;
    [SerializeField] private float _asteriodSpawnRate;
    [SerializeField] private GameObject _asteriodPrefab;
    [SerializeField] private Transform _asteriodParent;

    private float _nextAsteriodTime;
    private Vector3 _spawnPosition;
    private GameObject _asteriod;


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,.5f);
        Gizmos.DrawCube(transform.position, _size);
    }

    private void Update()
    {
        if(Time.time> _nextAsteriodTime)
        {
            _nextAsteriodTime = Time.time + _asteriodSpawnRate;

            AsteriodSpawner();
        }
    }

    private void AsteriodSpawner()
    {
         _spawnPosition = this.transform.position + new Vector3(Random.Range(-_size.x / 2, _size.x / 2),
                                                                Random.Range(-_size.y / 2, _size.y / 2),
                                                                Random.Range(-_size.z / 2, _size.z / 2));

        _asteriod = Instantiate(_asteriodPrefab, _spawnPosition, Quaternion.identity);
        _asteriod.transform.SetParent(_asteriodParent);
    }
}

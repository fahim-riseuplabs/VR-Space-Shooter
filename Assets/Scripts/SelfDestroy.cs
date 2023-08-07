using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float _destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _destroyTimer);
    }

}

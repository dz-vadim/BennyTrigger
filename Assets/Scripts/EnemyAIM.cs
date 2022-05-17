using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIM : MonoBehaviour
{

    public Transform target;
    Transform currentDirectional;
    public float x, y, z;
    void Start()
    {
        currentDirectional = transform;
    }

    void Update()
    {
        //transform.LookAt(target);

        transform.LookAt(target, new Vector3(x,y,z));
    }
}

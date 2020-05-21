using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    float t;
    public float speed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    public void Jump()
    {
        t = Time.time;
        float vx = speed * t * Mathf.Cos(angle) * Time.deltaTime;
        float vy = speed * t * Mathf.Sin(angle) * Time.deltaTime * Physics.gravity.y * (t * t) / 2 * Time.deltaTime;
        transform.position += new Vector3(vx, vy, 0);
    }
}

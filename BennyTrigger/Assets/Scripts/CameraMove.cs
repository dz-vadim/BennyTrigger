using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    private Vector3 offset;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.position;
        height = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.position + offset;
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}

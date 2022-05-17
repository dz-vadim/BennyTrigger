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
        SetPlayerHeigth();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.GetComponent<StartAnimationInTrigger>().isFlip)
        {
            transform.position = Player.position + offset;
        }
        else
        {
            transform.position = Player.position + offset;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }        
    }
    public void SetPlayerHeigth()
    {
        offset = transform.position - Player.position;
        height = transform.position.y;
    }

}

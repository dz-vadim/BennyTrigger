using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationInTrigger : MonoBehaviour
{
    public float moveSpeed;    
    private float speedFactor=0.1f;

    private void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed*speedFactor;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "StartJump")
        {
            //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            moveSpeed = 0;
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationInTrigger : MonoBehaviour
{
    public float moveSpeed;
    private float speedFactor=0.1f;
    void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed*speedFactor;
    }
        private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "StartJump")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            speedFactor = 0;
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationInTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "StartJump")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }        
    }
}

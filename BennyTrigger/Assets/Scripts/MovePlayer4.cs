using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer4 : MonoBehaviour
{
    public float moveSpeed;
    private bool isJumped;

    private GameObject player;
    private Animator animator;
    public GameObject laser;

    void Start()
    {
        player = gameObject;
        animator = GetComponent<Animator>();
        isJumped = false;
    }

    void FixedUpdate()
    {
        if (!isJumped)
        {
            player.transform.position += player.transform.right * moveSpeed;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        isJumped = true;
        if (other.tag == "Start Jump") Jump4();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Start Jump")
        {
            isJumped = false;
            laser.SetActive(false);
        }
    }

    public void Jump4()
    {
        laser.SetActive(true);
        animator.Play("Flip");
    }
}



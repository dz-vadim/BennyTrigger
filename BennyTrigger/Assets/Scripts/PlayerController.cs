using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private bool isJumped;
    private float groundForPlayer;

    public float xSpeed;
    public float ySpeed;
    public float amplitude;  

    private float gravity;
    public float angle = 45f;
    public float timeScaler = 10f;

    private GameObject player;
    private Animator animator;
    public GameObject laser;


    //   private float time;
    void Start()
    {        
        player = gameObject;
        animator = GetComponent<Animator>();

        gravity = Physics.gravity.y;
        angle *= Mathf.Deg2Rad;
        isJumped = false;
        groundForPlayer = player.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.transform.position += player.transform.right * moveSpeed;
        if (!isJumped)
        {
            player.transform.position += player.transform.right * moveSpeed;
        }

        // player.transform.position += player.transform.right * moveSpeed;

        if (Input.GetKey(KeyCode.F))
        {
            animator.Play("Flip");
        }

        if (Input.GetKey(KeyCode.J))
        {
            float xx = jumpSpeed * Mathf.Cos(angle) * Time.time ;
            float yy = jumpSpeed * Mathf.Sin(angle) - gravity * Mathf.Sqrt(Time.time) / 2;

            /*xSpeed *= (moveSpeed / timeScaler);
            ySpeed *= (moveSpeed / timeScaler);
            x *= 0.02f;
            y *= 0.02f;*/

            transform.position += new Vector3(xx, yy, 0);
        }

        /*float x = Time.time * xSpeed * Time.deltaTime;
        float y = Mathf.Sin(Time.time * amplitude) * ySpeed * Time.deltaTime;
        transform.position += new Vector3(x, y, 0);*/

      //  time = Time.time;

        
    }
    private void OnTriggerStay(Collider other)
    {
        
        isJumped = true;
        if (other.tag == "Start Jump") Jump();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Start Jump")
        {
            isJumped = false;
            laser.SetActive(false);
            player.transform.position = new Vector3(player.transform.position.x, groundForPlayer, player.transform.position.z);
            //player.transform.position.x = groundForPlayer;
            //transform.position.y = groundForPlayer;
        }
        
    }


    public void Jump()
    {
        laser.SetActive(true);
        //transform.position += Vector3.right * xSpeed * Time.deltaTime;
        //transform.position += Vector3.up * Mathf.Sin(Time.time * amplitude) * ySpeed * Time.deltaTime;
        animator.Play("Flip");
    }
}

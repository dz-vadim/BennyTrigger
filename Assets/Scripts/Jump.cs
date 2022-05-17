using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Transform SpawnTransform;
    public Transform TargetTransform;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    public GameObject Player;
    private bool isClick=false;
    public float degreesSpeed;

    private Animator animator;
    public GameObject laser;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            JumpForAToB();
            isClick = true;
            float dist = Vector3.Distance(TargetTransform.position, transform.position);
            Debug.Log(dist);
            degreesSpeed = dist * 3.25102f / 22.02304f;
            Debug.Log(degreesSpeed);
            animator.Play("Flip");

        }
        if (isClick)
        {
            Quaternion rotationX = Quaternion.AngleAxis(degreesSpeed, Vector3.right);
            Player.transform.rotation *= rotationX;
            laser.SetActive(true);
        }        
    }

    public void JumpForAToB()
    {
        Time.timeScale = 0.4f;
        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);


        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        Player.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isClick = false;
            Player.transform.rotation = Quaternion.Euler(0,0,0);
            laser.SetActive(false);
            Time.timeScale = 1;
        }
    }

}

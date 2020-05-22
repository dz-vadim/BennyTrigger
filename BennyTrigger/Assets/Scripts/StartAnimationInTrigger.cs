using UnityEngine;

public class StartAnimationInTrigger : MonoBehaviour
{
    public float moveSpeed;
    private float speedFactor = 0.1f;
    public GameObject laser;
    void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed * speedFactor;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "StartJump")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            speedFactor = 0;
        }
    }
    private void SetSpeed()
    {
        speedFactor = 0.1f;
        laser.SetActive(false);
    }
    private void ActivateLaser()
    {
        laser.SetActive(true);
    }
}

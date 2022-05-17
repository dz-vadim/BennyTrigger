using UnityEngine;

public class StartAnimationInTrigger : MonoBehaviour
{
    public float moveSpeed;
    public float playerY;
    public bool isFlip;


    private float speedFactor = 0.1f;
    public GameObject laser;
    public GameObject FinishMassage;
    public Camera mainCamera;
    private Transform playerTransform;


   // public Camera mainCamera;
   private void Start()
    {
        isFlip = false;
        FinishMassage.SetActive(false);
    }
    void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed * speedFactor;
      //  mainCamera.transform.Translate(transform.position);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "StartJump")
        {           //заменить на параметр флоат в аниматоре и добавить енам в скрипт
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Flip", false);
            gameObject.GetComponent<Animator>().SetBool("SwipeMove", false);
            speedFactor = 0;
        }

        if (collider.tag == "StartSwipe")
        {           //заменить на параметр флоат в аниматоре и добавить енам в скрипт
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Flip", false);
            gameObject.GetComponent<Animator>().SetBool("SwipeMove", true);
            speedFactor = 0;            
        }

        if (collider.tag == "StartFlip")
        {           //заменить на параметр флоат в аниматоре и добавить енам в скрипт
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Flip", true);
            gameObject.GetComponent<Animator>().SetBool("SwipeMove", false);
            speedFactor = 0;
        }

        if (collider.tag == "Finish")
        {
            Time.timeScale = 0;
            FinishMassage.SetActive(true);
        }
    }
    private void SetSpeed()
    {

        speedFactor = 0.1f;
        laser.SetActive(false);
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.position = new Vector3(transform.position.x, playerY, transform.position.z);

    }
    private void StopFlip()
    {
        speedFactor = 0.1f;
        laser.SetActive(false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -22.3f, transform.position.z);

    }
    private void ActivateLaser()
    {
        playerY = transform.position.y;
        laser.SetActive(true);
    }

    private void SetFlipTrue()
    {
        isFlip = true;
    }
    private void SetFlipFalse()
    {
        isFlip = false;
        mainCamera.GetComponent<CameraMove>().SetPlayerHeigth();
    }

}

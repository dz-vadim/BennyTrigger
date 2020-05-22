using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Vector3 lastPosition;
    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Linecast(lastPosition, transform.position, out hit))
        {            
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                print(hit.transform.name);
            }           
            Destroy(gameObject);
        }
        Destroy(gameObject, 10);
    }
}
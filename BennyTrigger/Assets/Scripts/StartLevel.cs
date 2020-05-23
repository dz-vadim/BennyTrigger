using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StartMassage;
    void Start()
    {
        Time.timeScale = 0;
        StartMassage.SetActive(true);

    }

    public void Play()
    {
        Time.timeScale = 1;
        StartMassage.SetActive(false);
    }
}

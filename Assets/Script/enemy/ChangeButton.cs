using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{

    public GameObject Button1, Button2;

    int count = 0;
    float delay = 0.02f;
    private void Update()
    {
        if (count == 4)
        {

            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                delay = 1000;
                Button2.SetActive(true);
                Button1.SetActive(false);
            }
        }
    }

    // Update is called once per frame

    public void ClickCount()
    {
        count++;
       
    }
}

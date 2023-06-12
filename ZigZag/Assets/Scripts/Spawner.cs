using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sonZemin; 
    void Start()
    {
        for(int i = 0; i<50; i++)
        {
            create();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void create()
    {
        Vector3 random;
        if(Random.Range(0,2) == 0)   // eğer 0 ve 1 den seçilen 0 ise
        {
            random = Vector3.left;
        }
        else
        {
            random = Vector3.forward;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + random, sonZemin.transform.rotation);
    }
}

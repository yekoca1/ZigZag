using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraTakip : MonoBehaviour
{
    public Transform top;
    Vector3 fark;
    void Start()
    {
        fark = transform.position - top.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hareket.fall == false)
        {
            transform.position = top.position + fark;
        }
    }
}

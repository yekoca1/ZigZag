using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skor : MonoBehaviour
{
    public static int skor;
    public TextMeshProUGUI skorText;
    void Start()
    {
        skor = 0;        
    }

    void Update()
    {
        skorText.text = skor.ToString();
    }
}

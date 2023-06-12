using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skor : MonoBehaviour
{
    public static int skor;
    private int currentLevel;
    public TextMeshProUGUI skorText;
    void Start()
    {
        skor = 0;  
        currentLevel = 1;    
        //UpdateLevel();  
    }

    void Update()
    {
        skorText.text = skor.ToString();
    }

    
}

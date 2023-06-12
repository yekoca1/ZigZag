using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
    }

    public void play()
    {
        PlayerPrefs.DeleteKey("currentLevel");
        SceneManager.LoadScene(1); // Yeni sahneyi yükle
    }

    public void playSaved()
    {
        SceneManager.LoadScene(1); // Yeni sahneyi yükle
    }

    public void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
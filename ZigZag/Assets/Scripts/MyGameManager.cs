using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
using TMPro;




public class MyGameManager : MonoBehaviour
{
    public string nextLevelName;
    public TextMeshProUGUI levelText;

    private int currentLevel = 0;

    private void Start()
    {
        // PlayerPrefs'tan currentLevel değişkeninin değerini okuyun
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        UpdateLevelText();
    }

    public void nextLevel()
    {
        currentLevel++;
        UpdateLevelText();

        // PlayerPrefs'ta currentLevel değişkeninin değerini güncelleyin
        PlayerPrefs.SetInt("currentLevel", currentLevel);

        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }
}



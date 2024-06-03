using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSettings;
    [SerializeField] private GameObject iconsButtons;


    public GameObject PausePanel;
    public GameObject CanvasScore;
    public GameObject Hint;
    public GameObject Tittle;
    public bool isPaused;

    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Continue();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Play()
    {
        isPaused = false;
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("TutorialShown") == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            GoToHint();
        }

        Continue();
    }    
    public void OpenSettings()
    {
        painelSettings.SetActive(true);
        iconsButtons.SetActive(false);
        CanvasScore.SetActive(false);     

    }
    public void CloseSettings()
    {
        painelSettings.SetActive(false);
        painelMenuInicial.SetActive(true);
        iconsButtons.SetActive(true);
    }    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        CanvasScore.SetActive(false);
        isPaused = true;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        CanvasScore.SetActive(true);
        isPaused = false;
    }

    public void BackToMenu()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene("MenuInicial");
        
    }

    public void GoToHint()
    {
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 1)
        {
            Hint.SetActive(false);
        } 
        else 
        {
            Hint.SetActive(true);
            iconsButtons.SetActive(false);
            Tittle.SetActive(false);
            PlayerPrefs.SetInt("TutorialShown", 1);
            PlayerPrefs.Save();
        }
        
    }
}


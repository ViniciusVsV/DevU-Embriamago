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
    public GameObject Hearts;
    public bool isPaused;

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
        SceneManager.LoadScene("SampleScene");
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
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        CanvasScore.SetActive(false);
        Hearts.SetActive(false);
        isPaused = true;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        CanvasScore.SetActive(true);
        Hearts.SetActive(true);
        isPaused = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}


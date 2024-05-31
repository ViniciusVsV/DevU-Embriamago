using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private string nome_do_level_jogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSettings;
    [SerializeField] private GameObject iconsButtons;

    
    public GameObject PausePanel;
    public bool isPaused;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }    
    public void OpenSettings()
    {
        painelSettings.SetActive(true);
        iconsButtons.SetActive(false);     

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

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        isPaused = true;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        isPaused = false;
    }
}


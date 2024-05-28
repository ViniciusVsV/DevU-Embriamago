using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private string nome_do_level_jogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSettings;
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }    
    public void OpenSettings()
    {
        painelSettings.SetActive(true);        
    }
    public void CloseSettings()
    {
        painelSettings.SetActive(false);
        painelMenuInicial.SetActive(true);
    }    
    public void ExitGame()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}

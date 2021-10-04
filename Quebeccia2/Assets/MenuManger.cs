using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Jouer");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Parametres");
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsManager : MonoBehaviour
{
    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Parametres");
    }
}

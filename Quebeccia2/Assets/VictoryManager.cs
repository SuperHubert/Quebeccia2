using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI newHighScore;

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Menu");
    }

    private void Start()
    {
       if (ScoreToNextScene.Instance.scoreP1 == ScoreToNextScene.Instance.scoreP2)
        {
            playerText.text = "Aucun";
            scoreText.text = "Score : " + ScoreToNextScene.Instance.scoreP1;
        }
       else if (ScoreToNextScene.Instance.scoreP1 > ScoreToNextScene.Instance.scoreP2)
       {
            playerText.text = "Joueur 1";
            scoreText.text = "Score : " + ScoreToNextScene.Instance.scoreP1;
        }
       else
        {
            playerText.text = "Joueur 2";
            scoreText.text = "Score : " + ScoreToNextScene.Instance.scoreP2;
        }

        highScoreText.text = "Highscore : " + ScoreToNextScene.Instance.highScore;
        if (ScoreToNextScene.Instance.newHighScore)
        {
            newHighScore.text = "New !";
        }

    }

}

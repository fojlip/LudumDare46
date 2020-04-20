using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public IntVariable score;
    public IntVariable railCounter;
    public Bar bar;

    public void StartGame()
    {
        bar.StartGame();
    }

    public void GameOver()
    {
        bar.GameOver();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        score.RuntimeValue = 0;
        railCounter.RuntimeValue = 0;
        Debug.Log("frfrfrfrfr");
        SceneManager.LoadScene(0);
    }

}

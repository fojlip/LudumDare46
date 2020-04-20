using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bar : MonoBehaviour
{
    public IntVariable score;
    public IntVariable railCounter;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI railCounterText;
    public GameObject Intro;
    public GameObject Outro;


    private void Start()
    {
        Intro.SetActive(true);
        Outro.SetActive(false);
    }

    public void StartGame()
    {
        Intro.SetActive(false);
    }


    void Update()
    {
        scoreText.text = "Score: " + score.RuntimeValue;
        railCounterText.text = "Rails: " + railCounter.RuntimeValue;
    }


    public void GameOver()
    {
        Outro.SetActive(true);
    }

    public void ResetGame()
    {
        
    }

}

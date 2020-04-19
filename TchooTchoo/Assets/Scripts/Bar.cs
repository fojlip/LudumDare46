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

    void Update()
    {
        scoreText.text = "Score: " + score.RuntimeValue;
        railCounterText.text = "Rails: " + railCounter.RuntimeValue;
    }
}

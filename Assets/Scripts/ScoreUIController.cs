using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public ScoreManager scoreManager;

    private void Update(){
        scoreText.text = scoreManager.score.ToString();
    }
}

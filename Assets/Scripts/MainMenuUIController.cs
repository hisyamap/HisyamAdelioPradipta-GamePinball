using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Start(){
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame(){
        SceneManager.LoadScene("MainScene");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndQuit : MonoBehaviour
{
    public Canvas canvas;
    public GameObject startButton;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        startButton = GameObject.Find("Start Button");
    }
    public void ChangeScene(){
        startButton.SetActive(false);        
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
}

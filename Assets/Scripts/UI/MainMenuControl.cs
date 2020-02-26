using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 控制主菜单的按钮功能
*/


public class MainMenuControl : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject LoadGamePanel;
    public GameObject SettingPanel;


    void Start()
    {
        
    }

    public void StartNewGame() {
        SceneManager.LoadScene("Test");
    }

    public void ContinueGame() {


    }

    public void LoadGame() {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(false);
        LoadGamePanel.SetActive(true);
       
    }

    public void ModifySettings() {

    }

    public void QuitGame() {
        Application.Quit();
    }



}

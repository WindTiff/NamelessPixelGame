using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanelControl : MonoBehaviour
{

    public GameObject GameMenuPanel;
    public GameObject RoleInfomationPanel;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ShowOptions() {
        GameMenuPanel.SetActive(true);
    }

    public void ShowPlayerInfo() {
        RoleInfomationPanel.SetActive(true);

    }


}

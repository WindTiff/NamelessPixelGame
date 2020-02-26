using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGamePanelControl : MonoBehaviour
{


    public GameObject MainPanel;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReturnToMainMenu() {
        MainPanel.SetActive(true);
        gameObject.SetActive(false);
    }

}

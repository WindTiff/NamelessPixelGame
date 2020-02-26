using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuPanelControl : MonoBehaviour
{
    public GameObject SaveGameNotice;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ChooseReturnToGame() {
        gameObject.SetActive(false);
    }

    public void ChooseSaveGame() {
        SaveGameNotice.SetActive(true);

    }
}

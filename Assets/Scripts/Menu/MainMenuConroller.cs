using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenuConroller : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelMenu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("lvl1");
    }
    
    public void DoExitGame() 
    {
        Application.Quit();
    }

  
    public void LevelSelector()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
     public void MainSelector()
    {
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}

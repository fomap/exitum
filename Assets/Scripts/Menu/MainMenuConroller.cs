using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuConroller : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("lvl1");
    }
    
    public void DoExitGame() 
    {
        Application.Quit();
    }

}

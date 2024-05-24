using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public Image Lock;
    public Image Done;
    private int highestLevel;
    // Start is called before the first frame update
    void Start()
    {
        highestLevel = PlayerPrefs.GetInt("highestLevel", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            int levelNum = i+1;
            if(levelNum>highestLevel)
            {
                levelButtons[i].GetComponent<Image>().sprite = Lock.sprite;
                levelButtons[i].interactable = false;
                
            }
            else
            {
                levelButtons[i].GetComponent<Image>().sprite = Done.sprite;
                levelButtons[i].interactable = true;
                

            }
        }


    }



    // Update is called once per frame
    public void LoadLevel(int levelNum)
    {
        
        SceneManager.LoadScene("lvl" + levelNum);
    }
}

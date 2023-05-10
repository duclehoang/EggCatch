using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerStartGUI : MonoBehaviour
{   
  



    // Start is called before the first frame update
  

    public void gameStart(){
       
            SceneManager.LoadScene(1);
    }
    public void gameExit(){
        Application.Quit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    public GameObject egg;
    public Transform spawnPoint;
    Vector3 spawnPosition;
    //bool gameOver=false;
    public float EggSpawnRate;
    public float maxPos;
    private int score;
    public TextMeshProUGUI ScoreText;
    
    public bool isGamePause = false;
    public GameObject Basket,GameOverGUI,PauseGameGUI,MenuGamePause;


   private void Awake() {
        Instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition=spawnPoint.position;
       
        

           StartCoroutine("SpawnEggs");
     
    }

    // Update is called once per frame
    public void Update()
    {


        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePause){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
        
    }

    public void PauseGame(){
        Time.timeScale=0;
        isGamePause=true;
        MenuGamePause.SetActive(true);
        PauseGameGUI.SetActive(false);
        
    }
    public void ResumeGame(){
        Time.timeScale=1;
        isGamePause=false;
        MenuGamePause.SetActive(false);
         PauseGameGUI.SetActive(true);

    }
  
    void SpawnEgg(){
        float randomX=Random.Range(-maxPos,maxPos);
        spawnPosition.x=randomX;
        Instantiate(egg, spawnPosition,Quaternion.identity);

      
    }
   public void addScroredEgg(){
        score++;
        ScoreText.text="Score: "+score.ToString();
        
    }
      IEnumerator SpawnEggs(){
        while(true){
            yield return new WaitForSeconds(EggSpawnRate);
            SpawnEgg();
             Time.fixedDeltaTime = 1f / 60f; 
        }
            
    }

    public void gameOver1(){
        GameOverGUI.SetActive(true);
          StopCoroutine("SpawnEggs");
          PauseGameGUI.SetActive(false);


    }

    public void gameReplay(){
        
        SceneManager.LoadScene(1);
        GameOverGUI.SetActive(false);
       
    }
    public void QuitGame(){
        Application.Quit();
    }

}

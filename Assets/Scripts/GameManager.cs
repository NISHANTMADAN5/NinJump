using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    bool GameOver = false;
    public GameObject lifeHolder;
    public GameObject gameoverPanel;
    
    public Text scoreText;
    int score = 0 ;
    
    int lives=3;
    private void Awake() {
       
        if(instance==null)
        {
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IncrementScore();
    }

    public void IncrementScore()
    {
        if(!GameOver)
        {
            score++;
            scoreText.text= score.ToString();
        }
        
       
    }

    public void DecreaseLives()
    {
        lives--;
            

        lifeHolder.transform.GetChild(lives).gameObject.SetActive(false);    
        if(lives<=0)
        {
            GameOver=true;
            Gameover();
        }
        
    }

    void Gameover() 
    {
         ObstSpawn.instance.StopSpawning();
         GameObject.Find("Player").GetComponent<Player>().canMove=false;
         gameoverPanel.SetActive(true);
         print("GameOver()");
    }
}

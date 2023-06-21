using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;
    public float startWait;
    public float cloneWait;
    public float waveWait;
    public TMP_Text ScoreText;
    public TMP_Text RestartText;
    public TMP_Text GameOverText;
    private int score;
    private bool gameOver;
    private bool restart;
    // Start is called before the first frame update
    void Start()
    {
        score= 0;
        gameOver = restart = false;
        ScoreText.text = "Score:0";
        RestartText.text = "";
        GameOverText.text = "";

       StartCoroutine( Waves());
    }

    void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    } 

    IEnumerator Waves()
    {
        while (true){
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            if (gameOver)
            {
                restart = true;
                RestartText.text = "Press R to restart";
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
       
    }
    public void addScore(int sc)
    {
        
        score += sc;
        ScoreText.text = "Score:" + score;
    }
    public void GameOVer()
    {
        GameOverText.text = "GAME OVER!";
        gameOver= true;
    }
}

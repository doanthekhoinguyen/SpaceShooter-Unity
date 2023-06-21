using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;


    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller!= null)
        {
            gameController= controller.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Game controller not found");
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary") 
            return;
        Instantiate(explosion,transform.position,transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, other.transform.rotation);
            gameController.GameOVer();

        }
        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
  
  

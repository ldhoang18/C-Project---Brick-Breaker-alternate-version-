using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickProjectile : MonoBehaviour
{
    public GameObject brickprojectile;
    Vector3 respawn = new Vector3(0, -4, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            /*if (GameManager.lives == 0)
            {
                Destroy(collision.gameObject);
                GameManager.playGame = false;
                GameManager.startGame = false;
                //GameManager.gameStarted = false;
            }
            else
            {*/
            collision.gameObject.transform.position = respawn;
            //Destroy(collision.gameObject);
            GameManager.playGame = false;
            GameManager.startGame = false;
            GameManager.lives--;
            Destroy(brickprojectile);
            //}
            
        }

        if (collision.gameObject.tag == "losebox")
        {
            Destroy(brickprojectile);
        }
    }
}

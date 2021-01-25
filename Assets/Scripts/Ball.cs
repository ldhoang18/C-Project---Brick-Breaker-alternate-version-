using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lives > 0)
        {
            movement();
        }
    }

    void movement()
    {
        if (GameManager.startGame == true && GameManager.gameStarted == false)
        {
            rb.AddForce(transform.up * 250f);
            rb.AddForce(transform.right * -250f);
            GameManager.gameStarted = true;
        }

        if (rb.velocity.x < 1 && rb.velocity.x >= 0)
        {
            rb.AddForce(transform.right * -50);
        }
        if (rb.velocity.x > -1 && rb.velocity.x < 0)
        {
            rb.AddForce(transform.right * 50);
        }
        if (rb.velocity.y < 1 && rb.velocity.y >= 0)
        {
            rb.AddForce(transform.up * -50);
        }
        if (rb.velocity.y > -1 && rb.velocity.y < 0)
        {
            rb.AddForce(transform.up * 50);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "brickprojectile")
        {
            Destroy(collision.gameObject);
            GameManager.playGame = true;
        }*/
        if (collision.gameObject.tag == "brick")
        {
            /*if (GameManager.lives == 0)
            {
                Destroy(this.gameObject);
                GameManager.playGame = false;
                GameManager.startGame = false;
            }
            else
            {*/
            Destroy(collision.gameObject);
            GameManager.score += 100;
            GameManager.lives++;
            GameManager.playGame = true;
            //} 
        }

        if (collision.gameObject.tag == "losebox")
        {
            /*if (GameManager.lives == 0)
            {
                Destroy(this.gameObject);
                GameManager.playGame = false;
                GameManager.startGame = false;
            }
            else
            {*/
            GameManager.playGame = false;
            GameManager.lives--;
            GameManager.startGame = false;
            //}
            //Destroy(this.gameObject);      
        }
    }


}


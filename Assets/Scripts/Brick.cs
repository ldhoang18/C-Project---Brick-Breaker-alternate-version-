using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brick;
    public GameObject brickProjectile;
    public GameObject brickProjectileClone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lives > 0) //&& GameManager.playGame == true
        {
            brickFireProjectile();
        }
    }

    void brickFireProjectile()
    {
        if (Random.Range(0f, 750f) < 1)
        {
            brickProjectileClone = Instantiate(brickProjectile, new Vector3(brick.transform.position.x, brick.transform.position.y - 0.4f, 0), brick.transform.rotation) as GameObject;
        }
        
    }
}

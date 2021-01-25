using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    float leftMax = 190;
    float rightMax = 700;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
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
        float maxPosition = Mathf.Clamp(Input.mousePosition.x, leftMax, rightMax);
        float worldPos = mainCamera.ScreenToWorldPoint(new Vector3(maxPosition, 0, 0)).x;
        this.transform.position = new Vector3(worldPos, -4, 0);
    }
}

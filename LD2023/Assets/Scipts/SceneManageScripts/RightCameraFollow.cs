using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCameraFollow : MonoBehaviour
{
    public Camera rightCamera;
    public PlayerTwoController playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        rightCamera = GetComponent<Camera>();
        playerTwo = FindObjectOfType<PlayerTwoController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y, -10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCameraFollow : MonoBehaviour
{
    public Camera leftCamera;
    public PlayerOneController playerOne;
    // Start is called before the first frame update
    void Start()
    {
        leftCamera = GetComponent<Camera>();
        playerOne = FindObjectOfType<PlayerOneController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y, -10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public GameObject player;//玩家
    public Vector2 directionVector;//移动方向
    public float movementSpeed;//移速
    public Vector2 playerPosition;//玩家位置判定
    // Start is called before the first frame update
    void Start()
    {
        directionVector = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        directionVector.x = Input.GetAxisRaw("HorizontalTwo");
        directionVector.y = Input.GetAxisRaw("VerticalTwo");
        if ((directionVector.x != 0f || directionVector.y != 0f))
        {
            CharacterMovement();
        }
        playerPosition = this.GetComponent<Transform>().position;//移动代码
    }
    
    void CharacterMovement()//移动生效代码
    {
        transform.Translate(Vector3.right * directionVector.x * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * directionVector.y * movementSpeed * Time.deltaTime);
    }
}

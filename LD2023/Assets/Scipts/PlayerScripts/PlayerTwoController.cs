using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public GameObject player;//玩家
    public Vector2 directionVector;//移动方向
    public float movementSpeed;//移速
    public Vector2 playerPosition;//玩家位置判定
    public bool isBagExpand = false;
    public bool isFastBike = false;
    public bool isOrderIntercept = false;
    public bool Upgraded = false;
    public int bagCapacity=1;
    public int additionalFood=3;
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
        if(isBagExpand&&!Upgraded){
            bagCapacity=2;
            Upgraded=true;
        }
        if(isFastBike&&!Upgraded){
            movementSpeed*=1.2f;
            Upgraded=true;
        }
    }
    
    void CharacterMovement()//移动生效代码
    {
        transform.Translate(Vector3.right * directionVector.x * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * directionVector.y * movementSpeed * Time.deltaTime);
    }
}

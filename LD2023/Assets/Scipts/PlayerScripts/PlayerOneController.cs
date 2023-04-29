using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]public float moveX;
    [HideInInspector]public float moveY;
    [HideInInspector]public float faceNum;

    public Collider2D playerOneCollider;
    public Rigidbody2D playerOneRigidbody;
    private void Start()
    {
        playerOneCollider=GetComponent<Collider2D>();
        playerOneRigidbody=GetComponent<Rigidbody2D>();
    }
    public void Run(){
        moveX=Input.GetAxis("Horizontal");
        moveY=Input.GetAxis("Vertical");
        playerOneRigidbody.velocity=new Vector2(moveX*moveSpeed,moveY*moveSpeed);
        faceNum=Input.GetAxisRaw("Horizontal");
        if(faceNum<0){
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }
}

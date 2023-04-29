using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkShop : MonoBehaviour
{
    public Collider2D milkShopCollider;
    public bool isPlayerOne;
    public bool isPlayerTwo;
    public float prepareTime=15f;
    public float currentTime;
    public bool isPrepared=false;

    private void Start()
    {
        milkShopCollider = GetComponent<Collider2D>();
    }
    public void Update(){
        if(!isPrepared){
            Preparation();
        }
    }
    public void Preparation(){
        currentTime+=Time.deltaTime;
        if(currentTime>=prepareTime){
            currentTime=prepareTime;
            isPrepared=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否碰撞的物体是 PlayerOne 或 PlayerTwo
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            // 查找场景中所有的 OrderController 组件
            OrderController[] orderControllers = FindObjectsOfType<OrderController>();

            // 遍历所有的 OrderController
            foreach (OrderController orderController in orderControllers)
            {
                // 如果找到 orderType 为 Pizza 的 OrderController
                if (orderController.orderType == OrderController.OrderType.Milk && isPrepared)
                {
                    orderController.orderFetched = true;
                    isPrepared=false;
                    currentTime=0f;

                    if (other.CompareTag("PlayerOne"))
                    {
                        isPlayerOne = true;
                    }
                    if (other.CompareTag("PlayerTwo"))
                    {
                        isPlayerTwo = true;
                    }


                    // 如果找到一个满足条件的 OrderController，直接跳出循环
                    break;
                }
            }
        }
    }
}

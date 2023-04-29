using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkShop : MonoBehaviour
{
    public OrderController orderController;
    public Collider2D pizzaShopCollider;
    private void Start()
    {
        orderController = FindObjectOfType<OrderController>();
        pizzaShopCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("PlayerOne")||other.CompareTag("PlayerTwo")) && orderController.orderType == OrderController.OrderType.Milk)
        {
            orderController.orderFetched=true;
        }
    }
}

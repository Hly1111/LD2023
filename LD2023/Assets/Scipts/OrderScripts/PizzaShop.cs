using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShop : MonoBehaviour
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
        if ((other.CompareTag("PlayerOne")||other.CompareTag("PlayerTwo")) && orderController.orderType == OrderController.OrderType.Pizza)
        {
            orderController.orderFetched=true;
        }
    }
}

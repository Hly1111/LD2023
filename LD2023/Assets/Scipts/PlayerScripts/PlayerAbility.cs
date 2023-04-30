using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    //扩容背包
    //快速电瓶车
    //截获订单
    public PlayerOneController player_1;
    public PlayerTwoController player_2;
    public PizzaShop pizzaShop;
    public MilkShop milkShop;
    public BurgerShop burgerShop;

    public void Start()
    {
        player_1 = FindObjectOfType<PlayerOneController>();
        player_2 = FindObjectOfType<PlayerTwoController>();
        pizzaShop = FindObjectOfType<PizzaShop>();
        milkShop = FindObjectOfType<MilkShop>();
        burgerShop = FindObjectOfType<BurgerShop>();
    }
    public void Update(){

    }
}

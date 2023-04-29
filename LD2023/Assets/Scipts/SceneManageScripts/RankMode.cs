using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankMode : MonoBehaviour
{
    public PlayerOneController playerOneController;
    public PlayerTwoController playerTwoController;
    public PizzaShop pizzaShop;
    public MilkShop milkShop;   
    public BurgerShop burgerShop;
    public OrderController orderController;
    public void Start(){
        playerOneController=FindObjectOfType<PlayerOneController>();
        playerTwoController=FindObjectOfType<PlayerTwoController>();
        pizzaShop=FindObjectOfType<PizzaShop>();
        milkShop=FindObjectOfType<MilkShop>();
        burgerShop=FindObjectOfType<BurgerShop>();
        orderController=FindObjectOfType<OrderController>();
    }
    public void Update(){
        Punish();
    }
    public void Punish(){
        if(orderController.isTimeOut){
            if(pizzaShop.isPlayerOne){
                //koufen
                pizzaShop.isPlayerOne=false;
                }
            if(milkShop.isPlayerOne){
                //koufen
                milkShop.isPlayerOne=false;
                }
            if(burgerShop.isPlayerOne){
                //koufen
                burgerShop.isPlayerOne=false;
                }
            if(pizzaShop.isPlayerTwo){
                //koufen
                pizzaShop.isPlayerTwo=false;
                }
            if(milkShop.isPlayerTwo){
                //koufen
                milkShop.isPlayerTwo=false;
                }
            if(burgerShop.isPlayerTwo){
                //koufen
                burgerShop.isPlayerTwo=false;
                }
        }
        
    }
    public void Prize(){
        if(orderController.isPlayerOne){
            //jiangli
            orderController.isPlayerOne=false;
        }
        if(orderController.isPlayerTwo){
            //jiangli
            orderController.isPlayerTwo=false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RankMode : MonoBehaviour
{
    public PlayerOneController playerOneController;
    public PlayerTwoController playerTwoController;
    public PizzaShop pizzaShop;
    public MilkShop milkShop;   
    public BurgerShop burgerShop;
    public OrderController orderController;
    public Image endGame;
    public Text[] endGameText;
    public int[] playerMarks=new int[2];
    public float gameTime=300f;
    public float currentTime;
    public void Start(){
        playerOneController=FindObjectOfType<PlayerOneController>();
        playerTwoController=FindObjectOfType<PlayerTwoController>();
        pizzaShop=FindObjectOfType<PizzaShop>();
        milkShop=FindObjectOfType<MilkShop>();
        burgerShop=FindObjectOfType<BurgerShop>();
        orderController=FindObjectOfType<OrderController>();
        endGame=FindObjectOfType<Image>();
        endGame.enabled=false;
        endGameText[0].enabled=false;
        endGameText[1].enabled=false;
        endGameText[2].enabled=false;
    }
    public void Update(){
        Punish();
        Prize ();
        GameMatch();
    }
    public void Punish(){
        if(orderController.isTimeOut){
            if(pizzaShop.isPlayerOne){
                playerMarks[0]-=15;
                pizzaShop.isPlayerOne=false;
                }
            if(milkShop.isPlayerOne){
                playerMarks[0]-=10;
                milkShop.isPlayerOne=false;
                }
            if(burgerShop.isPlayerOne){
                playerMarks[0]-=20;
                burgerShop.isPlayerOne=false;
                }
            if(pizzaShop.isPlayerTwo){
                playerMarks[1]-=15;
                pizzaShop.isPlayerTwo=false;
                }
            if(milkShop.isPlayerTwo){
                playerMarks[1]-=10;
                milkShop.isPlayerTwo=false;
                }
            if(burgerShop.isPlayerTwo){
                playerMarks[1]-=20;
                burgerShop.isPlayerTwo=false;
                }
        }
        
    }
    public void Prize(){
        if(orderController.isPlayerOne){
            playerMarks[0]+=10;
            orderController.isPlayerOne=false;
        }
        if(orderController.isPlayerTwo){
            playerMarks[1]+=10;
            orderController.isPlayerTwo=false;
        }
    }
    public void GameMatch(){
        currentTime+=Time.deltaTime;
        if(currentTime>=gameTime){
            currentTime=gameTime;
            
            if(playerMarks[0]>playerMarks[1]){
                endGame.enabled=true;
                endGameText[0].enabled=true;
            }
            else if(playerMarks[0]<playerMarks[1]){
                endGame.enabled=true;
                endGameText[1].enabled=true;
            }
            else{
                endGame.enabled=true;
                endGameText[2].enabled=true;
            }
        }
    }
}

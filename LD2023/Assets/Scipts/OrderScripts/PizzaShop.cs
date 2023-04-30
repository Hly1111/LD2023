using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PizzaShop : MonoBehaviour
{
    public Collider2D pizzaShopCollider;
    public PlayerOneController player_1;
    public PlayerTwoController player_2;
    public Image[] pizzaUI;
    public GameObject ready;
    public AudioClip[] pizzaShopAudioClip=new AudioClip[2];
    public bool isPlayerOne;
    public bool isPlayerTwo;
    public float prepareTime=15f;
    public float currentTime;
    public bool isPrepared=false;

    private void Start()
    {
        pizzaShopCollider = GetComponent<Collider2D>();
        player_1 = FindObjectOfType<PlayerOneController>();
        player_2 = FindObjectOfType<PlayerTwoController>();
        pizzaShopAudioClip[0]=Resources.Load<AudioClip>("Audio/Order/Prepared");
        pizzaShopAudioClip[1]=Resources.Load<AudioClip>("Audio/Order/Taken");
        ready.SetActive(false);          
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
            ready.SetActive(true);
            AudioSource.PlayClipAtPoint(pizzaShopAudioClip[0],transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否碰撞的物体是 PlayerOne 或 PlayerTwo
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            // 查找场景中所有的 OrderController 组件
            OrderController[] orderControllers = FindObjectsOfType<OrderController>();
            List<OrderController> eligibleOrderControllers = new List<OrderController>();

            foreach (OrderController orderController in orderControllers)
            {
                if (orderController.orderType == OrderController.OrderType.Pizza && isPrepared)
                {
                    eligibleOrderControllers.Add(orderController);
                }
                else
                {
                    orderController.orderFetched = false;
                }
            }

            if (eligibleOrderControllers.Count > 0)
            {
                int randomIndex = Random.Range(0, eligibleOrderControllers.Count);
                OrderController randomOrderController = eligibleOrderControllers[randomIndex];
                randomOrderController.orderFetched = true;
                isPrepared = false;
                currentTime = 0f;
                AudioSource.PlayClipAtPoint(pizzaShopAudioClip[1], transform.position);
                ready.SetActive(false);
                if (other.CompareTag("PlayerOne"))
                {
                    isPlayerOne = true;
                    pizzaUI[0].enabled=true;
                }
                if (other.CompareTag("PlayerTwo"))
                {
                    isPlayerTwo = true;
                    pizzaUI[1].enabled=true;
                }
            }

            
            if(player_1.isBagExpand&&player_1.bagCapacity==2&&isPrepared){
                isPrepared=false;
                currentTime=0f;
                AudioSource.PlayClipAtPoint(pizzaShopAudioClip[1],transform.position);
                ready.SetActive(false);
                pizzaUI[0].enabled=true;
                player_1.additionalFood=0;
                player_1.bagCapacity=1;
            }
            if(player_2.isBagExpand&&player_2.bagCapacity==2&&isPrepared){
                isPrepared=false;
                currentTime=0f;
                AudioSource.PlayClipAtPoint(pizzaShopAudioClip[1],transform.position);
                ready.SetActive(false);
                pizzaUI[1].enabled=true;
                player_2.additionalFood=0;
                player_2.bagCapacity=1;
            }
        }
    }
}

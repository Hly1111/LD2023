using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OrderController : MonoBehaviour
{
    public PlayerOneController player_1;
    public PlayerTwoController player_2;
    public Image[] player_1UIImages;
    public Image[] player_2UIImages;

    public enum OrderType
    {
        Pizza,
        Milk,
        Burger,
    }

    public OrderType orderType;
    public Transform residentTransform;
    public AudioClip orderAudioClip;
    public GameObject[] prefabs; // 存储预制件的数组
    public GameObject spawnedPrefab; // 生成的预制件
    public Collider2D orderCollider;
    public float startTime;
    [HideInInspector]public bool firstOrderGenerated;
    public bool orderFetched;
    public bool orderFinished;
    public float orderWaitTime;//配送时间
    public bool isTimeOut;
    public bool isPlayerOne;
    public bool isPlayerTwo;
    public float[] orderTimeRestriction = new float[]{
            35f,//pizza
            25f,//milk
            25f//burger
        };//配送时间限制
    [HideInInspector]public int lastOrderNum;

    private void Start()
    {
        residentTransform = GetComponent<Transform>();
        orderCollider = GetComponent<Collider2D>();
        player_1 = FindObjectOfType<PlayerOneController>();
        player_2 = FindObjectOfType<PlayerTwoController>();
        orderAudioClip = Resources.Load<AudioClip>("Audio/Order/Received");
        LoadPrefabs();
    }

    private void Update()
    {
        TimeCount();
        OrderGenerate();
        OrderTimeOut();
    }

    private void LoadPrefabs()
    {
        prefabs = new GameObject[]
        {
            Resources.Load<GameObject>("Prefabs/Pizza"),
            Resources.Load<GameObject>("Prefabs/Milk"),
            Resources.Load<GameObject>("Prefabs/Burger")
        };
    }

    public void TimeCount()
    {
        startTime += Time.deltaTime;
    }
#region 生成订单
    public void OrderGenerate()
    {
        //第一单在5秒后生成
        if (startTime >= 5f && !firstOrderGenerated)
        {
            orderFinished = false;
            orderType = (OrderType)Random.Range(0, 3);
            lastOrderNum = (int)orderType;
            spawnedPrefab=Instantiate(prefabs[(int)orderType], residentTransform.position + new Vector3(0, 2, 0), Quaternion.identity);
            firstOrderGenerated = true;
        }
        //后续订单10秒后持续随机生成
        if (firstOrderGenerated && orderFinished)
        {                         
            orderFinished = false;            
            StartCoroutine(WaitTime()); 
        }
    }
#endregion
#region 订单配送超时
    public void OrderTimeOut()
    {
        if (orderWaitTime >= orderTimeRestriction[(int)orderType])
        {
            Destroy(spawnedPrefab);
            orderFinished = true;
            orderWaitTime = 0;
            orderFetched = false;
            if(orderFetched){
                orderFetched = false;
                isTimeOut = true;
            }
        }
    }
#endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool orderGenerated=true;
        if((other.tag == "PlayerOne"|| other.tag == "PlayerTwo")&& !orderFinished && orderFetched){
            if(other.tag == "PlayerOne"){
                player_1UIImages[(int)orderType].enabled = false;
                isPlayerOne = true;
                orderGenerated = false;
            }
            if(other.tag == "PlayerTwo"){
                player_2UIImages[(int)orderType].enabled = false;
                isPlayerTwo = true;
                orderGenerated = false;
            }          
        }
        if(other.tag == "PlayerOne"&& !orderFinished&&player_1.isBagExpand){
            if((int)orderType == player_1.additionalFood){
                player_1UIImages[(int)orderType].enabled = false;
                isPlayerOne = true;
                orderGenerated = false;
                player_1.bagCapacity=2;              
            }   
        }
        if(other.tag == "PlayerTwo"&& !orderFinished&&player_2.isBagExpand){
            if((int)orderType == player_2.additionalFood){
                player_2UIImages[(int)orderType].enabled = false;
                isPlayerTwo = true;
                orderGenerated = false;
                player_2.bagCapacity=2;              
            }   
        }
        if(!orderGenerated){
            orderFinished = true;
            orderFetched = false;
            orderWaitTime=0;
            AudioSource.PlayClipAtPoint(orderAudioClip, transform.position);
            Destroy(spawnedPrefab);
        }
    }
    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        
                     
            int newOrderNum;
            float chanceOfRepeat = 0.2f; // 重复订单的概率

    // 如果随机数大于重复概率，确保订单不重复
            if (Random.value > chanceOfRepeat)
            {
                do
            {
                newOrderNum = Random.Range(0, 3);
            }
                while (newOrderNum == lastOrderNum);
            }
            else
            {
                newOrderNum = lastOrderNum;
            }

            orderType = (OrderType)newOrderNum;
            spawnedPrefab = Instantiate(prefabs[(int)orderType], residentTransform.position + new Vector3(0, 2, 0), Quaternion.identity);
            lastOrderNum = newOrderNum;
    }
}

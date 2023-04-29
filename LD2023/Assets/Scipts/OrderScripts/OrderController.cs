using UnityEngine;

public class OrderController : MonoBehaviour
{
    public enum OrderType
    {
        Pizza,
        Milk,
        Burger,
    }

    public OrderType orderType;
    public Transform residentTransform;
    public GameObject[] prefabs; // 存储预制件的数组
    private GameObject spawnedPrefab; // 生成的预制件
    public Collider2D orderCollider;
    public float startTime;
    [HideInInspector]public bool firstOrderGenerated;
    public bool orderFetched;
    public bool orderFinished;
    public float orderWaitTime;//配送时间
    public float[] orderTimeRestriction = new float[]{
            100f,
            150f,
            200f
        };//配送时间限制

    private void Start()
    {
        residentTransform = GetComponent<Transform>();
        orderCollider = GetComponent<Collider2D>();
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
            spawnedPrefab=Instantiate(prefabs[(int)orderType], residentTransform.position + new Vector3(0, 2, 0), Quaternion.identity);
            firstOrderGenerated = true;
        }
        //后续订单10秒后持续随机生成
        if (startTime >= 10f && orderFinished)
        { 
            orderFinished = false;          
            orderType = (OrderType)Random.Range(0, 3);
            spawnedPrefab=Instantiate(prefabs[(int)orderType], residentTransform.position + new Vector3(0, 2, 0), Quaternion.identity);        
        }
        if(!orderFinished){
            orderWaitTime+=Time.deltaTime;
        }
    }
#endregion
#region 订单配送超时
    public void OrderTimeOut()
    {
        if (orderWaitTime >= orderTimeRestriction[Random.Range(0, 3)])
        {
            Destroy(spawnedPrefab);
            orderFinished = true;
            orderWaitTime = 0;
            orderFetched = false;
            //惩罚
        }
    }
#endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "PlayerOne"|| other.tag == "PlayerTwo")&& !orderFinished && orderFetched){
            orderFinished = true;
            orderFetched = false;
            orderWaitTime=0;
            Destroy(spawnedPrefab);
        }
    }
}

using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] CarController carController;
    [SerializeField] BGScroll bgScroll;
    [SerializeField] GameObject Obstacles00OBJ;
    [SerializeField] GameObject Obstacles01OBJ;
    [SerializeField] GameObject Obstacles02OBJ;

    float timer = 0;

    [Header("障害物配置の間隔の最小値(秒)")]
    [SerializeField] float interval_Limit = 0.5f;

    float instantiate_Interval = 0;

    int instantiate_Level = 0;

    //[SerializeField] float instantiate_Time_00 = 3;
    //[SerializeField] float instantiate_Time_01 = 5;
    //[SerializeField] float instantiate_Time_02 = 7;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;

        int distance_to_Interval = 3;

        // 障害物配置の間隔を設定  残り距離に応じて間隔も短くなる
        instantiate_Interval = gameController.remaining_distance * distance_to_Interval;
        if (instantiate_Interval <= interval_Limit) { instantiate_Interval = interval_Limit; }

        Debug.Log(instantiate_Interval);

        // 配置する障害物をランダムに決定
        if(bgScroll.now_Speed >= carController.accel && timer >= instantiate_Interval)
        {
            timer = 0;
            instantiate_Level = Random.Range(1, 4);
        }

        // 障害物配置
        if (gameController.isPlaying)
        {
            // 障害物1を配置
            if (instantiate_Level == 1)
            {
                Instantiate(Obstacles00OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }

            // 障害物2を配置
            if (instantiate_Level == 2)
            {
                Instantiate(Obstacles01OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }

            // 障害物3を配置
            if (instantiate_Level == 3)
            {
                Instantiate(Obstacles02OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }
        }

    }

}

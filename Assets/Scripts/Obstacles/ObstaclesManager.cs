using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    //[SerializeField] CarController carController;
    //[SerializeField] BGScroll bgScroll;

    [Header("配置する障害物")]
    [SerializeField] GameObject Obstacles01OBJ;
    [SerializeField] GameObject Obstacles02OBJ;
    [SerializeField] GameObject Obstacles03OBJ;
    [SerializeField] GameObject E_CarOBJ;

    float timer = 0;

    [Header("障害物配置の間隔の最小値(秒)")]
    [SerializeField] float interval_Limit = 0.5f;

    // 障害物物配置の間隔
    float instantiate_Interval = 0;

    // 配置する障害物の種類
    int instantiate_Level = 0;

    //----------------------------------------------------------------------------------------------------------------------
    // 以下対向車用

    [Header("何秒ごとに対向車配置の抽選をするか")]
    [SerializeField] float e_Car_Go_Time = 5;

    float e_Car_Timer = 0;

    // 
    int e_Car_Go_or_No;

    //======================================================================================================================
    void Start()
    {

    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;

        const int distance_to_Interval = 3;

        // 障害物配置の間隔を設定  残り距離に応じて間隔も短くなる
        instantiate_Interval = gameController.remaining_distance * distance_to_Interval;

        // 障害物配置の間隔が、設定した最低値を下回ったら強制的に最低値にそろえる
        if (instantiate_Interval <= interval_Limit) { instantiate_Interval = interval_Limit; }

        // 配置する障害物をランダムに決定
        if (gameController.IsRun() && timer >= instantiate_Interval)
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
                Instantiate(Obstacles01OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }

            // 障害物2を配置
            if (instantiate_Level == 2)
            {
                Instantiate(Obstacles02OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }

            // 障害物3を配置
            if (instantiate_Level == 3)
            {
                Instantiate(Obstacles03OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------
        e_Car_Timer += Time.deltaTime;

        // 対向車を配置する否かの抽選 現在 二分の一の確率で配置
        if (e_Car_Timer >= e_Car_Go_Time)
        {
            e_Car_Timer = 0;
            e_Car_Go_or_No = Random.Range(1, 3);
        }

        // 抽選の結果、e_Car_Go_or_Noが1なら対向車を配置
        if (gameController.isPlaying)
        {
            if (e_Car_Go_or_No == 1)
            {
                Instantiate(E_CarOBJ, transform.position, transform.rotation);
                e_Car_Go_or_No = 0;
            }
        }

    }

}

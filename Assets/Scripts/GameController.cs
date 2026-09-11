using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] CarController carController;
    [SerializeField] BGScroll bgScroll;
    [SerializeField] RoadkillManager roadkillManager;
    [SerializeField] RoadSystemManager roadSystemManager;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("画面のサイズ")]
    public float screen_Size_x = 1280;

    public float screen_Size_y = 720;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("ゲームプレイが現在可能かどうか")]
    public bool isPlaying = true;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("ゴールまでの距離(km)")]
    public float distance_to_goal = 0;

    [Header("経過時間")]
    public float timer = 0;

    // 秒速用
    float per_Second_Speed = 0;

    [Header("残りの距離")]
    public float remaining_distance = 0;

    // 残りの距離算出に使用するタイマー
    float remaining_distance_Counter = 0;

    [Header("スコア ゲーム開始時の値を設定可")]
    public float score = 100;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("経過時間→スコアへの換算を行ったかどうか")]
    public bool isToScore = false;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("道交法違反時にスコアからどれくらい減点するか")]
    [SerializeField] float kashitsu_Unten_Chishi = 10;
    [SerializeField] float shingo_Mushi = 5;
    [SerializeField] float speed_Ihan = 5;
    // 信号無視中の経過時間
    float shingo_Mushi_Counter = 0;

    // 速度制限中の経過時間
    float speed_Ihan_Counter = 0;

    //----------------------------------------------------------------------------------------------------------------------
    // 車が現在走行中か否か
    bool isRun = false;

    //======================================================================================================================
    void Start()
    {
        Application.targetFrameRate = 60;

        // ゴールまでの距離を残りの距離に写す
        remaining_distance = distance_to_goal;
    }

    //======================================================================================================================
    void Update()
    {
        // 走行中か否かを判断して返す
        IsRun();

        // 経過時間の計測
        Timer();

        // 残り距離の算出
        Distance();

        // 目的地に着いたらゲームプレイ中フラグをfalseに
        if (remaining_distance <= 0)
        {
            isPlaying = false;
        }

        // スコア管理
        Score();
    }

    //======================================================================================================================
    public bool IsRun()
    {
        // 走行中か否か
        if (bgScroll.now_Speed >= carController.accel) { isRun = true; }
        else { isRun = false; }

        return isRun;
    }

    //======================================================================================================================
    void Timer()
    {
        if (isPlaying)
        { timer += Time.deltaTime; }
    }

    //======================================================================================================================
    void Distance()
    {
        //------------------------------------------------------------------------------------------------------------------
        const float per_hour_to_per_second = 3600;

        // 秒速の算出
        per_Second_Speed = bgScroll.now_Speed / per_hour_to_per_second;

        //------------------------------------------------------------------------------------------------------------------
        // 1秒をカウントする
        remaining_distance_Counter += Time.deltaTime;

        // 残り距離算出 1秒ごとに残りの距離から秒速を引いていく
        if (remaining_distance > 0 && remaining_distance_Counter >= 1)
        {
            remaining_distance_Counter = 0;
            remaining_distance -= per_Second_Speed;
        }

        // 残り距離が0を下回ったら強制的に0にする
        if (remaining_distance < 0)
        {
            remaining_distance = 0;
        }
    }

    //======================================================================================================================
    public void Score()
    {
        //------------------------------------------------------------------------------------------------------------------
        //障害物轢殺時
        if (roadkillManager.isRoadkilling)
        {
            score -= kashitsu_Unten_Chishi;
            roadkillManager.isRoadkilling = false;
        }

        //------------------------------------------------------------------------------------------------------------------
        // 信号無視時
        if (roadSystemManager.isBe_Stop && isRun)
        {
            // 黄色信号時
            if(roadSystemManager.signal_Color == 2)
            {
                shingo_Mushi_Counter += Time.deltaTime;

                // 3秒ごとにスコアから減点
                if( shingo_Mushi_Counter >= 3)
                {
                    shingo_Mushi_Counter = 0;
                    score -= shingo_Mushi;
                }
            }

            // 赤信号時
            if (roadSystemManager.signal_Color == 3)
            {
                shingo_Mushi_Counter += Time.deltaTime;

                // 3秒ごとにスコアから減点
                if (shingo_Mushi_Counter >= 3)
                {
                    shingo_Mushi_Counter = 0;
                    // 黄色信号時より少し多く減点
                    score -= shingo_Mushi + (shingo_Mushi / 3);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------
        // 速度違反
        // 許容する誤差の範囲
        const float allowable_range = 3.0f;

        // 現在の速度が速度制限を超えていたら
        if (bgScroll.now_Speed > (roadSystemManager.speed_limit + allowable_range))
        {
            // スピード違反中の経過時間を計測
            speed_Ihan_Counter += Time.deltaTime;

            // 3秒ごとにスコアから減点
            if (speed_Ihan_Counter >= 3) 
            {
                speed_Ihan_Counter = 0;
                score -= speed_Ihan; 
            }
        }

        //------------------------------------------------------------------------------------------------------------------
        // 目的地到着までに経過した時間をスコアに変換して加算
        if (!isPlaying && !isToScore)
        {
            isToScore = true;
            score += (score / timer) * 100;
        }
    }
}

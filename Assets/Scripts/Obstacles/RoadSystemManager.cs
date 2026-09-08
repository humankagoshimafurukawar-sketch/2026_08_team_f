using UnityEngine;

public class RoadSystemManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    //[SerializeField] CarController carController;
    //[SerializeField] BGScroll bgScroll;

    //----------------------------------------------------------------------------------------------------------------------
    [Header("現在の信号の色  青 → 1, 黄 → 2, 赤 → 3")]
    public int signal_Color = 1;

    [Header("何秒おきに赤信号にするか")]
    [SerializeField] float red_Signal_Interval = 20;

    // 赤信号にするまでの時間
    float signal_Counter = 0;

    [Header("赤信号を何秒間持続させるか")]
    [SerializeField] float red_Signal_Time = 7;

    // 赤信号の時間を計測
    float red_Signal_Counter = 0;

    [Header("現在赤信号、または黄信号か")]
    public bool isBe_Stop = false;

    //----------------------------------------------------------------------------------------------------------------------
    // 通常時の法定速度
    const int legal_speed = 60;

    [Header("現在の速度制限")]
    public int speed_limit = legal_speed;

    // 速度制限開始用タイマー
    float speed_limit_Interval = 0;

    [Header("速度制限をかけられる時間の上限(秒)")]
    [SerializeField] float speed_limit_time = 10;

    // 速度制限用タイマー
    float speed_limit_Counter = 0;

    //[Header("表示")]
    //[SerializeField] GameObject SignalOBJ;
    //[SerializeField] GameObject OBJ;
    //[SerializeField] GameObject OBJ;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        // 信号
        Signal();

        // 速度制限
        SpeedLimit();
    }

    //======================================================================================================================
    // 信号
    void Signal()
    {
        // 赤信号にするまでの時間を計測
        if(signal_Color != 3) { signal_Counter += Time.deltaTime; }

        // 信号を黄色にする
        if (signal_Counter >= (red_Signal_Interval - 3.0f))
        {
            signal_Color = 2;
            isBe_Stop = true;
        }

        // 信号を赤にする
        if (signal_Counter >= red_Signal_Interval)
        {
            signal_Counter = 0;
            signal_Color = 3;
            isBe_Stop = true;
        }

        // 赤信号中の経過時間を計測
        if(signal_Color == 3)
        {
            red_Signal_Counter += Time.deltaTime;

            // 持続時間を超えたら経過時間を0に戻し、信号を青に
            if (red_Signal_Counter >= red_Signal_Time)
            {
                red_Signal_Counter = 0;
                signal_Color = 0;
                isBe_Stop = false;
            }
        }
    }

    //======================================================================================================================
    // 速度制限
    void SpeedLimit()
    {
        // 速度制限開始までの時間をカウント
        if (gameController.IsRun() && speed_limit >= legal_speed) 
        { speed_limit_Interval += Time.deltaTime; }

        // 30秒ごとに速度制限をかける
        if (gameController.IsRun() && speed_limit_Interval >= 30)
        {
            speed_limit_Interval = 0;
            // 30km/h ～ 50km/hまでの速度制限のうち一つをランダムにかける
            speed_limit = Random.Range(3, 6) * 10;
        }

        // 速度制限がかかっている場合
        if (speed_limit < legal_speed)
        {
            // 速度制限がかかってからの経過時間を計測
            speed_limit_Counter += Time.deltaTime;

            // 経過時間が上限を超えたら経過時間を0に戻し、速度制限を通常に戻す
            if (speed_limit_Counter >= speed_limit_time)
            {
                speed_limit_Counter = 0;
                speed_limit = legal_speed;
            }
        }
    }
}

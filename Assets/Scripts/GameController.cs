using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class GameController : MonoBehaviour
{
    [SerializeField] BGScroll bgScroll;

    [Header("画面のサイズ")]
    public float screen_Size_x = 1280;

    public float screen_Size_y = 720;

    public bool isPlaying = true;

    [Header("ゴールまでの距離(km)")]
    public float distance_to_goal = 0;

    [Header("経過時間")]
    public float timer = 0;

    // 秒速用
    float per_Second_Speed = 0;

    [Header("残りの距離")]
    public float remaining_distance = 0;

    // 残りの距離算出に使用するタイマー
    float timer_for_remaining_distance = 0;

    [Header("スコア")]
    public float score = 100;

    [Header("道交法違反時にスコアからどれくらい減算するか")]
    public float kashitsu_Unten_Chishi = 10;


    // 経過時間→スコアへの換算を行ったかどうか
    bool isToScore = false;

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
        // 経過時間の計測
        Timer();

        // 残り距離の算出
        Distance();

        // 目的地に着いたらゲームプレイ中フラグをfalseに
        if (remaining_distance <= 0)
        {
            isPlaying = false;
        }

        // スコア換算
        Score();

        Debug.Log(score);
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
        timer_for_remaining_distance += Time.deltaTime;

        // 残り距離算出 1秒ごとに残りの距離から秒速を引いていく
        if (remaining_distance > 0 && timer_for_remaining_distance >= 1)
        {
            timer_for_remaining_distance = 0;
            remaining_distance -= per_Second_Speed;
        }

        // 残り距離が0を下回ったら強制的に0にする
        if (remaining_distance < 0)
        {
            remaining_distance = 0;
        }
    }

    //======================================================================================================================
    void Score()
    {

        // 目的地到着までに経過した時間をスコアに変換して加算
        if (!isPlaying && !isToScore)
        {
            isToScore = true;
            score += (score / timer) * 100;
        }

    }
}

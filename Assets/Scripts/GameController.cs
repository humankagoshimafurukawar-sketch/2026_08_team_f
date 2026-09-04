using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class GameController : MonoBehaviour
{
    [SerializeField] BGScroll bgScroll;

    [Header("画面のサイズ")]
    public float screen_Size_x = 1280;

    public float screen_Size_y = 720;

    //bool isPlaying;

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
        if (remaining_distance > 0)
        { timer += Time.deltaTime; }

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
        if(remaining_distance < 0) { remaining_distance = 0; }

        Debug.Log(per_Second_Speed);
    }
}

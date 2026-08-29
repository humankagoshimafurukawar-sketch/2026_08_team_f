using UnityEngine;
using UnityEngine.UIElements;

public class BGScroll : MonoBehaviour
{
    [SerializeField] CarController CarController;

    [SerializeField] float bg_Size_y = 720;
    [SerializeField] const float up_Goal_Pos = 720;
    [SerializeField] const float down_Goal_Pos = -720;

    public float now_Speed = 0;

    // 出せる速度の上限
    [SerializeField] float max_Speed = 120;

    // 自動減速
    [SerializeField] float engine_brake = 10;

    // ======================================================================================================================
    void Start()
    {
        
    }

    // ======================================================================================================================
    void Update()
    {
        // 背景をスクロール  CarControllerのforward_or_backで進行方向を制御
        transform.Translate(0, now_Speed * CarController.forward_or_back, 0);

        // ボタン操作がなかったら自動で減速
        if(now_Speed > 0 && CarController.forward_or_back == 0)
        {
            now_Speed -= engine_brake;
        }

        // 速度上限
        SpeedLimiter();

        // 背景スクロールの動きを作る
        BGPositionBack();
    }

    // ======================================================================================================================
    // 出せる速度の上限を超えたら、強制的に上限にそろえる
    void SpeedLimiter()
    {
        if(now_Speed > max_Speed) { now_Speed = max_Speed; }
    }

    //======================================================================================================================
    void BGPositionBack()
    {
        // 使用する画像の枚数
        const int bg_Number = 3;

        // 画面外下側に出たら上に移動
        if (transform.position.y > up_Goal_Pos)
        {
            transform.Translate(0, -bg_Size_y * bg_Number, 0);
        }

        // 画面外上側に出たら下に移動
        if (transform.position.y < down_Goal_Pos)
        {
            transform.Translate(0, bg_Size_y * bg_Number, 0);
        }
    }
}

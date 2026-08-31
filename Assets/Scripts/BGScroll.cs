using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] CarController carController;

    [SerializeField] float bg_Size_y = 720;
    [SerializeField] float up_Goal_Pos = 720;
    [SerializeField] float down_Goal_Pos = -720;

    public float now_Speed = 0;

    // 出せる速度の上限
    [SerializeField] float max_Speed = 120;

    // 自動減速
    [SerializeField] float engine_brake = 0.1f;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        // 背景スクロールの動き
        BGPosition();

        // アクセル時のスピード増加
        Accel();

        // ブレーキ時のスピード減少
        Brake();

        // 速度修正
        SpeedLimiter();

        // 自動減速
        Enginebrake();

        // 背景を移動
        MoveBG();
    }

    //======================================================================================================================
    void BGPosition()
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

    //======================================================================================================================
    // アクセル
    void Accel()
    {
        if (carController.isAccel)
        {
            now_Speed += carController.accel;
        }
    }

    // ブレーキ
    void Brake()
    {
        if (carController.isBrake && now_Speed > 0)
        {
            now_Speed -= carController.brake;
        }
    }

    //======================================================================================================================
    // 速度が最高速度を超えたり0を下回ったりしないよう修正
    void SpeedLimiter()
    {
        if (now_Speed > max_Speed) { now_Speed = max_Speed; }

        if (now_Speed < 0) { now_Speed = 0; }
    }

    // ======================================================================================================================
    // ボタン操作がなかったら自動で減速
    void Enginebrake()
    {
        if (now_Speed > 0 && !carController.isOperat)
        {
            now_Speed -= engine_brake;
        }
    }

    //======================================================================================================================
    // 背景を上下に動かす
    void MoveBG()
    {
        transform.Translate(0, now_Speed * carController.forward_or_back, 0);
    }
}

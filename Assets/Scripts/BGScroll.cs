using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] CarController CarController;

    public float now_Speed = 0;

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
    }
}

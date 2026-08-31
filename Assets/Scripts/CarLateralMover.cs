using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CarLateralMover : MonoBehaviour
{
    [SerializeField] CarController CarController;

    // 画面の横のサイズ
    [SerializeField] float screen_Size_x = 1280;

    void Start()
    {

    }

    void Update()
    {
        float movement_Range = screen_Size_x / 2.0f;

        if (transform.position.x >=  movement_Range) 
        { transform.position = new Vector3(movement_Range, transform.position.y, transform.position.z); }

        if (transform.position.x <= -movement_Range) 
        { transform.position = new Vector3(-movement_Range, transform.position.y, transform.position.z); }

        // 移動量の分だけ車本体を右か左に動かす
        transform.Translate(CarController.lateral_Move_Amount * CarController.right_or_left, 0, 0);
    }
}

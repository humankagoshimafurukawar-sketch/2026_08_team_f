using UnityEngine;

public class ObstaclesMover : MonoBehaviour
{
    GameObject gameController;
    GameController gameController_Script;

    //------------------------------------------------------------------------------------------------------------------
    GameObject bg_dummy_Center;
    BGScroll bgScroll_Script;

    //------------------------------------------------------------------------------------------------------------------
    GameObject carController;
    CarController carController_Script;

    //------------------------------------------------------------------------------------------------------------------
    [SerializeField] float move_amount = 0;

    //======================================================================================================================
    void Start()
    {
        // オブジェクトとしてのGameControllerを取得
        gameController = GameObject.Find("GameController");

        // GameControllerが持っているスクリプトを取得
        gameController_Script = gameController.GetComponent<GameController>();

        //------------------------------------------------------------------------------------------------------------------
        bg_dummy_Center = GameObject.Find("bg_dummy_Center");
        bgScroll_Script = bg_dummy_Center.GetComponent<BGScroll>();

        //------------------------------------------------------------------------------------------------------------------
        carController = GameObject.Find("CarController");
        carController_Script = carController.GetComponent<CarController>();
    }

    //======================================================================================================================
    void Update()
    {
        float movement_Range = gameController_Script.screen_Size_x / 2.0f;

        transform.Translate
            (
            -move_amount, // x軸移動量
            bgScroll_Script.now_Speed * carController_Script.forward_or_back,  // y軸移動量
            0 // z軸移動量
            );

        if (transform.position.x < -movement_Range) { Destroy(this.gameObject); }
    }
}

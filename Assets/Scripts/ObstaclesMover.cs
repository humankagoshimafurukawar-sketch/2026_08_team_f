using UnityEngine;

public class ObstaclesMover : MonoBehaviour
{
    GameObject gameController;

    GameController gameController_Script;

    [SerializeField] float move_amount = 0;

    //======================================================================================================================
    void Start()
    {
        // オブジェクトとしてのGameControllerを取得
        gameController = GameObject.Find("GameController");

        // GameControllerが持っているスクリプトを取得
        gameController_Script = gameController.GetComponent<GameController>();
    }

    //======================================================================================================================
    void Update()
    {
        float movement_Range = gameController_Script.screen_Size_x / 2.0f;

        transform.Translate(-move_amount, 0, 0);

        if (transform.position.x < -movement_Range) { Destroy(this.gameObject); }
    }
}

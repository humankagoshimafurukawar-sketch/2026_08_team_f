using UnityEngine;

public class ObstaclesMover04 : MonoBehaviour
{
    GameObject gameController;
    GameController gameController_Script;

    [Header("下方向への移動量")]
    [SerializeField] float move_amount = 7;

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
        if (transform.position.y > gameController_Script.screen_Size_y || transform.position.y < -gameController_Script.screen_Size_y)
        { Destroy(this.gameObject); }

        transform.Translate(0, -move_amount, 0);
    }

    //======================================================================================================================
    // コライダーに何かぶつかったときの動き
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 車とぶつかったら削除
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(this.gameObject);
        }
    }
}

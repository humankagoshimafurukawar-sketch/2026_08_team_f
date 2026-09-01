using UnityEngine;

public class ObstaclesMover : MonoBehaviour
{
    GameObject gameController;
    GameController gameController_Script;

    Transform BG_OBJ;

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
        transform.Translate( -move_amount, 0, 0 );

        // 画面外に出たら削除
        float movement_Range_x = gameController_Script.screen_Size_x / 2.0f;

        if (transform.position.x < -movement_Range_x) { Destroy(this.gameObject); }
        if (transform.position.y > gameController_Script.screen_Size_y || transform.position.y < -gameController_Script.screen_Size_y)
        { Destroy(this.gameObject); }
    }

    //======================================================================================================================
    // コライダーに何かぶつかったときの動き
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 背景の座標を取得して、y軸移動を背景と連動
        if (collision.gameObject.CompareTag("BG"))
        {
            BG_OBJ = collision.transform;
            transform.parent = BG_OBJ;
        }

        // 車とぶつかったら削除
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class ObstaclesMover02 : MonoBehaviour
{
    GameObject gameController;
    GameController gameController_Script;

    Transform BG_OBJ;

    Transform CarObJ_T;

    [Header("この距離に近づくまで車の左右移動を追尾")]
    public float tracking_Distance = 5;

    //======================================================================================================================
    void Start()
    {
        // オブジェクトとしてのGameControllerを取得
        gameController = GameObject.Find("GameController");

        // GameControllerが持っているスクリプトを取得
        gameController_Script = gameController.GetComponent<GameController>();

        // 指定したタグを持つオブジェクトを取得
        CarObJ_T = GameObject.FindWithTag("Car").transform;
    }

    //======================================================================================================================
    void Update()
    {
        // 車とオブジェクトの距離
        float distance = Vector3.Distance(CarObJ_T.transform.position, transform.position);

        // 一定の距離に近づくまで車の左右移動を追尾
        if (distance >= tracking_Distance) 
        { transform.position = new Vector3(CarObJ_T.transform.position.x, transform.position.y, transform.position.z); }

        if (transform.position.y > gameController_Script.screen_Size_y || transform.position.y < -gameController_Script.screen_Size_y)
        { Destroy(this.gameObject); }

        Debug.Log(distance);
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

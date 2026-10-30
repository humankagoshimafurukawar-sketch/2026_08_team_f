using UnityEngine;

public class ObstaclesMover04 : MonoBehaviour
{
    [SerializeField] Animator obsCAnim;

    GameObject gameController;
    GameController gameController_Script;

    [Header("下方向への移動量")]
    [SerializeField] float move_amount = 7;

    bool isExplosion = false;

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

        obsCAnim.SetBool("isExplosion", isExplosion);

    }

    void FixedUpdate()
    {
        transform.Translate(0, -move_amount, 0);
    }

    //======================================================================================================================
    // コライダーに何かぶつかったときの動き
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 車とぶつかったら削除
        if (!isExplosion && collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("ECar"))
        {
            isExplosion = true;
            obsCAnim.SetBool("isExplosion", isExplosion);

            Destroy(this.gameObject, 0.5f);
        }
    }
}

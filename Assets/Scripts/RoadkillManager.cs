using UnityEngine;

public class RoadkillManager : MonoBehaviour
{
    [SerializeField] GameController gameController;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        
    }

    //======================================================================================================================
    // コライダーに何かぶつかったときの動き
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 人をひき殺したらスコアから減算
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameController.score -= gameController.kashitsu_Unten_Chishi;
        }
    }
}

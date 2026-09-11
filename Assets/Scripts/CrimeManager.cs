using UnityEngine;

public class CrimeManager : MonoBehaviour
{
    [SerializeField] GameController gameController;

    public bool isRoadkilling = false;

    public bool isClash = false;

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
        // 人をひき殺したら轢殺フラグを立てる
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            isRoadkilling = true;
        }

        // 車と衝突したら衝突フラグを立てる
        if (collision.gameObject.CompareTag("Car"))
        {
            isClash = true;
        }
    }
}

using UnityEngine;

public class CrimeManager : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [SerializeField] SoundManager soundManager_Script;

    public bool isRoadkilling = false;

    public bool isClash = false;

    public bool isHodoGaHiroi = false;

    public bool isGyakuso = false;

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
            soundManager_Script.PlaySE(soundManager_Script.se_Explosion);
        }

        // 車と衝突したら衝突フラグを立てる
        if (collision.gameObject.CompareTag("ECar"))
        {
            isClash = true;
            soundManager_Script.PlaySE(soundManager_Script.se_Explosion);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 通行帯違反
        if (collision.gameObject.CompareTag("sidewalk"))
        { isHodoGaHiroi = true; }

        // 逆走
        if (collision.gameObject.CompareTag("OppositionLane"))
        { isGyakuso = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 通行帯違反
        if (collision.gameObject.CompareTag("sidewalk"))
        { isHodoGaHiroi = false; }

        // 逆走
        if (collision.gameObject.CompareTag("OppositionLane"))
        { isGyakuso = false; }
    }

    //======================================================================================================================
}

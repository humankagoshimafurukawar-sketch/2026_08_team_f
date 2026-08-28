using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    //===============================================================================================================================
    // 背景画像のサイズを記憶しておく
    public float sizeX;

    // 背景をスクロールさせる速度を設定
    public float scrollSpeed;

    // 最高速度を設定
    public float maxSpeed;

    //どれくらいの割合で減速させるかを設定
    public float brakeSpeed;

    // ゴール地点を設定
    public float goalPos;

    // 現在のスピードを記憶しておく
    private float nowSpeed = 0.1f;

    //===============================================================================================================================
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //===============================================================================================================================
    // Update is called once per frame
    void Update()
    {
        
    }

    //===============================================================================================================================
    // スクロール速度算出
    void Scroll()
    {

    }
}

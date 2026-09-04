using UnityEngine;

public class GameController : MonoBehaviour
{

    // 画面の横のサイズ
    public float screen_Size_x = 1280;

    public float screen_Size_y = 720;

    public float timer = 0;

    //======================================================================================================================
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;
    }
}

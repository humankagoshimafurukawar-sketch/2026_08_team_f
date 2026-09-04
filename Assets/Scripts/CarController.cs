using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [Header("前後移動関係")]
    // 前後判断用
    public int forward_or_back = 0;

    // 前後ボタン操作の有無を判断
    public bool isOperat = false;

    // アクセルとブレーキ
    public float accel = 50;
    public float brake = 10;

    // アクセル操作、ブレーキ操作の有無を判断
    public bool isAccel = false;
    public bool isBrake = false;

    [Header("左右移動関係")]
    // 左右判断用
    public int right_or_left = 0;

    // 左右移動量
    public float lateral_Move_Amount = 10;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        // 前後左右ボタン判定
        if (Keyboard.current != null && gameController.isPlaying)
        {
            // 前後
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                isOperat = true; 
                forward_or_back = -1;
            }
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                isOperat = true;
                forward_or_back = 1;
            }
            else { isOperat = false; }

            // 左右
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                right_or_left = 1;
            }
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                right_or_left = -1;
            }
            else { right_or_left = 0; }

        }

        // アクセル  前後どちらかのキーを押しながら、スペースキーを一回押すごとに加速
        if (Keyboard.current != null && gameController.isPlaying)
        {
            if (isOperat && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                isAccel = true;
            }
            else { isAccel = false; }
        }

        // ブレーキ  押し続けると減速
        if (Keyboard.current != null && gameController.isPlaying)
        {
            if (Keyboard.current.enterKey.isPressed)
            {
                isBrake = true;
            }
            else { isBrake = false; }
        }

    }
}

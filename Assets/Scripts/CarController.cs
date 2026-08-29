using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public BGScroll BGScroll;

    // 前後判断用
    public int forward_or_back = 0;

    public bool isOperat = false;

    // アクセルとブレーキ
    public float accel = 50;
    public float brake = 10;

    // ======================================================================================================================
    void Start()
    {
        
    }

    // ======================================================================================================================
    void Update()
    {
        // 前後ボタン判定
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                forward_or_back = -1;
                isOperat = true;
            }
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                forward_or_back = 1;
                isOperat = true;
            }
            else
            {
                isOperat = false;
            }
        }

        // アクセル  一回押すごとに加速
        if (Keyboard.current != null)
        {
            if (isOperat = true && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                BGScroll.now_Speed += accel;
            }
        }

        // ブレーキ  押し続けると減速
        if (Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.isPressed && BGScroll.now_Speed > 0)
            {
                BGScroll.now_Speed -= brake;
            }
        }
    }
}

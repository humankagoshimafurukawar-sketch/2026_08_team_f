using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public BGScroll BGScroll;

    public int forward = 0;
    public int back = 0;

    public float accel = 100;
    public float brake = 50;

    // ======================================================================================================================
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // ======================================================================================================================
    // Update is called once per frame
    void Update()
    {
        // 前後ボタン判定
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                forward = -1;
            }

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                back = 1;
            }
        }

        // アクセル
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                BGScroll.now_Speed += accel;
            }
        }

        // ブレーキ
        if (Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                BGScroll.now_Speed -= brake;
            }
        }
    }
}

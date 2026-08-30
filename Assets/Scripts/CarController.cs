using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    //public BGScroll BGScroll;

    // 前後判断用
    public int forward_or_back = 0;

    // 前後ボタン操作の有無を判断
    public bool isOperat = false;

    // アクセルとブレーキ
    public float accel = 50;
    public float brake = 10;

    // アクセルとブレーキが使用されているかを判定
    public bool isAccel = false;
    public bool isBrake = false;

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
                isOperat = true; 
                forward_or_back = -1;
            }
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                isOperat = true;
                forward_or_back = 1;
            }
            else
            {
                isOperat = false;
            }
        }

        // アクセル  前後どちらかのキーを押しながら、スペースキーを一回押すごとに加速
        if (Keyboard.current != null)
        {
            if (isOperat && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                isAccel = true;
            }
            else { isAccel = false; }
        }

        // ブレーキ  押し続けると減速
        if (Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.isPressed)
            {
                isBrake = true;
            }
            else { isBrake = false; }
        }

    }
}

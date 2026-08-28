using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    // 進行方向
    public int forward = 0;
    public int back = 0;
    public int right = 0;
    public int left = 0;

    //===============================================================================================================================
    void Start()
    {
        
    }

    //===============================================================================================================================
    void Update()
    {
        // 前後左右キー入力判定
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                forward = 1;
            }

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                back = 1;
            }
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                right = 1;
            }

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                left = 1;
            }
        }
    }
    //===============================================================================================================================
}

using UnityEngine;

public class CarLateralMover : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [SerializeField] CarController carController;

    //======================================================================================================================
    void Start()
    {

    }

    //======================================================================================================================
    void Update()
    {
        float movement_Range = gameController.screen_Size_x / 2.0f;

        if (transform.position.x >=  movement_Range) 
        { transform.position = new Vector3(movement_Range, transform.position.y, transform.position.z); }

        if (transform.position.x <= -movement_Range) 
        { transform.position = new Vector3(-movement_Range, transform.position.y, transform.position.z); }
    }

    //======================================================================================================================
    void FixedUpdate()
    {
        // 横に移動させる
        if (gameController.isPlaying) { transform.Translate(carController.lateral_Move_Amount * carController.right_or_left, 0, 0); }
    }
}

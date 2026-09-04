using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] CarController carController;
    [SerializeField] BGScroll bgScroll;
    [SerializeField] GameObject Obstacles00OBJ;
    [SerializeField] GameObject Obstacles01OBJ;
    [SerializeField] GameObject Obstacles02OBJ;

    float timer = 0;

    int instantiate_Level = 0;

    [SerializeField] float instantiate_Time_00 = 3;
    [SerializeField] float instantiate_Time_01 = 5;
    [SerializeField] float instantiate_Time_02 = 7;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;

        if (gameController.isPlaying)
        {
            // 障害物1を配置
            if (bgScroll.now_Speed >= carController.accel && instantiate_Level == 0 && timer >= instantiate_Time_00)
            {
                Instantiate(Obstacles00OBJ, transform.position, transform.rotation);
                instantiate_Level = 1;
            }

            // 障害物2を配置
            if (bgScroll.now_Speed >= carController.accel && instantiate_Level == 1 && timer >= instantiate_Time_01)
            {
                Instantiate(Obstacles01OBJ, transform.position, transform.rotation);
                instantiate_Level = 2;
            }

            // 障害物3を配置
            if (bgScroll.now_Speed >= carController.accel && instantiate_Level == 2 && timer >= instantiate_Time_02)
            {
                timer = 0;
                Instantiate(Obstacles02OBJ, transform.position, transform.rotation);
                instantiate_Level = 0;
            }
        }

    }

}

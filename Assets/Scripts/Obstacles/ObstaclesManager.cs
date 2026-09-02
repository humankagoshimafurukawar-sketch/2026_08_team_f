using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameObject Obstacles00OBJ;
    [SerializeField] GameObject Obstacles01OBJ;

    float timer = 0;

    int instantiate_Level = 0;

    [SerializeField] float instantiate_Time_00 = 3;
    [SerializeField] float instantiate_Time_01 = 5;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;

        // 障害物1を生成
        if (instantiate_Level == 0 && timer >= instantiate_Time_00)
        {
            instantiate_Level = 1;
            Instantiate(Obstacles00OBJ, transform.position, transform.rotation);
        }

        // 障害物2を生成
        if (instantiate_Level == 1 && timer >= instantiate_Time_01)
        {
            timer = 0;
            instantiate_Level = 0;
            Instantiate(Obstacles01OBJ, transform.position, transform.rotation);
        }
    }
}

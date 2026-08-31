using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameObject ObstaclesOBJ;

    float timer = 0;

    [SerializeField] float instantiate_Time = 10;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= instantiate_Time)
        {
            timer = 0;
            Instantiate(ObstaclesOBJ, transform.position, transform.rotation);
        }
    }
}

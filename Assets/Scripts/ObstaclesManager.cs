using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameObject ObstaclesOBJ;

    float timer = 0;

    [SerializeField] float instantiate_Time = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= instantiate_Time)
        {
            timer = 0;
            Instantiate(ObstaclesOBJ, transform.position, transform.rotation);
        }

        Debug.Log(timer);
    }
}

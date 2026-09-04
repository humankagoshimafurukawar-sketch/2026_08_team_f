using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] BGScroll bgScroll;

    [SerializeField] TMP_Text now_Speed_Text;
    [SerializeField] TMP_Text timer_Text;
    [SerializeField] TMP_Text distance_Text;

    void Start()
    {
        
    }

    void Update()
    {
        // 現在の速度を表示
        now_Speed_Text.text = bgScroll.now_Speed.ToString("F1") + ("km/h");

        // timerをint型に変換し、分と秒を算出
        int min = Mathf.FloorToInt(gameController.timer / 60f);
        int sec = Mathf.FloorToInt(gameController.timer % 60f);

        timer_Text.text = $"{min:00}:{sec:00}";

        // 残りの距離を表示
        distance_Text.text = gameController.remaining_distance.ToString("F1") + ("km");
    }
}

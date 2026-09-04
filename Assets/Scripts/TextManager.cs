using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] BGScroll bgScroll;

    [SerializeField] TMP_Text now_Speed_Text;
    [SerializeField] TMP_Text timer_Text;

    void Start()
    {
        
    }

    void Update()
    {
        now_Speed_Text.text = bgScroll.now_Speed.ToString("F1") + ("km");

        // timerをint型に変換し、分と秒を算出
        int min = Mathf.FloorToInt(gameController.timer / 60f);
        int sec = Mathf.FloorToInt(gameController.timer % 60f);

        timer_Text.text = $"{min:00}:{sec:00}";
    }
}

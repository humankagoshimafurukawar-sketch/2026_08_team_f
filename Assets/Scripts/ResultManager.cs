using UnityEngine;
using System;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [Header("表示テキスト")]
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text bestTimeText;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_Text rankText;

    [Header("スコアがこの点数以上ならランクA")]
    [SerializeField] float rank_A_score = 100;
    [Header("スコアがこの点数以上ならランクB")]
    [SerializeField] float rank_B_score = 80;

    float time;
    float score;

    float best_time;
    float best_score;

    //======================================================================================================================
    void Start()
    {
        //------------------------------------------------------------------------------------------------------------------
        // 記録表示
        time = PlayerPrefs.GetFloat("TIME", 0.0f);
        score = PlayerPrefs.GetFloat("SCORE", 0.0f);

        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.FloorToInt(time % 60f);

        timeText.text = "今回の走行時間 : " + $"{min:00}:{sec:00}";
        scoreText.text = "今回の得点 : " + score.ToString("F0") + "点";

        //------------------------------------------------------------------------------------------------------------------
        // ベスト記録表示
        best_time = PlayerPrefs.GetFloat("BEST_TIME", 0.0f);
        best_score = PlayerPrefs.GetFloat("BEST_SCORE", -9999f);

        int best_min = Mathf.FloorToInt(best_time / 60f);
        int best_sec = Mathf.FloorToInt(best_time % 60f);

        bestTimeText.text = "最速走行時間 : " + $"{best_min:00}:{best_sec:00}";
        bestScoreText.text = "最高得点 : " + best_score.ToString("F0") + "点";

        //------------------------------------------------------------------------------------------------------------------
        // ランク表示
        if (score > rank_A_score) { rankText.text = "優良運転者"; }
        else if (score > rank_B_score) { rankText.text = "免許停止"; }
        else { rankText.text = "今すぐ免許取り消し"; }
    }

    //======================================================================================================================
    void Update()
    {
        
    }
}

using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [Header("セーブデータの書き込みが終了したかどうか")]
    public bool isSetSaveData = false;

    //======================================================================================================================
    void Start()
    {

    }

    //======================================================================================================================
    void Update()
    {
        // プレイが終了し、経過時間がスコアに換算されたらスコアを記録
        if (!gameController.isPlaying && gameController.isToScore)
        {
            SetSaveData();
        }
    }

    //======================================================================================================================
    void SetSaveData()
    {
        // キー名 SCOREに現在のスコア、キー名 TIMEに現在のクリアタイムを記録、
        PlayerPrefs.SetFloat("SCORE", gameController.score);
        PlayerPrefs.SetFloat("TIME", gameController.timer);
        PlayerPrefs.Save();

        // キー名BEST_SCOREに保存されている値を呼び出す, BEST_SCOREがなければ0を呼び出す
        float best_Score = PlayerPrefs.GetFloat("BEST_SCORE", 0);

        if (gameController.score > best_Score)
        {
            PlayerPrefs.SetFloat("BEST_SCORE", gameController.score);
            PlayerPrefs.Save();
        }

        // キー名BEST_TIMEに保存されている値を呼び出す, BEST_TIMEがなければ0を呼び出す
        float best_Time = PlayerPrefs.GetFloat("BEST_TIME", 0);

        if (gameController.timer < best_Time)
        {
            PlayerPrefs.SetFloat("BEST_TIME", gameController.timer);
            PlayerPrefs.Save();
        }

        //　セーブデータの書き込み完了フラグを立てる
        isSetSaveData = true;
    }
}

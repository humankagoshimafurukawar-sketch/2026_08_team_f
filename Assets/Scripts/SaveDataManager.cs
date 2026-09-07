using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] GameController gameController;

    //======================================================================================================================
    void Start()
    {

    }

    //======================================================================================================================
    void Update()
    {
        // プレイが終了し、経過時間がスコアに換算されたらスコアを記録
        if (!gameController.isPlaying && gameController.Score())
        {
            SetSaveData();
        }
    }

    //======================================================================================================================
    void SetSaveData()
    {
        // キー名SCOREに現在のスコアを記録
        PlayerPrefs.SetFloat("SCORE", gameController.score);
        PlayerPrefs.Save();

        // キー名BEST SCOREに保存されている値を呼び出す, BEST SCOREがなければ0を呼び出す
        float best_Score = PlayerPrefs.GetFloat("BEST SCORE", 0);

        if (gameController.score > best_Score)
        {
            PlayerPrefs.SetFloat("BEST SCORE", gameController.score);
            PlayerPrefs.Save();
        }

        Debug.Log(PlayerPrefs.GetFloat("SCORE", 39393));
        Debug.Log(PlayerPrefs.GetFloat("BEST SCORE", 0));
    }
}

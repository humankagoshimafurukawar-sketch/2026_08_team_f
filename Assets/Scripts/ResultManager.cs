using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour

{
    [SerializeField] SaveDataManager saveDataManager;

    [Header("プレイ終了時に何秒待ってからリザルト画面に移行するか")]
    [SerializeField] float invoke_Time = 1;

    //======================================================================================================================
    void Start()
    {
        
    }

    //======================================================================================================================
    void Update()
    {
        // 現在のシーンがリザルトシーンでなく、かつセーブデータの書き込みが完了しているなら
        if (SceneManager.GetActiveScene().name != "ResultScene" && saveDataManager.isSetSaveData)
        {
            // invoke_Time秒待ってからLoadResultSceneを実行
            Invoke("LoadResultScene", invoke_Time);
        }
    }

    //======================================================================================================================
    // リザルトシーンの読み込み
    void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}

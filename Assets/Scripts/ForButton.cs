using UnityEngine;
using UnityEngine.SceneManagement;

public class ForButton : MonoBehaviour
{
    //======================================================================================================================
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //======================================================================================================================
    public void LoadRuleScene()
    {
        SceneManager.LoadScene("RuleScene");
    }

    //======================================================================================================================
    public void LoadMaineScene()
    {
        SceneManager.LoadScene("MaineScene");
    }

    //======================================================================================================================
    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}

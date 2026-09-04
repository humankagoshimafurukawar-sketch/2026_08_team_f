using UnityEngine;
using UnityEngine.SceneManagement;

public class TitelScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

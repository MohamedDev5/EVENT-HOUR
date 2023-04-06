using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Button reloadButton;

    void Start()
    {
        reloadButton.onClick.AddListener(ReloadSceneOnClick);
    }

    void ReloadSceneOnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
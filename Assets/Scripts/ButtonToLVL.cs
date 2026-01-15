using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonToLVL : MonoBehaviour
{
    public enum ButtonAction
    {
        LoadScene,
        QuitGame
    }

    [SerializeField] private ButtonAction action;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ExecuteAction);
    }

    private void ExecuteAction()
    {
        switch (action)
        {
            case ButtonAction.LoadScene:
                SceneManager.LoadScene(sceneName);
                break;

            case ButtonAction.QuitGame:
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                break;
        }
    }
}



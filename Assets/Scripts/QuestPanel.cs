using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [Header("Quest Sub Panels")]
    public GameObject characterPanel;
    public GameObject gamePanel;
    public GameObject checkPanel;

    public void HideAll()
    {
        characterPanel.SetActive(false);
        gamePanel.SetActive(false);
        checkPanel.SetActive(false);
    }

    public void ShowCharacter()
    {
        HideAll();
        characterPanel.SetActive(true);
    }

    public void ShowGame()
    {
        HideAll();
        gamePanel.SetActive(true);
    }

    public void ShowCheck()
    {
        HideAll();
        checkPanel.SetActive(true);
    }
}

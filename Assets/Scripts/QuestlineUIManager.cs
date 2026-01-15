using UnityEngine;
using UnityEngine.UI;

public class QuestlineUIManager : MonoBehaviour
{
    [Header("Questline")]
    [SerializeField] private QuestPanel[] questline;
    private int currentQuestIndex;
    private QuestPanel currentQuest;

    [Header("Global Panels")]
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject winScreen;

    [Header("Global Timer")]
    [SerializeField] private Slider timerSlider;
    [SerializeField] private float gameTime = 10f;

    [Header("End Screens (Last Quest Only)")]
    [SerializeField] private GameObject endFailScreen;
    [SerializeField] private GameObject endWinScreen;


    private float currentTimer;
    private bool gameRunning;
    private bool IsLastQuest =>
    currentQuestIndex == questline.Length - 1;

    private void Start()
    {
        timerSlider.gameObject.SetActive(false);
        StartQuest();
    }

    private void Update()
    {
        if (!gameRunning) return;

        currentTimer -= Time.deltaTime;

        timerSlider.value = currentTimer / gameTime;

        if (currentTimer <= 0f)
        {
            gameRunning = false;
            timerSlider.gameObject.SetActive(false);
            ShowFail();
        }
    }

    // =====================
    // Quest Flow
    // =====================

    private void StartQuest()
    {
        HideAll();
        currentQuest = questline[currentQuestIndex];
        currentQuest.gameObject.SetActive(true);
        currentQuest.ShowCharacter();
    }

    private void HideAll()
    {
        foreach (QuestPanel quest in questline)
        {
            quest.gameObject.SetActive(false);
        }

        failScreen.SetActive(false);
        winScreen.SetActive(false);

        if (endFailScreen != null) endFailScreen.SetActive(false);
        if (endWinScreen != null) endWinScreen.SetActive(false);

        timerSlider.gameObject.SetActive(false);
        gameRunning = false;
    }


    public void StartGame()
    {
        currentQuest.ShowGame();

        currentTimer = gameTime;
        gameRunning = true;

        timerSlider.value = 1f;
        timerSlider.gameObject.SetActive(true);
    }

    public void OpenCheck()
    {
        gameRunning = false;
        timerSlider.gameObject.SetActive(false);
        currentQuest.ShowCheck();
    }

    public void ShowFail()
    {
        HideAll();

        if (IsLastQuest && endFailScreen != null)
        {
            endFailScreen.SetActive(true);
        }
        else
        {
            failScreen.SetActive(true);
        }
    }

    public void ShowWin()
    {
        HideAll();

        if (IsLastQuest && endWinScreen != null)
        {
            endWinScreen.SetActive(true);
        }
        else
        {
            winScreen.SetActive(true);
        }
    }


    public void NextQuest()
    {
        currentQuestIndex++;

        if (currentQuestIndex >= questline.Length)
        {
            Debug.Log("Questline completed");
            return;
        }

        StartQuest();
    }
}

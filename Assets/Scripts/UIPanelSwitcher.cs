using UnityEngine;

public class UIPanelSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    private void Start()
    {
        HideAllPanels();
    }

    public void ShowPanel(GameObject panelToShow)
    {
        HideAllPanels();

        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
        }
    }

    private void HideAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}

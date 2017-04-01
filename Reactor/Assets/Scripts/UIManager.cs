using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject creditPanel;
    // Use this for initialization
    private void Awake()
    {
        ToolBox.RegisterAsTool(this);
    }

    private void OnDestroy()
    {
        ToolBox.UnregisterTool(this);
    }

    void Start () {
        creditPanel.SetActive(false);
	}

    public void ToggleCreditsPanel()
    {
        if (creditPanel.activeSelf)
        {
            creditPanel.SetActive(false);
        } else
        {
            creditPanel.SetActive(true);
        }
    }
}

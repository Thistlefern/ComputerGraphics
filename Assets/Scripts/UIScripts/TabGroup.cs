using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public RectTransform panel0;
    public RectTransform panel1;
    public RectTransform panel2;

    public RectTransform[] tabs;
    public RectTransform currentTab;

    void ShowTab(int tabIndex)
    {
        if (currentTab != null)
        {
            currentTab.gameObject.SetActive(false);
        }
        Tabs[tabIndex].gameObject.SetActive(true);
        currentTab = Tabs[tabIndex];
    }
    public void ShowTab(RectTransform tab)
    {
        if (currentTab != null)
        {
            currentTab.gameObject.SetActive(false);
        }
        tab.gameObject.SetActive(true);
        currentTab = tab;
    }
    void HideTab()
    {
        if(currentTab != null)
        {
            currentTab.gameObject.SetActive(false);
        }
        currentTab = null;
    }
    RectTransform CurrentTab { get { return currentTab; } }
    RectTransform[] Tabs { get { return tabs; } }

    void Start()
    {
        currentTab = null;
        tabs[0] = panel0;
        tabs[1] = panel1;
        tabs[2] = panel2;

        for(int i = 0; i < Tabs.Length; i++)
        {
            tabs[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowTab(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowTab(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowTab(2);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(currentTab == null)
            {
                ShowTab(0);
            }
            else
            {
                HideTab();
            }
        }
    }
}

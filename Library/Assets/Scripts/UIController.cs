using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    GameObject _mainPanel;
    GameObject _objectPanel;
    // Start is called before the first frame update
    void Start()
    {
        _mainPanel = GameObject.Find("MainPanel");
        _objectPanel = GameObject.Find("ObjectPanel");
        _objectPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableMainPanel()
    {
        _mainPanel.SetActive(true);
        _objectPanel.SetActive(false);
    }

    public void EnableObjectPanel()
    {
        _objectPanel.SetActive(true);
        _mainPanel.SetActive(false);
    }

    public bool IsMainPanelActive()
    {
        return _mainPanel.activeSelf;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public GameObject MenuPanel;
    // Use this for initialization
    void Start()
    {
        MenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonClicked()
    {
        Application.LoadLevel("Game1");
    }
}

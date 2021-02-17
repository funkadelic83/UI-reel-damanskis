using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private VideoMenu _miniDocMenu;
    [SerializeField] private VideoMenu _comedyMenu;

    public void ToggleMiniDocMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _miniDocMenu.gameObject.SetActive(true);
    }

    public void ToggleComedyMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _comedyMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

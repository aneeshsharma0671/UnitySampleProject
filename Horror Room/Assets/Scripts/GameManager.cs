using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameWonPanel;

    public void GameWon()
    {
        Debug.Log("GameWon");
        GameWonPanel.SetActive(true);
    }
    
    public void ResetButton()
    {
        GameWonPanel.SetActive(false);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject[] characters;
    public int selectedCharacter = 0;
    public int panelCount = 0;


    public static string charName = "Kyrilios";

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void NextPanel()
    {
        panels[panelCount].SetActive(false);
        panelCount = (panelCount + 1) % panels.Length;
        panels[panelCount].SetActive(true);
    }

    public void PreviousPanel()
    {
        panels[panelCount].SetActive(false);
        panelCount--;
        if(panelCount < 0)
        {
            panelCount += panels.Length;
        }
        panels[panelCount].SetActive(true);
    }

    public void SelectCharacter()
    {
        charName = characters[selectedCharacter].name;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}

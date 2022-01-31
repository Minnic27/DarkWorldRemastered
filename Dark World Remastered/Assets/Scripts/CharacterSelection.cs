using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CharacterSelection : MonoBehaviour
{
    //Character Selection
    public GameObject[] panels;
    public GameObject[] characters;
    public int selectedCharacter = 0;
    public int panelCount = 0;

    //MapSelection
    public GameObject[] mapnames;
    public GameObject[] maps;
    public int mapNameCount = 0;
    public int mapCount = 0;

    //Character Selection
    public static string charName;
    public static string mapName = "Neighborhood";

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        charName = characters[selectedCharacter].name;
        //Debug.Log(characters[selectedCharacter]);
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
        charName = characters[selectedCharacter].name;
        //Debug.Log(characters[selectedCharacter]);
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

    //MapSelection
    public void NextMapName()
    {
        mapnames[mapNameCount].SetActive(false);
        mapNameCount = (mapNameCount + 1) % mapnames.Length;
        mapnames[mapNameCount].SetActive(true);
    }

    public void PreviousMapName()
    {
        mapnames[mapNameCount].SetActive(false);
        mapNameCount--;
        if(mapNameCount < 0)
        {
            mapNameCount += mapnames.Length;
        }
        mapnames[mapNameCount].SetActive(true);
    }

    public void NextMap()
    {
        maps[mapCount].SetActive(false);
        mapCount = (mapCount + 1) % maps.Length;
        maps[mapCount].SetActive(true);
        mapName = maps[mapCount].name;
    }

    public void PreviousMap()
    {
        maps[mapCount].SetActive(false);
        mapCount--;
        if(mapCount < 0)
        {
            mapCount += maps.Length;
        }
        maps[mapCount].SetActive(true);
        mapName = maps[mapCount].name;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(mapName, LoadSceneMode.Single);
    }

}

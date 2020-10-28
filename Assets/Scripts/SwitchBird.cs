using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchBird : MonoBehaviour
{
    public GameObject[] birdList;
    private int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        birdList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
            birdList[i] = transform.GetChild(i).gameObject;

        //Ascunde toate caracterele
        foreach (GameObject go in birdList)
            go.SetActive(false);

        //Arata caracterul selectat
        if (birdList[index])
            birdList[index].SetActive(true);
    }

    public void SelectLeft()
    {
        //Ascunde caracterul curent
        birdList[index].SetActive(false);

        index--;
        if (index < 0)
            index = birdList.Length - 1;

        //Arata caracterul anterior
        birdList[index].SetActive(true);
    }

    public void SelectRight()
    {
        //Ascunde caracterul curent
        birdList[index].SetActive(false);

        index++;
        if (index == birdList.Length)
            index = 0;

        //Arata caracterul anterior
        birdList[index].SetActive(true);
    }

    public void SelectedCharacter()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
    }
}

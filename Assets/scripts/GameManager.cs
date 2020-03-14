using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public GameObject ReitMenu;
    public GameObject Menu;
    public GameObject StartMenu;
    public AudioClip SoundMenu;
    public AudioSource audioSor;

    public GameObject PauseMenu;
    public GameObject LoseMenu;

    public InputField nameInput;
    public Text score;
    public Text scoreINMenu;
    public Text PlayerName;
    [HideInInspector]public static string Name;

    public void Start()
    {


        if (ReitMenu != null)
        {
            StartMenu.SetActive(false);
            ReitMenu.SetActive(false);
            
        }
        else
        {
            PauseMenu.SetActive(false);
            LoseMenu.SetActive(false);
            if (Name == "" || Name == null) Name = "Player";
            PlayerName.text = Name;
            //Debug.Log(Name);
            score.text = "0";
        }
        audioSor.clip = SoundMenu;
    }
    

    //Buttons
    public void ReitButton()
    {
        ReitMenu.SetActive(true);
        audioSor.Play();
        ShowReitTable();

    }

    public void StartMenuButton()
    {
        Menu.SetActive(false);
        StartMenu.SetActive(true);
        audioSor.Play();
    }

    public void MenuBackButton()
    {
        if (ReitMenu != null)
        {
            ReitMenu.SetActive(false);
            StartMenu.SetActive(false);
            Menu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
            LoseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        audioSor.Play();

    }

    public void QuitGameButton()
    {
        Application.Quit();

    }

    public void StartGameButton()
    {
        Time.timeScale = 1;
        Name = nameInput.text;
        
        SceneManager.LoadScene("SampleScene");
        audioSor.Play();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("SampleScene");
        audioSor.Play();
    }

    public void PauseMenuButoon()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        audioSor.Play();
    }

    public void BackInMenuButton()
    {
        Time.timeScale = 1;
        audioSor.Play();

        SceneManager.LoadScene("Menu");
    }

    //работа с сортировкой, записью и чтением таблицы рекордов
    public static void RecordTopList(int[] score, string[] name)//Запись рекордов в базу
    {
        for(int i=0; i<10; i++)
        {
            PlayerPrefs.SetInt("Score" + Convert.ToString(i), score[i]);
            PlayerPrefs.SetString("Name" + Convert.ToString(i), name[i]);
        }
    }
    public static int[] GetScoreTopList()//Чтение очков из базы
    {
        int[] score = new int[10];
        for (int i = 0; i < 10; i++)
        {
            score[i] = PlayerPrefs.GetInt("Score" + Convert.ToString(i));
        }
        return score;
    }
    public static string[] GetNameTopList()//Чтение имен из базы
    {
        string[] name = new string[10];
        for (int i = 0; i < 10; i++)
        {
            name[i] = PlayerPrefs.GetString("Name" + Convert.ToString(i));
        }
        return name;
    }
    public static void NewTopList(string namePlayer, int ScorePlayer)
    {
        int[] score = new int[10];
        score = GetScoreTopList();
        string[] name = GetNameTopList();
        int x = 0;
        
        while( x < 10 && ScorePlayer <= score[x]) x++;
        if (x == 10) return;
        else
        {
            for (int i = 9; i > x; i--)
            {
                score[i] = score[i - 1];
                name[i] = name[i - 1];
            }
            score[x] = ScorePlayer;
            name[x] = namePlayer;
            RecordTopList(score, name);
        }

    }//создание и заись обновленной таблицы рекордов

    public static void ShowReitTable()
    {
        int[] score = GetScoreTopList();
        string[] name = GetNameTopList();
        string text;
        for(int i=0; i<10; i++)
        {
            text = Convert.ToString(i + 1) + ". " + Convert.ToString(score[i]) + " " + name[i];
            GameObject.Find("Reit" + Convert.ToString(i + 1)).GetComponent<Text>().text = text;
        }
    }
}

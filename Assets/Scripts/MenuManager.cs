using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button QuitButton;
    public Button StartButton;
    [SerializeField] private AudioClip _menuMusic;

    private void Start()
    {
        StartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        QuitButton.onClick.AddListener(() => Application.Quit());
        SoundManager.Instance.PlayMenuMusic(_menuMusic);
    }






}

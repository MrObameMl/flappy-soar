using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button PauseButton;
    public Button ResumeButton;
    public Button MenuButton;
    public GameObject PausePanel;
    public Bird Bird; // ������ �� �������
    public TMP_Text ScoreText; // ����� ��� ������ �����
    public GameObject EndPanel; // ������ ��������� ����
    public Button RestartButton; // ������ �������� 
    public Button ExitButton; // ������ ������ �� ���� 
    public TMP_Text CurrentScoreText;// ����� ��� ��������� �������� �������� �����
    public TMP_Text BestScoreText; // ����� ��� ��������� ���������� �������� �����

    private int _recordScore; // ���� ��� �������� ���������� �������� ����� (��������)
    private float _timer = 5; // ����� ����� ������� ����� �������������� 

    private void Start()
    {
        Time.timeScale = 1; // �������� ����� �� ���������� ����� ��� ��������� 
        RestartButton.onClick.AddListener(() => SceneManager.LoadScene(0)); // ������������� ����� 
        ExitButton.onClick.AddListener(() => Application.Quit());// ������� �� ����

        if (SoundManager.Instance.AudioSource.isPlaying)
        {
            SoundManager.Instance.AudioSource.Stop();
        }

        PauseButton.onClick.AddListener(PauseGame);
        ResumeButton.onClick.AddListener(ResumeGame);
        MenuButton.onClick.AddListener(OpenSceneMenu);

    }

    private void Update()
    {
        LoadScore(); // ��������� ���������� ����
        ScoreText.text = $"{Bird.Score}"; // �������� ���� �� �����

        if (Bird.Score > _recordScore) // ���� ������� ������ ����� ��� ����
        {
            _recordScore = Bird.Score; // ���������� �������� ���������
            SaveScore(); // ��������� � ������ 
        }

    }

    public IEnumerator ChangeText() // ��������, ������� ��������� ���������� ����� ���� �������� � ��������� �������
    {
        int startFontSize = 200; // ��������� ������ ������
        int targetFontSize = 150; // ������� ������ ������
        while (ScoreText.fontSize > targetFontSize) // ������� ���� �������� ������ ������ �� ��������� ��������
        {
            ScoreText.fontSize = targetFontSize; // ������������� � ���������� �������� ��������
            ScoreText.color = new Color(Random.value, Random.value, Random.value); // ������ ��������� ����
            yield return null; // ���������� ��� ����, ���� � ������� ������. �� ���� ���� ������� ������ ������ �� ������ �������!
        }

        float resetTime = 0.25f; // ����� �� ������� �� ���� ������������� ������ ���������
        yield return new WaitForSeconds(resetTime); // ��� resetTime ������ 


        ScoreText.fontSize = startFontSize; // ���������� ������� ������ ������ �� ���������
        ScoreText.color = new Color(Random.value, Random.value, Random.value); // ������ ��������� ����

        //��� ����� ���������� ������ �������� ������ 
    }

    public IEnumerator CountDown() // ��������, ������� ������ �������� ������ ������� �� ������������ ����� 
    {
        while (_timer > 0) // ������� ���� ����� �� ��������� 
        {
            _timer -= Time.deltaTime; // �������� �� �������
            ScoreText.text = $"Time To End: {_timer:F0}s"; // ������� ���� ������� �� ����� ����� �����
            yield return null; // // ���������� ��� ����, ���� � ������� ������. �� ���� ���� ����� �� ������ ����. 5...4...3...2...1...������������
        }
        EndGame(); // ����� ��������� ���� 
    }

    public void EndGame()// ����� ��������� ���� 
    {
        EndPanel.SetActive(true); // ���������� ������ ����� ���� 
        Time.timeScale = 0; // ������������ ����� 
    }

    private void SaveScore() // ��������� �������� ���������� �����
    {
        PlayerPrefs.SetInt("record", _recordScore); //����� ����������  ���������� ������� ���������� � �����  (int, float, string) ��������� �������� � _recordScore
        PlayerPrefs.Save(); // ������������ ����������
    }

    private void LoadScore() // ��������� �������� ���������� �����
    {
        _recordScore = PlayerPrefs.GetInt("record", 0); // ������� ���������� ���������� �����
        CurrentScoreText.text = $"CURRENT SCORE: {Bird.Score:D6}"; // ���������� ������� ��������� ����� �����
        BestScoreText.text = $"BEST SCORE: {_recordScore:D6}";  // ���������� ��������� ��������� ����� �����
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        PauseButton.interactable = false;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        PauseButton.interactable = true;
    }
    private void OpenSceneMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }





}


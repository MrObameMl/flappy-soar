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
    public Bird Bird; // ссылка на птицчку
    public TMP_Text ScoreText; // текст для вывода очков
    public GameObject EndPanel; // панель окончания игры
    public Button RestartButton; // кнопка рестарта 
    public Button ExitButton; // кнопка выхода из игры 
    public TMP_Text CurrentScoreText;// текст для обработки текущего значения очков
    public TMP_Text BestScoreText; // текст для обработки наилучшего значения очков

    private int _recordScore; // поле для хранения наилучшего значения очков (числовое)
    private float _timer = 5; // время через которое сцена перезагрузится 

    private void Start()
    {
        Time.timeScale = 1; // включаем время на нормальный режим без заморозки 
        RestartButton.onClick.AddListener(() => SceneManager.LoadScene(0)); // перезагружаем сцену 
        ExitButton.onClick.AddListener(() => Application.Quit());// выходим из игры

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
        LoadScore(); // загружаем наилучсший счёт
        ScoreText.text = $"{Bird.Score}"; // выводжим счёт на экран

        if (Bird.Score > _recordScore) // если набрали больше очков чем есть
        {
            _recordScore = Bird.Score; // обновлячем налучшее изначение
            SaveScore(); // сохраняем в память 
        }

    }

    public IEnumerator ChangeText() // корутина, которая позволяет выполянять какое либо действие с задержкой времени
    {
        int startFontSize = 200; // стартовый размер текста
        int targetFontSize = 150; // целевой размер текста
        while (ScoreText.fontSize > targetFontSize) // условие пока текущийц размер текста не достигнет целевого
        {
            ScoreText.fontSize = targetFontSize; // устанавливаем и обнолвляем значения размеров
            ScoreText.color = new Color(Random.value, Random.value, Random.value); // делаем рандомный цвет
            yield return null; // пропускаем код ниже, пока в условии правда. То есть пока текущий размер текста не станет целевым!
        }

        float resetTime = 0.25f; // время за которое всё выше перечисленное должно произойти
        yield return new WaitForSeconds(resetTime); // ждём resetTime секунд 


        ScoreText.fontSize = startFontSize; // возвращаем текущий размер текста на начальный
        ScoreText.color = new Color(Random.value, Random.value, Random.value); // делаем рандомный цвет

        //тем самым получается эффект мерцания текста 
    }

    public IEnumerator CountDown() // корутина, которая делает обратный отсчёт времени до перезагрузки сцены 
    {
        while (_timer > 0) // условие пока время не кончилось 
        {
            _timer -= Time.deltaTime; // забираем по секунде
            ScoreText.text = $"Time To End: {_timer:F0}s"; // выводим этот процесс на экран через текст
            yield return null; // // пропускаем код ниже, пока в условии правда. То есть пока время не станет нулём. 5...4...3...2...1...перезагрузка
        }
        EndGame(); // метод окончания игры 
    }

    public void EndGame()// метод окончания игры 
    {
        EndPanel.SetActive(true); // активируем панель конца игры 
        Time.timeScale = 0; // замораживаем время 
    }

    private void SaveScore() // сохранить прогресс начисления очков
    {
        PlayerPrefs.SetInt("record", _recordScore); //через встроенный  функционал системы сохранения в Юнити  (int, float, string) сохраняет значение в _recordScore
        PlayerPrefs.Save(); // подтверждаем сохранение
    }

    private void LoadScore() // загрузить прогресс начисления очков
    {
        _recordScore = PlayerPrefs.GetInt("record", 0); // выводим сохранённое количество очков
        CurrentScoreText.text = $"CURRENT SCORE: {Bird.Score:D6}"; // показываем текущий результат через текст
        BestScoreText.text = $"BEST SCORE: {_recordScore:D6}";  // показываем наилучший результат через текст
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


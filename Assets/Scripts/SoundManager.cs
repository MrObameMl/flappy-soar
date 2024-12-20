using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource AudioSource;
    public AudioClip MenuSound;
    public AudioClip HitSound;
    public AudioClip DieSound;
    public AudioClip PointSound;
    public AudioClip SwooshSound;
    public AudioClip WingSound;

    private void Awake()
    {
        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void PlaySound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Die:
                AudioSource.PlayOneShot(DieSound);
                break;
            case SoundType.Hit:
                AudioSource.PlayOneShot(HitSound);
                    break;
            case SoundType.Point:
                AudioSource.PlayOneShot(PointSound);
                break;
            case SoundType.Swoosh:
                AudioSource.PlayOneShot(SwooshSound, 0.1f);
                break;
            case SoundType.Wing:
                AudioSource.PlayOneShot(WingSound);
                break;
        }
    }

    public void PlayMenuMusic(AudioClip menuMusic)
    {
        AudioSource.clip = menuMusic;
        AudioSource.volume = 0.1f;
        AudioSource.loop = true;
        AudioSource.Play();
    }
    public enum SoundType
    {
        Die,
        Hit,
        Point,
        Swoosh,
        Wing
    }
}
/*
    singlton это подход написания кода при котором при помощи экземпляра класса можно обращаться к нему напрямую из любого места в коде
-----------------------------------------------
    static это ключевое слово в с#, которое указывает что (метод, переменная, свойство) или сам класс принадлежит не конкретному объекту, а всему классу в целом (сегодня в белом таанце кружимсяяяяяя)
-----------------------------------------------
    ! Обычно, когда ты создаешь объект класса, у каждого объекта есть свои копии переменных и методов (АНДРЮСИКОВ). Но если ты добавляешь static к переменной или методу, они становятся общими для всех объектов класса. То есть 1 копия на них.
-----------------------------------------------
    ! Где применяется static:
    a) Статические переменные 
    Переменная, помеченная как static, существует в одной копии для всего класса 
    public static int PlayerScore = 0;
    использование:
    GameManager.PlayerScore = 100;
    Здесь PlayerScore будет общей для всех. Если один скрипт изменит значение, это изменение увидят все другие скрипт.

    б) Статические методы
    Это методы, которые можно вызывать без создания объекта класса
    public static void PrintMessage(string message)
    {
        Debug.Log(message);
    }
    использование:
    GameManager.PrintMessage("Привет Андрюсик, ты ЖОСКИЙ СИГМА"); 
    Ты вызываешь метод через имя клааса, а не через объект.

    в) статические классы
    если класс полностью состоит из статических методов и переменных, его можно сделать static.Такие классы нельзя создавать в 
    виде объектов.

    ! Что важно знать про статик
    1  статические данные живут всё время работы программы. Статическая переменная существует пока программа работает. Это удобно, но если их слишком много это множет занимать много памяти.
     2 они общие для всех, если один скрипт изменит стат переменную, другие скрипты отреагируют на это.
    3 статик нельзя использовать с ключевым словом this или instance, к примеру, статический метод не может обращаться к переменным объекта, потому что он работает без объекта
    когда использовать статик:
    1) )))) хранилище общих данных например счет игрока глобальный таймер и настройки игры.
    2) (((( универсальные инструменты и утилиты например какие нибудь математические расчеты методы для логов
    3) ()() синглтон где один экземпляр класса доступен через статик переменную
     что лучше не делать со статиком 
    1)))))) не делать слишком много статических переменных. это может запутать код
    2(((((( если данные не должны быть общими для всех
 */
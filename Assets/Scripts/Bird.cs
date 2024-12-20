using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [HideInInspector]public int Score; // поле которое хранит в себе очки
    public float JumpForce; // сила с которпой птичка будет прыгать
    public GameManager GameManager; // ссылка на менеджер дл€ вызова методов обработки конца игры

    private Camera _camera; // ссылка на камеру 
    private Rigidbody2D _rigidbody; // ссылка на компонент физики
    private Quaternion _targetRotation; // целевой угол поворота птицы в кватернионах (ед измерени€)
    private float _angleRotation = 15f; // угол поворота 
    private float _speedRotation = 5f;// скорость поворта 
    private float _upEdgeCamera; // верхн€€ граница камеры 
    private float _soundCooldown = 0.5f;
    private float _lastSoundTime = 0f;
    private void Start()
    {
        _camera = Camera.main; // получение ссылки на камеру 
        _rigidbody = GetComponent<Rigidbody2D>(); //получение компонента физики
        float upOffsetCamera = 0.5f; // добавл€ем небольшой отступ от верхней границы камеры 
        _upEdgeCamera = _camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - upOffsetCamera; // получаем верхнюю границу камеры с отступом
    }

    private void Update()
    {
        BirdMovement();
    }

    private void BirdMovement()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) //если разово нажата Ћ ћ
        {
            _rigidbody.velocity = Vector2.up * JumpForce; // придаЄм ускорение птицы через свойство velocity - скорость физического объекта
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Wing);
        }

        _targetRotation = Quaternion.Euler(0f, 0f, _rigidbody.velocity.y > 0 ? _angleRotation: -_angleRotation); //высчитываем угол поворота птицы в зависимости от того падает она (_rigidbody.velocity.y > 0) или взлетает  (_rigidbody.velocity.y > 0)
        if (_rigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _speedRotation * Time.deltaTime);// если взлетает, то крутим модельку вверх относительно текущего поворота модельки в пространстве
        }
        else if (_rigidbody.velocity.y < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _speedRotation * Time.deltaTime);
            if (Time.time - _lastSoundTime > _soundCooldown)
            {
                _lastSoundTime = Time.time;
                SoundManager.Instance.PlaySound(SoundManager.SoundType.Swoosh);
            }
        }

        if (transform.position.y > _upEdgeCamera) // если позици€ птицы выше чем верхн€€ граница камеры
        {
            transform.position = new Vector2(transform.position.x, _upEdgeCamera); // не даЄ1м ей взлететь выше чем граница!
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision) // метод, который обрабатывает вход любого коллайдера в неос€заемую зону (триггер)
    {
        if (collision.CompareTag("Score")) // если птица проходит зону очков
        {
            GameManager.StartCoroutine(GameManager.ChangeText()); // мен€ем текст (размер и цвет)
            Score++;// увеличиваем количество очков
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Point);
        }

        if (collision.CompareTag("Finish")) // если птица проходит зону финиша
        {
            gameObject.SetActive(false); // выключаем птичку
            GameManager.StartCoroutine(GameManager.CountDown()); // запускаем обратный отсчЄт до перезагрузки сцены
        }
    }
}

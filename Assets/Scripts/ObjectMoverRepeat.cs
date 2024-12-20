using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverRepeat : MonoBehaviour
{
    public float MoveSpeed; // скорость движения земли

    private Vector2 _startPositionX; // стартовая точка земли в игровом пространстве 
    private BoxCollider2D _collider; // ссылка на коллайдер земли

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>(); // получаем коллайдер, чтобы работать с ним через скрипт!
        _startPositionX = transform.position; // устанавливаем стартовую точку в позиции, где находится земля!
    }

    private void Update()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime; // двигаем позицию земли в левом направлении с сучётом количества кадров и скорости. Это нужно для того, чтобы при просадке FPS движение оставалось плавным!
        if (transform.position.x < _startPositionX.x - _collider.size.x / 2) // условие о том, что если значение при перемещении земли по горизонтальной оси  меньше чем значение равное половине коллайдера, взятого так же по горизонтальной оси, тогда возвращаем землю в начальную точку! 
        {
            transform.position = _startPositionX;
        }
    }
}

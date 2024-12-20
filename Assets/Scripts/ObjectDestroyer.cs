using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private Camera _camera; // ссылка на камеру,которая находится на сцене
    private float _leftEdgeCamera; // поле для хранения позиции левой границы камеры

    private void Start()
    {
        _camera = Camera.main; // получаем ссылку через тег, чтобы работать с камерой. Тэг - система поиска объектов в Unity по имени!

        float leftOffsetCamera = 1f; // отступ от левой границы камеры, для того чтобы мы не видили явно как удаляются объекты! (небольшое смещение)
        _leftEdgeCamera = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - leftOffsetCamera; // получение левой границы камеры через метод, взятый у камеры ViewportToWorldPointб в котором  левый ноль означает левую границу камеры. К примеру, если хочешь взять правую границу камеры нужжно поставить единицу (1)
    }

    private void Update()
    {
        if (transform.position.x <= _leftEdgeCamera) // условие о том, что если позиция труб меньше чем левая граница камеры - трубы уничтожаются 
        {
            Destroy(gameObject);
        }
    }
}

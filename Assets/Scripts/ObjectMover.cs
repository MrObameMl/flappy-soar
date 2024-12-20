using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float MoveSpeed; // скорость движения труб

    private Transform _transform; // ссылка на компонент трансформ

    private void Start()
    {
        _transform = GetComponent<Transform>();// получаем трансформ, чтобы работать с ним через скрипт!
    }
    private void Update()
    {
        _transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime); // двигаем позицию земли в левом направлении с сучётом количества кадров и скорости. Это нужно для того, чтобы при просадке FPS движение оставалось плавным!
    }
}

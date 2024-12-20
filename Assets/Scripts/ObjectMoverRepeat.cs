using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverRepeat : MonoBehaviour
{
    public float MoveSpeed; // �������� �������� �����

    private Vector2 _startPositionX; // ��������� ����� ����� � ������� ������������ 
    private BoxCollider2D _collider; // ������ �� ��������� �����

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>(); // �������� ���������, ����� �������� � ��� ����� ������!
        _startPositionX = transform.position; // ������������� ��������� ����� � �������, ��� ��������� �����!
    }

    private void Update()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime; // ������� ������� ����� � ����� ����������� � ������� ���������� ������ � ��������. ��� ����� ��� ����, ����� ��� �������� FPS �������� ���������� �������!
        if (transform.position.x < _startPositionX.x - _collider.size.x / 2) // ������� � ���, ��� ���� �������� ��� ����������� ����� �� �������������� ���  ������ ��� �������� ������ �������� ����������, ������� ��� �� �� �������������� ���, ����� ���������� ����� � ��������� �����! 
        {
            transform.position = _startPositionX;
        }
    }
}

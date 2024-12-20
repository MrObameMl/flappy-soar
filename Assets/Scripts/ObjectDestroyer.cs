using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private Camera _camera; // ������ �� ������,������� ��������� �� �����
    private float _leftEdgeCamera; // ���� ��� �������� ������� ����� ������� ������

    private void Start()
    {
        _camera = Camera.main; // �������� ������ ����� ���, ����� �������� � �������. ��� - ������� ������ �������� � Unity �� �����!

        float leftOffsetCamera = 1f; // ������ �� ����� ������� ������, ��� ���� ����� �� �� ������ ���� ��� ��������� �������! (��������� ��������)
        _leftEdgeCamera = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - leftOffsetCamera; // ��������� ����� ������� ������ ����� �����, ������ � ������ ViewportToWorldPoint� � �������  ����� ���� �������� ����� ������� ������. � �������, ���� ������ ����� ������ ������� ������ ������ ��������� ������� (1)
    }

    private void Update()
    {
        if (transform.position.x <= _leftEdgeCamera) // ������� � ���, ��� ���� ������� ���� ������ ��� ����� ������� ������ - ����� ������������ 
        {
            Destroy(gameObject);
        }
    }
}

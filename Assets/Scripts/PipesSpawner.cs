using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject PipePrefab; // ������ �� ������, ������� ����� ���������. ���� �� ����� �������� 
    public float MaxYBorder; // ������������ ������� ������� ������ ����
    public float MinYBorder; // ����������� ������ ������� ������ ����

    private void Start()
    {
        float startSpawnTime = 0f; // �����, ����� ������� ������� ���������� ������ SpawnPipes
        float repeatSpawnTime = 2f; // �����, ����� ������� ����� ������������ ���������� ������ SpawnPipes
        InvokeRepeating(nameof(SpawnPipes), startSpawnTime, repeatSpawnTime); // �����, ������� �������� �����(SpawnPipes) ����� ����������� ����� ����� ������ ���� � ��������� ����� (����������) ����� ��������� ���������� �������

    }
    private void SpawnPipes()// �����, ������� ������� ����� 
    {
        GameObject pipe = Instantiate(PipePrefab, transform.position, Quaternion.identity); // ����� ������� Instantiate ������ ������ �� ������ ���� (PipePrefab)� ������ ��� ��������� � ������� ��������� �������� � � ������� �������� (�� ���� �� ������ ��������� � ���������� ��� ������������ ���������)
        pipe.transform.position = new Vector2(transform.position.x, Random.Range(MinYBorder, MaxYBorder)); // ���������� � ���������� ���� (������, ������� ��������� ��� ����������� � ���������! (���������)) � ������������� ��� ������� � ������ �������� �� ������

    }

}

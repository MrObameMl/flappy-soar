using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float MoveSpeed; // �������� �������� ����

    private Transform _transform; // ������ �� ��������� ���������

    private void Start()
    {
        _transform = GetComponent<Transform>();// �������� ���������, ����� �������� � ��� ����� ������!
    }
    private void Update()
    {
        _transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime); // ������� ������� ����� � ����� ����������� � ������� ���������� ������ � ��������. ��� ����� ��� ����, ����� ��� �������� FPS �������� ���������� �������!
    }
}

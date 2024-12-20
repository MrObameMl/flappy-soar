using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [HideInInspector]public int Score; // ���� ������� ������ � ���� ����
    public float JumpForce; // ���� � �������� ������ ����� �������
    public GameManager GameManager; // ������ �� �������� ��� ������ ������� ��������� ����� ����

    private Camera _camera; // ������ �� ������ 
    private Rigidbody2D _rigidbody; // ������ �� ��������� ������
    private Quaternion _targetRotation; // ������� ���� �������� ����� � ������������ (�� ���������)
    private float _angleRotation = 15f; // ���� �������� 
    private float _speedRotation = 5f;// �������� ������� 
    private float _upEdgeCamera; // ������� ������� ������ 
    private float _soundCooldown = 0.5f;
    private float _lastSoundTime = 0f;
    private void Start()
    {
        _camera = Camera.main; // ��������� ������ �� ������ 
        _rigidbody = GetComponent<Rigidbody2D>(); //��������� ���������� ������
        float upOffsetCamera = 0.5f; // ��������� ��������� ������ �� ������� ������� ������ 
        _upEdgeCamera = _camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - upOffsetCamera; // �������� ������� ������� ������ � ��������
    }

    private void Update()
    {
        BirdMovement();
    }

    private void BirdMovement()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) //���� ������ ������ ���
        {
            _rigidbody.velocity = Vector2.up * JumpForce; // ������ ��������� ����� ����� �������� velocity - �������� ����������� �������
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Wing);
        }

        _targetRotation = Quaternion.Euler(0f, 0f, _rigidbody.velocity.y > 0 ? _angleRotation: -_angleRotation); //����������� ���� �������� ����� � ����������� �� ���� ������ ��� (_rigidbody.velocity.y > 0) ��� ��������  (_rigidbody.velocity.y > 0)
        if (_rigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _speedRotation * Time.deltaTime);// ���� ��������, �� ������ �������� ����� ������������ �������� �������� �������� � ������������
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

        if (transform.position.y > _upEdgeCamera) // ���� ������� ����� ���� ��� ������� ������� ������
        {
            transform.position = new Vector2(transform.position.x, _upEdgeCamera); // �� ��1� �� �������� ���� ��� �������!
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision) // �����, ������� ������������ ���� ������ ���������� � ����������� ���� (�������)
    {
        if (collision.CompareTag("Score")) // ���� ����� �������� ���� �����
        {
            GameManager.StartCoroutine(GameManager.ChangeText()); // ������ ����� (������ � ����)
            Score++;// ����������� ���������� �����
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Point);
        }

        if (collision.CompareTag("Finish")) // ���� ����� �������� ���� ������
        {
            gameObject.SetActive(false); // ��������� ������
            GameManager.StartCoroutine(GameManager.CountDown()); // ��������� �������� ������ �� ������������ �����
        }
    }
}

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
    singlton ��� ������ ��������� ���� ��� ������� ��� ������ ���������� ������ ����� ���������� � ���� �������� �� ������ ����� � ����
-----------------------------------------------
    static ��� �������� ����� � �#, ������� ��������� ��� (�����, ����������, ��������) ��� ��� ����� ����������� �� ����������� �������, � ����� ������ � ����� (������� � ����� ������ �������������)
-----------------------------------------------
    ! ������, ����� �� �������� ������ ������, � ������� ������� ���� ���� ����� ���������� � ������� (����������). �� ���� �� ���������� static � ���������� ��� ������, ��� ���������� ������ ��� ���� �������� ������. �� ���� 1 ����� �� ���.
-----------------------------------------------
    ! ��� ����������� static:
    a) ����������� ���������� 
    ����������, ���������� ��� static, ���������� � ����� ����� ��� ����� ������ 
    public static int PlayerScore = 0;
    �������������:
    GameManager.PlayerScore = 100;
    ����� PlayerScore ����� ����� ��� ����. ���� ���� ������ ������� ��������, ��� ��������� ������ ��� ������ ������.

    �) ����������� ������
    ��� ������, ������� ����� �������� ��� �������� ������� ������
    public static void PrintMessage(string message)
    {
        Debug.Log(message);
    }
    �������������:
    GameManager.PrintMessage("������ ��������, �� ������ �����"); 
    �� ��������� ����� ����� ��� ������, � �� ����� ������.

    �) ����������� ������
    ���� ����� ��������� ������� �� ����������� ������� � ����������, ��� ����� ������� static.����� ������ ������ ��������� � 
    ���� ��������.

    ! ��� ����� ����� ��� ������
    1  ����������� ������ ����� �� ����� ������ ���������. ����������� ���������� ���������� ���� ��������� ��������. ��� ������, �� ���� �� ������� ����� ��� ������ �������� ����� ������.
     2 ��� ����� ��� ����, ���� ���� ������ ������� ���� ����������, ������ ������� ����������� �� ���.
    3 ������ ������ ������������ � �������� ������ this ��� instance, � �������, ����������� ����� �� ����� ���������� � ���������� �������, ������ ��� �� �������� ��� �������
    ����� ������������ ������:
    1) )))) ��������� ����� ������ �������� ���� ������ ���������� ������ � ��������� ����.
    2) (((( ������������� ����������� � ������� �������� ����� ������ �������������� ������� ������ ��� �����
    3) ()() �������� ��� ���� ��������� ������ �������� ����� ������ ����������
     ��� ����� �� ������ �� �������� 
    1)))))) �� ������ ������� ����� ����������� ����������. ��� ����� �������� ���
    2(((((( ���� ������ �� ������ ���� ������ ��� ����
 */
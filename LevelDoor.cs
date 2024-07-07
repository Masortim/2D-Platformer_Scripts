using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public string levelToLoad;
    private bool isPlayerInTrigger = false;

    public bool unlocked;

    public Sprite doorBottomOpen;
    public Sprite doorTopOpen;
    public Sprite doorBottomClosed;
    public Sprite doorTopClosed;

    public SpriteRenderer doorTop;
    public SpriteRenderer doorBottom;

    void Start()
    {
        PlayerPrefs.SetInt("Level1", 1);
        
        if(PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }

        if(unlocked)
        {
            doorTop.sprite = doorTopOpen;
            doorBottom.sprite = doorBottomOpen;
        }
        else
        {
            doorTop.sprite = doorTopClosed;
            doorBottom.sprite = doorBottomClosed;
        }
    }

    void Update()
    {
        // ���������, ��������� �� ����� � �������� � ������ �� ������� "Jump"
        if (isPlayerInTrigger && Input.GetButtonDown("Jump") && unlocked)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ����� ����� � �������-���������
        if (other.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // ����� ����� �� �������-����������
        if (other.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }
}
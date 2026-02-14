using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject bombPrefab;
    public float speed;
    public float leftAndRightEdge = 32f;
    public float changeDirChance;
    public float appleDropDelay;
    public float bombDropDelay;
    
    void Start()
    {
        var difficulty = GameManager.Instance.SelectedDifficulty;

        switch (difficulty)
        {
            case GameManager.Difficulty.Easy:
                // easy mode
                speed = 1f;
                changeDirChance = .05f;
                appleDropDelay = 2f;
                bombDropDelay = 10f;
                break;
            
            case GameManager.Difficulty.Medium:
                // medium mode
                speed = 5f;
                changeDirChance = .1f;
                appleDropDelay = 1f;
                bombDropDelay = 5f;
                break;
            
            case GameManager.Difficulty.Hard:
                // hard mode
                speed = 5f;
                changeDirChance = .1f;
                appleDropDelay = 1f;
                bombDropDelay = 5f;
                break;
        }
        Invoke("DropApple", appleDropDelay);
        Invoke("DropBomb", bombDropDelay);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    void DropBomb()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y += 2.5f;
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = spawnPos;
        Invoke("DropBomb", bombDropDelay);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}

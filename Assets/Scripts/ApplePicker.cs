using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -20f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public Camera mainCamera;

    void Start()
    {
        var difficulty = GameManager.Instance.SelectedDifficulty;

        switch (difficulty)
        {
            case GameManager.Difficulty.Easy:
                // easy mode
                numBaskets = 5;
                CreateBaskets();
                break;
            
            case GameManager.Difficulty.Medium:
                // medium mode
                CreateBaskets();
                break;
            
            case GameManager.Difficulty.Hard:
                // hard mode
                numBaskets = 2;
                CreateBaskets();
                mainCamera = Camera.main;
                mainCamera.transform.Rotate(0f, 0f, 180f);
                break;
        }
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Main_Menu");
        }
    }
    public void BombCaught()
    {
        GameObject[] bombArray = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject tempGO in bombArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Main_Menu");
        }
    }
    public void CreateBaskets()
    {
        basketList = new List<GameObject>();

        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
}

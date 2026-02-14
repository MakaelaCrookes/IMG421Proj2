using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum Difficulty {Easy, Medium, Hard}
    public Difficulty SelectedDifficulty;
    public void SetDifficulty(int difficultyIndex)
    {
        SelectedDifficulty = (Difficulty)difficultyIndex;
        Instance = this;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("_Game_Scene");
    }
}
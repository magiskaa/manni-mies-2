using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject loadCanvas;
    public List<GameObject> levels;
    private int currentLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Manni.OnManniCollect += AddProgress;
        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
        loadCanvas.SetActive(false);
    }

    void AddProgress(int value)
    {
        progressAmount += value;
        progressSlider.value = progressAmount;

        if (progressAmount >= 10)
        {
            loadCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNextLevel()
    {
        int nextLevel = (currentLevel == levels.Count -1) ? 0 : currentLevel + 1;
        loadCanvas.SetActive(false);

        levels[currentLevel].SetActive(false);
        levels[nextLevel].SetActive(true);
        player.transform.position = new Vector3(0, -3, 0);

        currentLevel = nextLevel;
        progressAmount = 0;
        progressSlider.value = 0;
    }
}

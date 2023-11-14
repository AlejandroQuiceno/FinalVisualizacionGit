using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public List<Sprite> levelSprites; // List of sprites
    public List<string> sceneNames; // List of scene names
    public SpriteRenderer spriteRenderer;

    private int currentIndex = 0;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.drawMode = SpriteDrawMode.Simple;
        }

        UpdateSprite();
    }

    public void NextLevel()
    {
        currentIndex = (currentIndex + 1) % levelSprites.Count;
        UpdateSprite();
    }

    public void PreviousLevel()
    {
        currentIndex = (currentIndex - 1 + levelSprites.Count) % levelSprites.Count;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (levelSprites.Count > 0 && spriteRenderer != null && sceneNames.Count > 0)
        {
            spriteRenderer.sprite = levelSprites[currentIndex];

            // Save the selected scene name to PlayerPrefs
            PlayerPrefs.SetString("SceneToLoad", sceneNames[currentIndex]);
            PlayerPrefs.Save();

            // For a real game, you might load the scene directly here using SceneManager.LoadScene
            // SceneManager.LoadScene(sceneNames[currentIndex]);
        }
    }
}

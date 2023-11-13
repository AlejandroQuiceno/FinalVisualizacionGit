using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public List<Sprite> levelSprites;  // List of sprites to display
    public SpriteRenderer spriteRenderer;

    private int currentIndex = 0;

    void Start()
    {
        if (spriteRenderer == null)
        {
            // If SpriteRenderer is not assigned, try to find one on the same GameObject
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        UpdateSprite();
    }

    // Move to the next sprite in the list
    public void NextLevel()
    {
        currentIndex = (currentIndex + 1) % levelSprites.Count;
        UpdateSprite();
    }

    // Move to the previous sprite in the list
    public void PreviousLevel()
    {
        currentIndex = (currentIndex - 1 + levelSprites.Count) % levelSprites.Count;
        UpdateSprite();
    }

    // Update the SpriteRenderer with the current sprite
    private void UpdateSprite()
    {
        if (levelSprites.Count > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = levelSprites[currentIndex];
        }
    }
}

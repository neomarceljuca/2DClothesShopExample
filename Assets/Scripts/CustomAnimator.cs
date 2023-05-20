using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    public Texture2D sourceSpriteSheet;
    public int rows = 4;
    public int columns = 9;
    public int frameHeight = 64;
    public int frameWidth = 64;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpriteByFrame(int frameNumber)
    {
        // Calculate the row and column of the frame based on the frame number
        int row = frameNumber / columns;
        int column = frameNumber % columns;

        // Invert the row to account for the reversed y-axis
        row = rows - 1 - row;

        // Create a sprite using the specified frame coordinates and size
        Rect frameRect = new Rect(column * frameWidth, row * frameHeight, frameWidth, frameHeight);
        Sprite sprite = Sprite.Create(sourceSpriteSheet, frameRect, new Vector2(0.5f, 0.5f), 32);

        //Debug.Log(frameRect + ". " + "\nFrame number " + frameNumber);
        spriteRenderer.sprite = sprite;
    }

}

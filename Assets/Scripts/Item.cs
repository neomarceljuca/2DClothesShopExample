using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public Sprite Sprite;
    public Texture2D SourceSpriteSheet;
    public int cost = 100;
}

using UnityEngine;

[System.Serializable]
public class Card
{
    private int type;
    private int numb;

    private Rect rect;
    private Texture texture;

    public bool IsAvailableDraw
    {
        get { return rect.x > 0; }
    }

    public Rect Rect
    {
        get { return this.rect; }
        set { this.rect = value; }
    }

    public Card(int type, int numb, Texture texture)
    {
        this.type = type;
        this.numb = numb;
        this.texture = texture;
    }

    public void draw()
    {
        GUI.DrawTexture(rect, texture);
    }
}
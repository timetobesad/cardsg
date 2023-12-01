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

    public Card(int type, int numb, Texture texture)
    {
        this.type = type;
        this.numb = numb;
        this.texture = texture;
    }

    public void setRect(Rect rect)
    {
        this.rect = rect;
    }

    public void draw()
    {
        GUI.DrawTexture(rect, texture);
    }
}
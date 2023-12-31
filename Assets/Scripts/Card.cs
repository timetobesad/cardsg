using UnityEngine;

[System.Serializable]
public class Card
{
    public int type;
    public int numb;

    private Rect rect;
    private Rect newRect;

    private Texture texture;

    private bool isChangedRect = false;

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

    public void smoothChangedRect()
    {
        if (!isChangedRect) return;

        if(rect == newRect)
        {
            isChangedRect = false;
            return;
        }
    }
}
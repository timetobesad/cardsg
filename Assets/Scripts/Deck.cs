using UnityEngine;
using System.Collections.Generic;

public delegate void eventClickToCard(int id);

public class Deck
{
    private List<Card> cards;

    private int countCardInLine;

    public eventClickToCard handlerClick;

    public Card[] Cards
    {
        get { return this.cards.ToArray(); }
    }

    public Deck()
    {
        this.cards = new List<Card>();
    }

    public void settings(int countCardInLine, ref List<Card> allCards)
    {
        /* rewrite driving > 6 card in deck */

        for (int i = 0; i < countCardInLine; i++)
        {
            int id = Random.Range(0, allCards.Count - 1);

            this.cards.Add(allCards[id]);
            allCards.RemoveAt(id);
        }
    }

    public void updateRect(Vector2 size, Vector2 offs)
    {
        for(int i = 0; i < cards.Count; i++)
        {
            Vector2 cardOffs = new Vector2(offs.x + (i * size.x), offs.y);
            cards[i].Rect = new Rect(cardOffs, size);
        }
    }

    public void draw()
    {
        foreach(Card card in cards)
        {
            if(!card.IsAvailableDraw)
            {
                Debug.LogError("Error drawing deck, rect card undefined!");
                break;
            }

            card.draw();
        }
    }

    public void eventHandler()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Input.mousePosition;

            Vector2 cord = new Vector2(mousePos.x, Screen.height - mousePos.y);

            for(int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Rect.Contains(cord))
                    handlerClick(i);
            }
        }
    }
}
using UnityEngine;
using System.Collections.Generic;

public delegate void eventClickToCard(int id);

[System.Serializable]
public struct offsCardConf
{
    public int count;

    public float x;
    public float y;
}

public class Deck
{
    private List<Card> cards;

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

    public void updateRect(offsCardConf conf, Vector2 size, Vector2 offs)
    {
        for(int i = 0; i < cards.Count; i++)
        {
            int xInd = i % conf.count;
            int yInd = i / conf.count;

            Vector2 cardOffs = new Vector2(offs.x + (xInd * 2) + (xInd * size.x) + (yInd > 0 ? (yInd * conf.x) : 0), offs.y + (yInd * conf.y));
            cards[i].Rect = new Rect(cardOffs, size);
        }
    }


    private void Update()
    {

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
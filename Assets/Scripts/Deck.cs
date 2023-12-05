using UnityEngine;
using System.Collections.Generic;

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

    public Card[] Cards
    {
        get { return this.cards.ToArray(); }
    }

    public Deck()
    {
        this.cards = new List<Card>();
    }

    public void settings(int countCard, ref List<Card> allCards)
    {
        for (int i = 0; i < countCard; i++)
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
}
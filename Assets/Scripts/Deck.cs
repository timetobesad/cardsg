using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct multiLineOffs
{
    public int count;

    public float x;
    public float y;
}

[System.Serializable]
public struct deckConfig
{
    public int countCard;

    public Vector2 size;
    public Vector2 offs;

    public multiLineOffs mutleOffs;
}

public class Deck
{
    private deckConfig _config;

    private List<Card> cards;

    public Card[] Cards
    {
        get { return this.cards.ToArray(); }
    }

    public Deck()
    {
        this.cards = new List<Card>();
    }

    public void settings(deckConfig deckConf, ref List<Card> allCards)
    {
        _config = deckConf;

        for (int i = 0; i < _config.countCard; i++)
        {
            int id = Random.Range(0, allCards.Count - 1);

            this.cards.Add(allCards[id]);
            allCards.RemoveAt(id);
        }
    }

    public void updateRect()
    {

        for(int i = 0; i < cards.Count; i++)
        {
            int xInd = i % _config.countCard;
            int yInd = i / _config.countCard;

            Vector2 cardOffs = new Vector2(_config.offs.x + (xInd * 2) + (xInd * _config.size.x) + (yInd > 0 ? (yInd * _config.mutleOffs.x) : 0),
                                            _config.offs.y + (yInd * _config.mutleOffs.y));

            cards[i].Rect = new Rect(cardOffs, _config.size);
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

    public void addCard(Card card)
    {
        cards.Add(card);
        updateRect();
    }

    public void removeCard(int id)
    {
        cards.RemoveAt(id);
        updateRect();
    }
}
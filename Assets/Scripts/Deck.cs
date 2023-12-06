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

    public float startOffsY;

    public Vector2 size;
    public multiLineOffs multiOffs;
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

        for (int i = 0; i < deckConf.countCard; i++)
        { 
            int id = Random.Range(0, allCards.Count - 1);

            this.cards.Add(allCards[id]);
            allCards.RemoveAt(id);
        }
    }

    public void updateRect()
    {
        int maxCount = (cards.Count > _config.multiOffs.count) ? _config.multiOffs.count : cards.Count;

        float startOffsX = (Screen.width - (_config.size.x * maxCount)) / 2;

        for (int i = 0; i < cards.Count; i++)
        {
            int xInd = i % _config.multiOffs.count;
            int yInd = i / _config.multiOffs.count;

            Vector2 cardOffs = new Vector2(startOffsX + (xInd * 2) + (xInd * _config.size.x) + (yInd > 0 ? (yInd * _config.multiOffs.x) : 0),
                                            _config.startOffsY + (yInd * _config.multiOffs.y));

            cards[i].Rect = new Rect(cardOffs, _config.size);
        }
    }

    public void draw()
    {
        foreach(Card card in cards)
            card.draw();
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
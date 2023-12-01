using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Vector2 size;

    public Vector2 playerOffsCard;
    public Vector2 enemyOffsCard;

    public int countTypeCards = 4;
    public int countCardOneType = 9;

    public int defCountCard = 6;

    public List<Card> initialiteCards;

    private Deck playerDeck;
    private Deck enemyDeck;

    private void Start()
    {
        createInitialiteCards();

        initDeck(out playerDeck, playerOffsCard);
        initDeck(out enemyDeck, enemyOffsCard);
    }

    private void OnGUI()
    {
        playerDeck.draw();
        enemyDeck.draw();
    }

    private void createInitialiteCards()
    {
        initialiteCards = new List<Card>();

        for(int i = 0; i < countTypeCards; i++)
        {
            for(int j = 0; j < countCardOneType; j++)
            {
                Texture texture = Resources.Load<Texture>(string.Format("cards/{0}_{1}", i,j));
                initialiteCards.Add(new Card(i, j, texture));
            }
        }
    }

    private void initDeck(out Deck deck, Vector2 offs)
    {
        deck = new Deck();
        deck.settings(defCountCard, ref initialiteCards);
        deck.updateRect(size, offs);
    }
}

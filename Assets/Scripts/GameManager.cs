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

    #region main card

    private int mainCardId = -1;
    private Texture[] tTypesCard;

    public Rect rMainCard;

    #endregion

    private void Start()
    {
        createInitialiteCards();

        settingMainCard();

        initDeck(out playerDeck, playerOffsCard);
        initDeck(out enemyDeck, enemyOffsCard);
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

    private void settingMainCard()
    {
        tTypesCard = new Texture[countTypeCards];

        for (int i = 0; i < countTypeCards; i++)
            tTypesCard[i] = Resources.Load(string.Format("mainTypes/mainCardIcon_{0}", i)) as Texture;

        mainCardId = Random.Range(0, countTypeCards - 1);
    }

    public void drawMainCard()
    {
        if (mainCardId < 0)
            return;

        GUI.DrawTexture(rMainCard, tTypesCard[mainCardId]);
    }

    public void drawDecks()
    {
        playerDeck.draw();
        enemyDeck.draw();
    }
}

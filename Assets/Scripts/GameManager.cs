using UnityEngine;
using System.Collections.Generic;

public enum gameState
{
    playerMove,
    enemyMove
}

public class GameManager : MonoBehaviour
{
    public GameUI ui;
    public GameLogic logic;

    public Deck[] decks;
    public deckConfig[] configs;

    public int countTypeCards = 4;
    public int countCardOneType = 9;

    private List<Card> initialiteCards;

    public Deck PlayerDeck
    {
        get { return this.decks[0]; }
    }

    public Deck EnemyDeck
    {
        get { return this.decks[1]; }
    }

    public Deck GamingDeck
    {
        get { return this.decks[2]; }
        set { this.decks[2] = value; }
}

    #region main card

    private int mainCardId = -1;
    private Texture[] tTypesCard;

    #endregion

    private gameState gameState;

    public gameState GameState
    {
        get { return this.gameState; }
    }

    private void Start()
    {
        createInitialiteCards();

        decks = new Deck[configs.Length];

        for (int i = 0; i < configs.Length; i++)
            initDeck(out decks[i], configs[i]);


        settingMainCard();

        gameState = gameState.playerMove;
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

    private void initDeck(out Deck deck, deckConfig config)
    {
        deck = new Deck();
        deck.settings(config, ref initialiteCards);
        deck.updateRect();
    }

    private void settingMainCard()
    {
        tTypesCard = new Texture[countTypeCards];

        for (int i = 0; i < countTypeCards; i++)
            tTypesCard[i] = Resources.Load(string.Format("mainTypes/mainCardIcon_{0}", i)) as Texture;

        mainCardId = Random.Range(0, countTypeCards - 1);
    }

    public void drawMainCard(Rect rect)
    {
        if (mainCardId < 0)
            return;

        GUI.DrawTexture(rect, tTypesCard[mainCardId]);
    }

    public void drawDecks()
    {
        foreach (Deck deck in decks)
            deck.draw();
    }
}
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameManager manager;

    private void Update()
    {
        switch(manager.GameState)
        {
            case gameState.playerMove:
                waitingClickOnCard();
                break;
        }
    }

    private void waitingClickOnCard()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            int cardId = -1;

            for (int i = 0; i < manager.PlayerDeck.Cards.Length; i++)
            {
                Vector2 cord = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

                if (manager.PlayerDeck.Cards[i].Rect.Contains(cord)) cardId = i;
            }

            if (cardId < 0)
                return;

            cardClickEventHandler(cardId);
        }
    }

    private void cardClickEventHandler(int id)
    {
        manager.GamingDeck.addCard(manager.PlayerDeck.Cards[id]);
        manager.PlayerDeck.removeCard(id);

        Debug.Log(manager.PlayerDeck.Cards.Length);
    }
}

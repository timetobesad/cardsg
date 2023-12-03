using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameManager manager;

    private void eventHandlerClickToCard(int cardId)
    {
        Debug.Log("CLICK TO CARD: " + cardId);
    }

    private void Update()
    {
        if(manager.GameState == gameState.playerMove && manager.PlayerDeck.Cards.Length > 0)
            manager.PlayerDeck.eventHandler();
    }

    public void subscribeEvent()
    {
        manager.PlayerDeck.handlerClick += eventHandlerClickToCard;
    }
}

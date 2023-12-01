using System.Collections;
using System.Collections.Generic;
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
        if(manager.PlayerDeck != null)
            manager.PlayerDeck.eventHandler();
    }

    public void subscribeEvent()
    {
        manager.PlayerDeck.handlerClick += eventHandlerClickToCard;
    }
}

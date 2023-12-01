using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameManager manager;

    private void OnGUI()
    {
        manager.drawDecks();
        manager.drawMainCard();
    }
}

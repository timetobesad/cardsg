using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameManager manager;

    public Rect rMainCard;

    private void OnGUI()
    {
        manager.drawDecks();
        manager.drawMainCard(rMainCard);
    }
}

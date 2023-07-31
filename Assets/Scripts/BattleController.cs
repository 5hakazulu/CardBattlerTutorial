using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    private void Awake()
    {
        instance = this;
    }

    public int startingMana = 4, maxMana = 12;
    public int playerMana;

    public int startingCardsAmount = 5;

    public enum TurnOrder { playerActive, PlayerCardAtacks, enemyActive, enemyCardAttacks}
    public TurnOrder currentPhase;

    // Start is called before the first frame update
    void Start()
    {
        playerMana = startingMana;
        UIController.instance.SetPlayerManaText(playerMana);

        DeckController.instance.DrawMultipleCards(startingCardsAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpendPlayerMana(int amoungToSpend)
    {
        playerMana = playerMana - amoungToSpend;

        if (playerMana < 0)
        {
            playerMana = 0;
        }

        UIController.instance.SetPlayerManaText(playerMana);
    }
}

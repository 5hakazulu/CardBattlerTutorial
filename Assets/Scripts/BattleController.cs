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
    public int currentPlayerMaxMana;

    public int startingCardsAmount = 5;

    public int cardsToDrawPerTurn = 2;

    public enum TurnOrder { playerActive, PlayerCardAtacks, enemyActive, enemyCardAttacks}
    public TurnOrder currentPhase;

    // Start is called before the first frame update
    void Start()
    {
        //playerMana = startingMana;
        //UIController.instance.SetPlayerManaText(playerMana);
        currentPlayerMaxMana = startingMana;
        fillPlayerMana();

        DeckController.instance.DrawMultipleCards(startingCardsAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AdvanceTurn();
        }
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

    public void fillPlayerMana()
    {

        playerMana = currentPlayerMaxMana;
        UIController.instance.SetPlayerManaText(playerMana);
    }

    public void AdvanceTurn()
    {
        currentPhase++;

        if ((int)currentPhase> System.Enum.GetValues(typeof(TurnOrder)).Length) 
        {
            currentPhase = 0;
        }

        switch (currentPhase)
        {
            case TurnOrder.playerActive:
                UIController.instance.endTurnButton.SetActive(true);
                UIController.instance.drawCardButton.SetActive(true);
                if(currentPlayerMaxMana< maxMana)
                {
                    currentPlayerMaxMana++;
                }
                fillPlayerMana();
                DeckController.instance.DrawMultipleCards(cardsToDrawPerTurn);
                break;
            case TurnOrder.PlayerCardAtacks:
                //Debug.Log("Skipping player card attacks");
                //AdvanceTurn();
                CardsPointsController.instance.PlayerAttack();
                break;
            case TurnOrder.enemyActive:
                Debug.Log("Skipping Enemy Actions");
                AdvanceTurn();
                break;
            case TurnOrder.enemyCardAttacks:
                Debug.Log("Skipping Enemy card attacks");
                AdvanceTurn();
                break;
        }
    }

    public void EndPlayerTurn()
    {
        UIController.instance.endTurnButton.SetActive(false);
        UIController.instance.drawCardButton.SetActive(false);

        AdvanceTurn();
    }
}

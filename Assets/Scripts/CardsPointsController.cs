using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPointsController : MonoBehaviour
{
    public float timeBetweenAttacks = .25f;
    public static CardsPointsController instance;

    private void Awake()
    {
        instance = this;
    }

    public CardPlacePoint[] playerCardPoints, enemyCardPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttackCo());
    }

    IEnumerator PlayerAttackCo()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);

        for (int i = 0; i < playerCardPoints.Length; i++)
        {
            if(playerCardPoints[i].activeCard != null)
            {
                if(enemyCardPoints[i].activeCard != null)
                {
                    //Attack the Enemy Card
                }
                else
                {
                    //Attack enemy overall Health.
                }
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
        }

        BattleController.instance.AdvanceTurn();
    }
}

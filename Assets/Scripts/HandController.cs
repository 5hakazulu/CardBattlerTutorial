using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    public static HandController instance;
    private void Awake()
    {
        instance = this;
    }
    public  List <Card> heldCards = new List<Card>();

    public Transform minPos, maxPos;

    public List<Vector3> cardPostions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        SetCardPostionInHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardPostionInHand()
    {
        cardPostions.Clear();
        Vector3 distanceBetweenPoints = Vector3.zero;
        if (heldCards.Count > 1)
        {
            distanceBetweenPoints = (maxPos.position-minPos.position) / (heldCards.Count - 1);
        }

        for(int i = 0; i< heldCards.Count; i++)
        {
            cardPostions.Add(minPos.position + (distanceBetweenPoints * i));
            //heldCards[i].transform.position = cardPostions[i];
            //heldCards[i].transform.rotation = minPos.rotation;
            
            //this will set where the card will move to.
            heldCards[i].MoveToPoint(cardPostions[i], minPos.rotation);

            heldCards[i].inHand = true;
            heldCards[i].handPosition = i;
        }
    }

    public void RemoveCardFromHand(Card cardToRemove)
    {
        if(heldCards[cardToRemove.handPosition]== cardToRemove)
        {
            heldCards.RemoveAt(cardToRemove.handPosition);
        }
        else
        {
            Debug.LogError("card at position " + cardToRemove.handPosition + "is nothe card  being removed from hand");
        }

        SetCardPostionInHand();
    }


    public void AddCardToHand(Card cardToAdd)
    {
        heldCards.Add(cardToAdd);
        SetCardPostionInHand();
    }
   
}

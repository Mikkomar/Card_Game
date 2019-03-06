using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    GameObject cardHighlight;
    Hand hand;

    void Start()
    {
        cardHighlight = GameObject.Find("/Canvas/Highlight");
        cardHighlight.SetActive(false);
        hand = GameObject.Find("/Canvas/HandUI").GetComponent<Hand>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            data.position = Input.mousePosition;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(data, raycastResults);
            //Debug.Log(raycastResults.Count);
            for(int i = 0; i < raycastResults.Count; i++)
            {
                if (raycastResults[i].gameObject.GetComponentInParent<Card>() != null)
                {
                    hand.organizeHand();
                    raycastResults[i].gameObject.GetComponentInParent<Card>().highlight(cardHighlight);
                    break;
                }
                else
                {
                    cardHighlight.SetActive(false);
                    hand.organizeHand();
                }
            }


        }
    }

}

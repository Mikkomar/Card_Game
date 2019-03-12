using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class GameInitializer : MonoBehaviour
{
    Hand hand;
    BoardManager boardManager;
    RectTransform canvasRectTransform;
    GameObject tempCard;

    IDbConnection sqliteConnection;
    IDbCommand sqliteCommand;
    IDataReader reader;
    string commandText;

    string cardDBPath = "/Databases/Cards/";
    string westernCards = "WesternCards.db";

    void Start()
    {
        hand = GameObject.Find("Canvas/HandUI").GetComponent<Hand>();
        boardManager = GameObject.Find("Board").GetComponent<BoardManager>();
        canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        tempCard = Resources.Load<GameObject>("Prefabs/CardTemplate");

        /* Database stuff */
        sqliteConnection = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + cardDBPath + westernCards);
        sqliteConnection.Open();
        sqliteCommand = sqliteConnection.CreateCommand();
        commandText = "SELECT Title, FlavorText, CardImage, MilitaryPowerCost, CulturePowerCost, TechnologyPowerCost, TypeID, CultureID, AgeID, CardID FROM Cards";
        //Debug.Log("URI=file:" + Application.dataPath + cardDBPath + westernCards);
        sqliteCommand.CommandText = commandText;
        reader = sqliteCommand.ExecuteReader();

        loadDatabase(cardDBPath);

        fillHand(tempCard);
        boardManager.initializeBoard();
        while (reader.Read())
        {
            testInitializeHand(sqliteConnection, sqliteCommand, reader);
        }
        reader.Close();
        reader = null;
        sqliteCommand.Dispose();
        sqliteCommand = null;
        sqliteConnection.Close();
        sqliteConnection = null;
    }

    public void fillHand(GameObject c)
    {
        for(int i = 0; i < 7; i++)
        {
            GameObject temp = Instantiate(c);
            temp.transform.SetParent(GameObject.Find("Canvas").transform.Find("HandUI").transform);
            hand.addCard(temp.GetComponent<Card>());
        }
        hand.positionHand(canvasRectTransform.sizeDelta);
        hand.organizeHand();
    }

    public void loadDatabase(string path)
    {

    }

    public GameObject getTempCard()
    {
        return tempCard;
    }

    public void testInitializeHand(IDbConnection con, IDbCommand com, IDataReader reader)
    {
        List<Card> cardsInHand = hand.getCardsInHand();
        foreach(Card c in cardsInHand)
        {
            c.setCardName(reader.GetString(0));
            Debug.Log(reader.GetString(2));
            c.setCardImage(Resources.Load<Sprite>("Images/CardImages/" + reader.GetString(2)));
            c.initializeCard();
        }
    }
}

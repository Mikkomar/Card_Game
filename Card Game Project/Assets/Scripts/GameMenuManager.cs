using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class GameMenuManager : MonoBehaviour
{
    static GameObject singleton;

    private List<Culture> cultures;
    private List<Sprite> backgroundSprites;
    private Image cultureBackgroundImage;

    IDbConnection sqliteConnection;
    IDbCommand sqliteCommand;
    IDataReader reader;
    string commandText;
    string culturesDBPath = "/Databases/Cultures/";
    string cultureDB = "Cultures.db";

    private string backgroundPath;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = transform.gameObject;
            DontDestroyOnLoad(transform.gameObject);
            setUp();
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    private void Start()
    {

    }

    public void setCultureBackground(CultureType ct)
    {
        cultureBackgroundImage = GameObject.Find("Canvas").transform.Find("Culture_Background").GetComponent<Image>();
        //cultureBackgroundImage.sprite = s;
    }

    public void setUp()
    {
        cultures = new List<Culture>();

        /* Database stuff */
        sqliteConnection = (IDbConnection)new SqliteConnection("URI=file:" + Application.dataPath + culturesDBPath + cultureDB);
        sqliteConnection.Open();
        sqliteCommand = sqliteConnection.CreateCommand();
        commandText = "SELECT Name, Menu_Flavor_Text, Menu_Background, Card_Background FROM Cultures";
        sqliteCommand.CommandText = commandText;
        reader = sqliteCommand.ExecuteReader();
        while (reader.Read())
        {
            Sprite cs = Resources.Load<Sprite>("Images/Backgrounds/" + reader.GetString(2));
            cultures.Add(new Culture(reader.GetString(0), reader.GetString(1), cs, null));
        }
        backgroundPath = Application.dataPath + "/Resources/Images/Backgrounds/";
    }
}

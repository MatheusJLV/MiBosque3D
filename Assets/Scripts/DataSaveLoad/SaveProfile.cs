using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveProfile : MonoBehaviour
{
    public static SaveProfile instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    
    public PlayerData CreatePlayerData()
    {
        return GameManager.instance.playerData;
    }

    public void SaveGame()
    {
        PlayerData data = CreatePlayerData();
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/bosque.espol");
        bf.Serialize(file, data);
        file.Close();
        Debug.LogWarning("Juego Guardado!");
    }

    public void LoadGame()
    {
        //if (SaveFileExists())
        //{
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/bosque.espol", FileMode.Open);
            PlayerData playerData=(PlayerData) bf.Deserialize(file);
            GameManager.instance.SetPlayerData(playerData);
            Debug.Log(playerData.personajeSeleccionado);
            GameManager.instance.currentStation=playerData.numEstacion;
            file.Close();
            Debug.Log("Game Loaded");
        //}
        //else
        //{
        //    Debug.Log("NO SAVEDATA");
        //}
    }

    public bool SaveFileExists(){
        return File.Exists(Application.persistentDataPath + "/bosque.espol");
    }
    /*public static void savePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/perfilTest.xd";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
            
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/perfil1.xd";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData result = (PlayerData) formatter.Deserialize(stream);

            stream.Close();

            return result;
        }
        else
        {
            Debug.LogError("Save File not found in path");
            return null;
        }
    }
*/
}

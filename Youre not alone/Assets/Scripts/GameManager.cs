using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static PlayerGO player;
    public static ShipGO ship;
    public static List<RessourceGO> ressourcesList = new List<RessourceGO>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
}

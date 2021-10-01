using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public bool canSpawnWave;

    public List<GameObject> listOfFormations = new List<GameObject>();
    public List<GameObject> listOfOpponents = new List<GameObject>();

    private GameObject waveParent;
    
    #region Singleton
    public static WaveManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
        
    
    void Start()
    {
        currentWave = 0;
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update()
    {
        if (AreEnemiesDead())
        {
            Destroy(waveParent);
            currentWave++;
            if (currentWave == listOfFormations.Count)
            {
                currentWave = 0;
            }
            waveParent = Instantiate(listOfFormations[currentWave]);
            AddEnemiesToList();
        }
    }

    void AddEnemiesToList()
    {
        listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("E"));
    }
    
    public void KilledOpponent(GameObject opponent)
    {
        if(listOfOpponents.Contains(opponent))
        {
            listOfOpponents.Remove(opponent);
        }
    }
    
    public bool AreEnemiesDead()
    {
        return (listOfOpponents.Count <= 0);
    }
}

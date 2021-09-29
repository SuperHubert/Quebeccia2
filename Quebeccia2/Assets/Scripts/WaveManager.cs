using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public bool canSpawnWave;
    
    
    public List<GameObject> listOfOpponents = new List<GameObject>();
    
    #region Singleton
    public static WaveManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
        
    
    void Start()
    {
        currentWave = 1;
    }
    
    void Update()
    {
        if (AreEnemiesDead())
        {
            //spawn wave
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
        if(listOfOpponents.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}

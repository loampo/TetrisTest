using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float dropTime = 1f;
    public static float quickDropTime = 0.05f;
    public static int width= 15, height = 30;
    [SerializeField] public GameObject[] _blocks;
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBlock()
    {
        int randomBlock = Random.Range(0, _blocks.Length);
        Instantiate(_blocks[randomBlock]);
    }
}

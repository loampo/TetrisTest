using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float dropTime = 1f;
    public static float quickDropTime = 0.05f;
    public static int width= 15, height = 30;
    [SerializeField] public GameObject[] _blocks;
    public Transform[,] _grid = new Transform[width, height];
    [SerializeField] private ScoreManager scoreManager;
    public int pointsPerLine = 100;
    void Start()
    {
        SpawnBlock();
    }

    public void ClearLines()
    {
        int linesCleared = 0;
        for (int y = 0; y < height; y++)
        {
            if (IsLineComplete(y))
            {
                DestroyLine(y);
                MoveLines(y);
                linesCleared++;
            }
        }
        int scoreIncrease = pointsPerLine * linesCleared;
        scoreManager.AddScore(scoreIncrease);
    }

    private void MoveLines(int y)
    {
        for (int i = y; i < height - 1; i++)
        {
            for (int x = 0; x < width; x++)
            {
                if (_grid[x, i + 1] != null)
                {
                    _grid[x, i] = _grid[x, i + 1];
                    _grid[x, i].gameObject.transform.position -= new Vector3(0, 1, 0);
                    _grid[x, i + 1] = null;
                }
            }
        }
    }

    private void DestroyLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(_grid[x, y].gameObject);
            _grid[x, y] = null;            
        }
    }

    private bool IsLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (_grid[x, y] == null)
            {
                return false;
            }
        }return true;
    }
    public void SpawnBlock()
    {
        int randomBlock = Random.Range(0, _blocks.Length);
        Instantiate(_blocks[randomBlock]);
    }
}

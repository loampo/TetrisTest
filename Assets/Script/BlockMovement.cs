using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private GameManager _gameManager;
    private float _timer = 0f;
    private bool _isActive = true;
    [SerializeField] private GameObject _centerBlock;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    bool isMovable()
    {
        foreach (Transform subBlock in _centerBlock.transform)
        {
            if(subBlock.transform.position.x >= GameManager.width ||
                subBlock.transform.position.x < 0 ||
                subBlock.transform.position.y < 0) return false;
        } return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            //Drop
            _timer += 1 * Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow) && _timer > GameManager.quickDropTime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                _timer = 0;
                if (!isMovable())
                {
                    _isActive = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    _gameManager.SpawnBlock();
                }
            }
            else if (_timer > GameManager.dropTime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                _timer = 0f;
                if (!isMovable())
                {
                    _isActive = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    _gameManager.SpawnBlock();
                }
            }
            //Move
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);
                if (!isMovable())
                {
                    gameObject.transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
                if (!isMovable())
                {
                    gameObject.transform.position -= new Vector3(1, 0, 0);
                }
            }
            //Rotate
            if (Input.GetKeyDown (KeyCode.UpArrow))
            {
                _centerBlock.transform.eulerAngles -= new Vector3(0, 0, 90);
                if (!isMovable())
                {
                    gameObject.transform.position += new Vector3(0, 0, 90);
                }
            }
        }
    }
}

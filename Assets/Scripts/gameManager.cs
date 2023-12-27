using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false;

    void Start()
    {
        playerWhite = new GameObject[]
        {
            Create("wR", 0, 0), Create("wN", 1, 0), Create("wB", 2, 0), Create("wQ", 3, 0),
            Create("wK", 4, 0), Create("wB", 5, 0), Create("wN", 6, 0), Create("wR", 7, 0),
            Create("wP", 0, 1), Create("wP", 1, 1), Create("wP", 2, 1), Create("wP", 3, 1),
            Create("wP", 4, 1), Create("wP", 5, 1), Create("wP", 6, 1), Create("wP", 7, 1),
        };

        playerBlack = new GameObject[]
        {
            Create("bR", 0, 7), Create("bN", 1, 7), Create("bB", 2, 7), Create("bQ", 3, 7),
            Create("bK", 4, 7), Create("bB", 5, 7), Create("bN", 6, 7), Create("bR", 7, 7),
            Create("bP", 0, 6), Create("bP", 1, 6), Create("bP", 2, 6), Create("bP", 3, 6),
            Create("bP", 4, 6), Create("bP", 5, 6), Create("bP", 6, 6), Create("bP", 7, 6),
        };

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }

    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, x - 1), Quaternion.identity);
        chessman cm = obj.GetComponent<chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        chessman cm = obj.GetComponent<chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene("MainScene");
        }
    }
}

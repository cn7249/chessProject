using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    // false: movement, true: attacking
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            // Change to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<gameManager>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        controller.GetComponent<gameManager>().SetPositionEmpty(reference.GetComponent<chessman>().GetXBoard(),
            reference.GetComponent<chessman>().GetYBoard());

        reference.GetComponent<chessman>().SetXBoard(matrixX);
        reference.GetComponent<chessman>().SetYBoard(matrixY);
        reference.GetComponent<chessman>().SetCoords();

        controller.GetComponent<gameManager>().SetPosition(reference);

        controller.GetComponent<gameManager>().NextTurn();

        reference.GetComponent<chessman>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}

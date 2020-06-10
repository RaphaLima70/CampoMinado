using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public Sprite[] emptyTexture;
    public Sprite mineTexture;

    public bool mine;

    void Start()
    {
        mine = Random.value < 0.15f;

        int x = (int)transform.localPosition.x;
        int y = (int)transform.localPosition.y;

        Grid.elements [x,y] = this;
    }

    public void LoadTexture(int adjacentCount)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTexture[adjacentCount];
        }
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        //print("Clicou");
        if (mine)
        {
            Grid.uncoverElements();
        }
        else
        {
            int x = (int)transform.localPosition.x;
            int y = (int)transform.localPosition.y;
            LoadTexture(Grid.adjacentMines(x, y));

            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);
        }
    }
}

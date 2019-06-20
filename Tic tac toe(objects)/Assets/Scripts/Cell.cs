using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{
    FieldLogic parent;
    InterfaceController mainInterface;
    public Sprite xSprite;
    public Sprite oSprite;

    public int state;
    public int xIndex;
    public int yIndex;

    private void Start()
    {
        parent = GetComponentInParent<FieldLogic>();
        mainInterface = FindObjectOfType<InterfaceController>();
    }
    private void OnMouseDown()
    {
        if (parent.isRoundStarted&&!MainLogic.instance.isGamePaused)
        {
            if (state == 0)
            {
                state = MainLogic.instance.Turn;
                parent.EmptyCells -= 1;
                switch (state)
                {
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = xSprite;  
                        MainLogic.instance.Turn = 2;
                        break;
                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = oSprite;
                        MainLogic.instance.Turn = 1;
                        break;
                }
                if (parent.CheckWin(this))
                {
                    parent.isRoundStarted = false;
                    MainLogic.instance.ChangeScore(state);
                    mainInterface.ShowGameOverPanel(true,state);
                }
                else if (parent.EmptyCells<1)
                {
                    parent.isRoundStarted = false;
                    mainInterface.ShowGameOverPanel(false, state);
                }
            }
        }
        
    }
    public void AddToArray(int x, int y)
    {
        xIndex = x;
        yIndex = y;
        state = 0;
        GetComponentInParent<FieldLogic>().WriteToArray(x, y, this);
    }

}

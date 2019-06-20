using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   enum Side
    {
        Empty,
        Player1,
        Player2
    }
public class MainLogic : MonoBehaviour
{
    public static MainLogic instance;
    public GameObject fieldCell;
    public GameObject cellPrefab;
    float cameraWidth;
    float cameraHeight;
    int turn=1;
    int screenInUnits;

    public Vector2 startCellSpawnPosition;
    Vector2 offsetPosition;
    Camera mainCam;
    public int score1;
    public int score2;
    public bool isGamePaused;
    public bool isOnePlayer=true;

    public int Turn
    {
        get { return turn; }
        set { turn = value; }
    }
 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        Screen.orientation = ScreenOrientation.PortraitUpsideDown;
        mainCam = Camera.main;
        cameraWidth = mainCam.pixelWidth;
        cameraHeight = mainCam.pixelHeight;
        screenInUnits = fieldCell.GetComponent<FieldLogic>().sizeCellMass * 3;
        offsetPosition = new Vector2(3f,3f);
        startCellSpawnPosition = mainCam.transform.position;
    }

    public void CalculateCameraSize()
    {
        float ratio = (float)Screen.height / Screen.width;
        float myHight =  PlayerPrefController.GetSizeValue()*3 * (ratio>=1?ratio:1);
        float ortSize = myHight / 2f;

        Camera.main.orthographicSize = Mathf.RoundToInt(ortSize+0.5f);
    }

    internal void ChangeScore(int state)
    {
        if (state == 1)
        {
            score1++;
        }
        else if(state == 2)
        {
            score2++;
        }
    }

    public int GetTurn()
    {
        return turn;
    }
    public void SpawnCells(Vector2 pos, int count, GameObject parent)
    {
        GameObject cell;
        Vector2 offset;
        for (int y = 0; y < count; y++)
        {

            for (int x = 0; x < count; x++)
            {
                offset = new Vector2(x * 3, y * 3);
                cell = Instantiate(cellPrefab, pos + offset, Quaternion.identity, parent.transform);
                cell.GetComponent<Cell>().AddToArray(y,x);
            }

        }
    }

}

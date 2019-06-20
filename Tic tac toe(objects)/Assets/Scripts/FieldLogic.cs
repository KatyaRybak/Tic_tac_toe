using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLogic : MonoBehaviour
{
    public bool isRoundStarted;
    MainLogic logic;
    public int sizeCellMass = 4;
    public Cell[,] cellMass;
    int countCrossCells;
    Vector2 startCellSpawnPosition;
    public int EmptyCells
    {
        get;
        set;
    }
    private void Awake()
    {
        sizeCellMass = PlayerPrefController.GetSizeValue();
        countCrossCells = PlayerPrefController.GetCrossedValue();
        if (sizeCellMass < 3)
        {
            sizeCellMass = 3;
        }
        if (countCrossCells < 3)
        {
            countCrossCells = 3;
        }
        logic = MainLogic.instance;
        cellMass = new Cell[sizeCellMass, sizeCellMass];
        isRoundStarted = true;
        EmptyCells = sizeCellMass * sizeCellMass;
    }

    private void Start()
    {
        logic.SpawnCells(logic.startCellSpawnPosition, sizeCellMass, gameObject);
        logic.CalculateCameraSize();
        Camera.main.transform.position = new Vector3(CameraLocation().x, CameraLocation().y, Camera.main.transform.position.z);
        logic.isGamePaused = false;
        logic.Turn = 1;
    }
    public void WriteToArray(int xIndex, int yIndex, Cell cell)
    {
        cellMass[xIndex, yIndex] = cell;
    }

    public bool CheckWin(Cell cell)
    {
        List<GameObject>[] crossed = new List<GameObject>[4];
        List<GameObject> countDia1 = new List<GameObject>();
        crossed[0] = countDia1;
        List<GameObject> countDia2 = new List<GameObject>();
        crossed[1] = countDia2;
        List<GameObject> countHor = new List<GameObject>();
        crossed[2] = countHor;
        List<GameObject> countVert = new List<GameObject>();
        crossed[3] = countVert;
        GameObject firstCell = gameObject;
        GameObject lastCell = gameObject;

        for (int i = 0; i < sizeCellMass; i++)
        {
            if (cellMass[cell.xIndex, i].state == cell.state)
            {
                countVert.Add(cellMass[cell.xIndex, i].gameObject);
            }
            else if (countVert.Count <= 2)
            {
                countVert.Clear();
            }

            if (cellMass[i, cell.yIndex].state == cell.state)
            {
                countHor.Add(cellMass[i, cell.yIndex].gameObject);
            }
            else if (countHor.Count <= 2)
            {
                countHor.Clear();
            }

            int diff = cell.xIndex - cell.yIndex;
            if (Mathf.Abs(diff) <= sizeCellMass - countCrossCells)
            {
                if (i >= diff && i < sizeCellMass + diff)
                {
                    if (cellMass[i, i - diff].state == cell.state)
                    {
                        countDia1.Add(cellMass[i, i - diff].gameObject);
                    }
                    else
                    {
                        countDia1.Clear();
                    }
                }
            }

            int comb = cell.xIndex + cell.yIndex;
            if (i >= comb - (sizeCellMass - 1) && i <= comb)
            {
                if (cellMass[i, comb - i].state == cell.state)
                {
                    countDia2.Add(cellMass[i, comb - i].gameObject);
                }
                else if (countDia2.Count <= 2)
                {
                    countDia2.Clear();
                }
            }

        }
        List<Vector3> positionPoints = new List<Vector3>();
        for (int j = 0; j < 4; j++)
        {
            if (crossed[j].Count >= countCrossCells)
            {
                GetComponent<LineRenderer>().positionCount += 2;
                positionPoints.Add(crossed[j][0].transform.position);
                positionPoints.Add(crossed[j][countCrossCells - 1].transform.position);
            }

        }

        GetComponent<LineRenderer>().SetPositions(positionPoints.ToArray());

        if (GetComponent<LineRenderer>().positionCount > 0)
        {
            return true;
        }
        return false;
    }

    internal Vector2 CameraLocation()
    {
        Vector2 firstCellPosition = cellMass[0, 0].gameObject.transform.localPosition;
        Vector2 lastCellPosition = cellMass[sizeCellMass - 1, sizeCellMass - 1].gameObject.transform.localPosition;
        return (lastCellPosition - firstCellPosition) / 2;
    }

    public Cell[,] GetCellMass()
    {
        return cellMass;
    }
}

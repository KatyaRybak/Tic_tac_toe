using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayer : MonoBehaviour
{
    MainLogic logic;
    int fieldSize;
    int crossedCellsCount;
    Cell[,] cellMass;

    private void Start()
    {
        logic = MainLogic.instance;
        fieldSize = PlayerPrefController.GetSizeValue() != 0 ? PlayerPrefController.GetSizeValue() : 3;
        crossedCellsCount = PlayerPrefController.GetCrossedValue() != 0 ? PlayerPrefController.GetCrossedValue() : 3;
    }

    void GetCrossingCell()
    {
        cellMass = FindObjectOfType<FieldLogic>().GetCellMass();
        for(int i= 0; i<fieldSize; i++)
        {
            for(int j=0; j<fieldSize; j++)
            {

            }
        }
    }
}

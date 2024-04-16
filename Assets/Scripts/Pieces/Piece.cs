using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public abstract class Piece : MonoBehaviour
{
    public AllegianceData allegiance;
    public List<Tile> legalMovePoints;
    public Grid gridObject;
    public Tile currentTile;

    public UnityEvent OnMoved;
    public UnityEvent OnPieceTaken;
    public UnityEvent OnSelected;

    public abstract List<Tile> CheckLegalMoves();
    protected void MoveLateral(int spacesToMove, DirectionLateral direction, List<Tile> outputList, bool canAttackLateral = true)
    {
        int timesRan = 0;
        switch (direction)
        {
            case DirectionLateral.N:
                {
                    
                    for (int i = (int)currentTile.gridPos.y + 1; i < gridObject.gridDimensions.GetLength(1); i++)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
                            if (nextTile.pieceOnTile)
                            {
                                Piece nextPiece = nextTile.pieceOnTile;
                                if (nextPiece && allegiance == nextPiece.allegiance)
                                {
                                    break;
                                }
                                else if (nextPiece && allegiance != nextPiece.allegiance && canAttackLateral)
                                {
                                    outputList.Add(nextTile);
                                    break;
                                }
                                else
                                    break;
                            }
                            outputList.Add(nextTile);
                        }
                    }
                    break;
                }
            case DirectionLateral.E:
                {
                    for (int i = (int)currentTile.gridPos.x + 1; i < gridObject.gridDimensions.GetLength(0); i++) // I = 1 to exclude self
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            Tile nextTile = gridObject.gridDimensions[i, (int)currentTile.gridPos.y];
                            if (nextTile.pieceOnTile)
                            {
                                Piece nextPiece = nextTile.pieceOnTile;
                                if (nextPiece && allegiance == nextPiece.allegiance)
                                {
                                    break;
                                }
                                else if (nextPiece && allegiance != nextPiece.allegiance && canAttackLateral)
                                {
                                    outputList.Add(nextTile);
                                    break;
                                }
                                else
                                    break;
                            }
                            outputList.Add(nextTile);
                        }
                    }
                    break;
                }
            case DirectionLateral.S:
                {
                    for (int i = (int)currentTile.gridPos.y - 1; i >= 0; i--)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
                            if (nextTile.pieceOnTile)
                            {
                                Piece nextPiece = nextTile.pieceOnTile;
                                if (nextPiece && allegiance == nextPiece.allegiance)
                                {
                                    break;
                                }
                                else if (nextPiece && allegiance != nextPiece.allegiance && canAttackLateral)
                                {
                                    outputList.Add(nextTile);
                                    break;
                                }
                                else
                                    break;
                            }
                            outputList.Add(nextTile);
                        }
                    }
                    break;
                }
            case DirectionLateral.W:
                {
                    for (int i = (int)currentTile.gridPos.x - 1; i >= 0; i--)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            Tile nextTile = gridObject.gridDimensions[i, (int)currentTile.gridPos.y];
                            if (nextTile.pieceOnTile)
                            {
                                Piece nextPiece = nextTile.pieceOnTile;
                                if (nextPiece && allegiance == nextPiece.allegiance)
                                {
                                    break;
                                }
                                else if (nextPiece && allegiance != nextPiece.allegiance && canAttackLateral)
                                {
                                    outputList.Add(nextTile);
                                    break;
                                }
                                else
                                    break;
                            }
                            outputList.Add(nextTile);
                        }
                    }
                    break;
                }
        }
    }
    protected void MoveDiagonal(int spacesToMove, DirectionDiagonal direction, List<Tile> outputList, bool canAttackDiagonal = true)
    {
        int timesRan = 0;
        int y = 0;
        switch (direction)
        {
            case DirectionDiagonal.NE:
                {
                    y = (int)currentTile.gridPos.y;
                    for (int x = (int)currentTile.gridPos.x + 1; x < gridObject.gridDimensions.GetLength(0) && currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1; x++)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            if (y < gridObject.gridDimensions.GetLength(1) - 1)
                            {
                                y++;

                                Tile nextTile = gridObject.gridDimensions[x, y];
                                if (nextTile.pieceOnTile)
                                {
                                    Piece nextPiece = nextTile.pieceOnTile;
                                    if (nextPiece && allegiance == nextPiece.allegiance)
                                    {
                                        break;
                                    }
                                    else if (nextPiece && allegiance != nextPiece.allegiance && canAttackDiagonal)
                                    {
                                        outputList.Add(nextTile);
                                        break;
                                    }
                                    else
                                        break;
                                }

                                outputList.Add(gridObject.gridDimensions[x, y]);
                            }
                        }
                    }
                    break;
                }
            case DirectionDiagonal.SE:
                {
                    y = (int)currentTile.gridPos.y;
                    for (int x = (int)currentTile.gridPos.x + 1; x < gridObject.gridDimensions.GetLength(0); x++)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            if (y > 1)
                            {
                                y--;

                                Tile nextTile = gridObject.gridDimensions[x, y];
                                if (nextTile.pieceOnTile)
                                {
                                    Piece nextPiece = nextTile.pieceOnTile;
                                    if (nextPiece && allegiance == nextPiece.allegiance)
                                    {
                                        break;
                                    }
                                    else if (nextPiece && allegiance != nextPiece.allegiance && canAttackDiagonal)
                                    {
                                        outputList.Add(nextTile);
                                        break;
                                    }
                                    else
                                        break;
                                }

                                outputList.Add(gridObject.gridDimensions[x, y]);
                            }
                        }
                    }
                    break;
                }
            case DirectionDiagonal.SW:
                {
                    y = (int)currentTile.gridPos.y;
                    for (int x = (int)currentTile.gridPos.x - 1; x >= 0 && currentTile.gridPos.x > 0; x--)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            if (y > 1)
                            {
                                y--;

                                Tile nextTile = gridObject.gridDimensions[x, y];
                                if (nextTile.pieceOnTile)
                                {
                                    Piece nextPiece = nextTile.pieceOnTile;
                                    if (nextPiece && allegiance == nextPiece.allegiance)
                                    {
                                        break;
                                    }
                                    else if (nextPiece && allegiance != nextPiece.allegiance && canAttackDiagonal)
                                    {
                                        outputList.Add(nextTile);
                                        break;
                                    }
                                    else
                                        break;
                                }

                                outputList.Add(gridObject.gridDimensions[x, y]);
                            }
                        }
                    }
                    break;
                }
            case DirectionDiagonal.NW:
                {
                    y = (int)currentTile.gridPos.y;
                    // CHECK NW
                    for (int x = (int)currentTile.gridPos.x - 1; x >= 0 && currentTile.gridPos.x > 0; x--)
                    {
                        if (timesRan < spacesToMove || spacesToMove == 0)
                        {
                            timesRan++;
                            if (y < gridObject.gridDimensions.GetLength(1) - 1)
                            {
                                y++;

                                Tile nextTile = gridObject.gridDimensions[x, y];
                                if (nextTile.pieceOnTile)
                                {
                                    Piece nextPiece = nextTile.pieceOnTile;
                                    if (nextPiece && allegiance == nextPiece.allegiance)
                                    {
                                        break;
                                    }
                                    else if (nextPiece && allegiance != nextPiece.allegiance && canAttackDiagonal)
                                    {
                                        outputList.Add(nextTile);
                                        break;
                                    }
                                    else
                                        break;
                                }
                                outputList.Add(gridObject.gridDimensions[x, y]);
                            }
                        }
                    }
                    break;
                }
        }
    }
}

public enum DirectionLateral
{
    N,
    E,
    S,
    W,
}
public enum DirectionDiagonal
{
    NE,
    SE,
    SW,
    NW

}

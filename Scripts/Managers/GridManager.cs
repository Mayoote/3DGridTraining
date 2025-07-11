using Com.IsartDigital.TRPG.GridElements.Characters;
using Com.IsartDigital.TRPG.Managers;
using Godot;
using Maitson.PIERRE.Tools;
using System;
using System.Collections.Generic;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements;

public partial class GridManager : Node2D, IManager
{
    public Vector2 screenSize;
    [Export] private Player player;

    private Tile[,,] grid;
    [Export] private Node visualGrid;

    private int ROOM_NUMBER = 5;
    [Export] private int FLOOR_NUMBER;
    [Export] private int APARTMENT_NUMBER;

    private Person jack;

    public enum Rooms
    {
        KITCHEN,
        LIVING_ROOM,
        BEDROOM,
        BATHROOM,
        TOILET,
    }

    public void Start()
    {
        jack = new Person();
        jack.isMinor = false;
        jack.isMale = true;

        grid = CreateGrid();
        GD.Print(Name + " is ready !");
        
       IsTileOccupied(grid, new(1,1,0));
       WhoIsOnTargetTile(grid, new(1,1,0));

    }


    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;
    }


    private Tile[,,] CreateGrid()
    {
        //SetGridSize();

        Tile[,,] lGrid = new Tile[FLOOR_NUMBER, APARTMENT_NUMBER, ROOM_NUMBER];

        for (int x = 0; x < FLOOR_NUMBER; x++)
        {
            for (int y = 0; y < APARTMENT_NUMBER; y++)
            {
                for (int z = 0; z < ROOM_NUMBER; z++)
                {
                    lGrid = SetupTile(lGrid, x, y, z);
                }
            }
        }

        return lGrid;
    }

    private Tile[] Create1DGrid()
    {
        Tile[] lGrid = new Tile[FLOOR_NUMBER * APARTMENT_NUMBER * ROOM_NUMBER];

        return lGrid;
    }

    private int From3DPositionToIndex(Vector3I pPosition, int pMaxX, int pMaxY, int pMaxZ)
    {
        return pPosition.Z * (pMaxX * pMaxY) + pPosition.Y * pMaxX + pPosition.X;
    }


    private bool IsTileOccupied(Tile[,,] pGrid, Vector3I pPosition)
    {
        GD.Print(pGrid[pPosition.X, pPosition.Y, pPosition.Z].currentState == Tile.State.OCCUPIED);
        return pGrid[pPosition.X, pPosition.Y, pPosition.Z].currentState == Tile.State.OCCUPIED;
    }

    private List<Person> WhoIsOnTargetTile(Tile[,,] pGrid, Vector3I pPosition)
    {
        return pGrid[pPosition.X, pPosition.Y, pPosition.Z].occupants;
    }

    private void UpdateTileState(Tile[,,] pGrid, Vector3I pPosition, Tile.State pTileState)
    {
       pGrid[pPosition.X, pPosition.Y, pPosition.Z].currentState = pTileState;
    }

    private void LeaveRoom(Tile[,,] pGrid, Vector3I pPosition, Person pOccupant)
    {
        UpdateTileState(pGrid, pPosition, Tile.State.EMPTY);
        pGrid[pPosition.X, pPosition.Y, pPosition.Z].occupants.Remove(pOccupant);
    }

    private void EnterRoom(Tile[,,] pGrid, Vector3I pPosition, Person pOccupant)
    {
        UpdateTileState(pGrid, pPosition, Tile.State.OCCUPIED);
        pGrid[pPosition.X, pPosition.Y, pPosition.Z].occupants.Add(pOccupant);
    }

    private Tile[,,] SetupTile(Tile[,,] pGrid, int pFloorNumber, int pApartmentNumber, int pRoomNumber)
    {
        Vector3I lIndexPosition = new Vector3I(pFloorNumber, pApartmentNumber, pRoomNumber);

        pGrid[pFloorNumber, pApartmentNumber, pRoomNumber] = new Tile();
        pGrid[pFloorNumber, pApartmentNumber, pRoomNumber].indexPosition = lIndexPosition;

        return pGrid;
    }








    // OBSELETE

    //private void SetGridSize()
    //{
    //    screenSize = new(1080, 1920);
    //    Tile lTile = ShowTile(this);

    //    int lNumberOfRows = Mathf.CeilToInt(screenSize.X / lTile.Size.X);
    //    int lNumberOfCols = Mathf.CeilToInt(screenSize.Y / lTile.Size.Y);

    //    //ROW_NUMBER = lNumberOfRows;
    //    //COL_NUMBER = lNumberOfCols;
    //}

    //   private Tile SetupTile(Node pNode, Vector3I pTileIndex)
    //{
    //	Tile lTile = ShowTile(pNode);
    //       lTile.indexPosition = pTileIndex;
    //	lTile.SetupTile();
    //	return lTile;
    //   }

    //private Tile SpawnTile()
    //{
    //       PackedScene lTileFactory = GD.Load<PackedScene>(AssetPath.TILE_SCENE_PATH);
    //       Tile lTile = lTileFactory.Instantiate<Tile>();

    //	return lTile;
    //   }

    //private Tile ShowTile(Node pNode)
    //{
    //	Tile lTile = SpawnTile();
    //	pNode.AddChild(lTile);

    //	return lTile;
    //}

}

using Godot;
using Maitson.PIERRE.Tools;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements;

public partial class GridManager : Node
{
	private Tile[,] grid;

	[Export] private PackedScene tile;
	[Export] private int ROW_NUMBER;
	[Export] private int COL_NUMBER;
	[Export] private Node visualGrid;
	public override void _Ready()
	{
		grid = CreateGrid();
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}

	private Tile[,] CreateGrid()
	{
        Vector2I lTileIndex;

		Tile lTile = SpawnTile();

		//ROW_NUMBER = Mathf.FloorToInt(Root.screenSize.X / lTile.Size.X);
		//COL_NUMBER = Mathf.FloorToInt(Root.screenSize.Y / lTile.Size.Y);


        Tile[,] lGrid = new Tile[ROW_NUMBER, COL_NUMBER];

        for (int x = 0; x < ROW_NUMBER; x++)
        {
            for (int y = 0; y < COL_NUMBER; y++)
            {
                lTileIndex = new Vector2I(x, y);
				lGrid[y, x] = SetupTile(visualGrid, lTileIndex);

                GD.Print(lGrid[y, x].indexPosition);
            }
        }

		return lGrid;
    }

	private Tile SetupTile(Node pNode, Vector2I pTileIndex)
	{
		Tile lTile = ShowTile(pNode);
        lTile.indexPosition = pTileIndex;

		return lTile;
    }

	private Tile SpawnTile()
	{
        PackedScene lTileFactory = GD.Load<PackedScene>(AssetPath.TILE_SCENE_PATH);
        Tile lTile = lTileFactory.Instantiate<Tile>();

		return lTile;
    }

	private Tile ShowTile(Node pNode)
	{
		Tile lTile = SpawnTile();
		pNode.AddChild(lTile);

		return lTile;
	}

}

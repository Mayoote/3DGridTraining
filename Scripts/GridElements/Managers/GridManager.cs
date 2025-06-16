using Godot;
using Maitson.PIERRE.Tools;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements;

public partial class GridManager : Node
{
	private Tile[,] grid;
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
        Tile[,] lGrid = new Tile[ROW_NUMBER, COL_NUMBER];

        for (int x = 0; x < ROW_NUMBER; x++)
        {
            for (int y = 0; y < COL_NUMBER; y++)
            {
                lTileIndex = new Vector2I(x, y);
				lGrid[y, x] = SpawnTile(visualGrid, lTileIndex);

                GD.Print(lGrid[y, x].indexPosition);
                GD.Print("GLOBAL TILE POSITION : " + lGrid[y, x].GlobalPosition);
            }
        }

		return lGrid;
    }

	private Tile SpawnTile(Node pNode, Vector2I pTileIndex)
	{

		PackedScene lTileFactory = GD.Load<PackedScene>(AssetPath.TILE_SCENE_PATH);
		Tile lTile = lTileFactory.Instantiate<Tile>();
		pNode.AddChild(lTile);

		lTile.indexPosition = pTileIndex;

		return lTile;
	}
}

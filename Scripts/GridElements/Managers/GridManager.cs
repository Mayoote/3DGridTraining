using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements;

public partial class GridManager : Node
{
	private Tile[,] grid;
	[Export] private int ROW_NUMBER;
	[Export] private int COL_NUMBER;
	public override void _Ready()
	{
		CreateGrid();
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}

	private void CreateGrid()
	{
        Vector2I lTileIndex;
        grid = new Tile[ROW_NUMBER, COL_NUMBER];

        for (int x = 0; x < ROW_NUMBER; x++)
        {
            for (int y = 0; y < COL_NUMBER; y++)
            {
                lTileIndex = new Vector2I(x, y);
                grid[y, x] = new Tile(lTileIndex);
                GD.Print(grid[y, x].indexPosition);
                GD.Print("GLOBAL TILE POSITION : " + grid[y, x].GlobalPosition);
            }
        }
    }

	private void SpawnTile()
	{
		PackedScene lTileFactory = GD.Load
	}
}

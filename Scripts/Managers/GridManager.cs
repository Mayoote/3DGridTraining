using Com.IsartDigital.TRPG.GridElements.Characters;
using Com.IsartDigital.TRPG.Managers;
using Godot;
using Maitson.PIERRE.Tools;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements;

public partial class GridManager : Node2D, IManager
{
	private Tile[,] grid;
    public Vector2 screenSize;
	[Export] private Player player;
    [Export] private int ROW_NUMBER;
	[Export] private int COL_NUMBER;
	[Export] private Node visualGrid;


	public void Start()
	{
		grid = CreateGrid();
		GD.Print(Name + " is ready !");
	}

	public override void _Ready()
	{
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
		SetGridSize();

		Tile[,] lGrid = new Tile[COL_NUMBER, ROW_NUMBER];

		for (int x = 0; x < ROW_NUMBER; x++)
		{
			for (int y = 0; y < COL_NUMBER; y++)
			{
				lTileIndex = new Vector2I(x, y);
				lGrid[y, x] = SetupTile(visualGrid, lTileIndex);

				//GD.Print(lGrid[y, x].indexPosition);
			}
		}
		 
		player.Position = lGrid[2, 4].CenterPosition;
		return lGrid;
    }

	private void SetGridSize()
	{
        screenSize = new(1080, 1920);
        Tile lTile = ShowTile(this);

        int lNumberOfRows = Mathf.CeilToInt(screenSize.X / lTile.Size.X);
        int lNumberOfCols = Mathf.CeilToInt(screenSize.Y / lTile.Size.Y);

        ROW_NUMBER = lNumberOfRows;
        COL_NUMBER = lNumberOfCols;
    }

    private Tile SetupTile(Node pNode, Vector2I pTileIndex)
	{
		Tile lTile = ShowTile(pNode);
        lTile.indexPosition = pTileIndex;
		lTile.SetupTile();
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

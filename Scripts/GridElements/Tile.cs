using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements; 

public partial class Tile : Node2D
{
	public enum TileState
	{
		EMPTY,
		OCCUPIED
	}

	[Export] private Sprite2D renderer;

	public TileState currentState;
	public Vector2I indexPosition;
	public Vector2 CenterPosition {  get; private set; }
	public Vector2 Size {  get; private set; }
	public override void _Ready()
	{
		currentState = TileState.EMPTY;
		Size = renderer.Texture.GetSize();
            CenterPosition = Size * .5f;
		GlobalPosition = new Vector2(
					CenterPosition.X + CenterPosition.X * indexPosition.X,
					CenterPosition.Y + CenterPosition.Y * indexPosition.Y
					);
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}
}

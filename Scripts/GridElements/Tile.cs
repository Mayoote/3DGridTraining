using Godot;
using Maitson.PIERRE.Tools;
using System;
using System.Collections.Generic;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements; 

public partial class Tile : Node2D
{
	public enum State
	{
		EMPTY,
		OCCUPIED
	}

	private Sprite2D renderer;

	public Vector3I indexPosition;
	public State currentState = State.EMPTY;
	public List<Person> occupants = new List<Person>();

	//public Vector2 CenterPosition {  get; private set; }
	//public Vector2 Size {  get; private set; }
	public override void _Ready()
	{
		SetupTile();
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}

	public void SetupTile()
	{
		//renderer = (Sprite2D)FindChild(AssetPath.RENDERER_NAME);
  //      currentState = TileState.EMPTY;
  //      Size = renderer.Texture.GetSize() * renderer.Scale;
  //      CenterPosition = Size * .5f;

  //      GlobalPosition = new Vector2(
  //                  CenterPosition.X + CenterPosition.X * indexPosition.X,
  //                  CenterPosition.Y + CenterPosition.Y * indexPosition.Y
  //                  );

		//CenterPosition = new Vector2(
		//	GlobalPosition.X - CenterPosition.X * .5f,
		//	GlobalPosition.Y - CenterPosition.Y * .5f
  //          );
    }
}

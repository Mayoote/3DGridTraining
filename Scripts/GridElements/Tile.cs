using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements {
	
	public partial class Tile : Node2D
	{
		private enum TileState
		{
			EMPTY,
			OCCUPIED
		}

		private Sprite2D renderer;
		public Vector2 indexPosition;
		public Vector2 CenterPosition {  get; private set; }

		public Tile(Vector2 pIndexPosition) 
		{
			indexPosition = pIndexPosition;	
		}
		public override void _Ready()
		{
			CenterPosition = renderer.Texture.GetSize() * .5f; 
		}

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

		}

		protected override void Dispose(bool pDisposing)
		{

		}
	}
}

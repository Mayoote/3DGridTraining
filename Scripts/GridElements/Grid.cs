using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements; 

public partial class Grid : Node
{
	private Tile[] grid;
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
}

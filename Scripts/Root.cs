using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG; 

public partial class Root : Node2D
{
	public static Vector2 screenSize;
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}
}

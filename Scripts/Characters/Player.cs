using Godot;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.GridElements.Characters;

public partial class Player : Node2D
{
	#region Singleton
	public static Player Instance {  get; private set; }

	#endregion

	public override void _Ready()
	{
		Instance = this;
        GD.Print(Name + " is ready !");
    }

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;
	}

	protected override void Dispose(bool pDisposing)
	{
		Instance = null;
		base.Dispose(pDisposing);
	}
}

using Com.IsartDigital.TRPG.GridElements;
using Com.IsartDigital.TRPG.GridElements.Characters;
using Godot;
using Maitson.PIERRE.Tools;
using System;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.Managers; 

public partial class GameManager : Node, IManager
{
    public void Start()
    {
        GD.Print(Name + " is ready !");
    }
	public override void _Ready()
	{
        //ShowPlayer(this);
	}

	public override void _Process(double pDelta)
	{
		float lDelta = (float)pDelta;

	}

	protected override void Dispose(bool pDisposing)
	{

	}

    //private Player SetupPlayer(Node pNode)
    //{
    //    Player lPlayer = ShowPlayer(pNode);
    //    return lPlayer;
    //}

    //private Player SpawnPlayer()
    //{
    //    PackedScene lPlayerFactory = GD.Load<PackedScene>(AssetPath.PLAYER_SCENE_PATH);
    //    Player lPlayer = lPlayerFactory.Instantiate<Player>();

    //    return lPlayer;
    //}

    //private Player ShowPlayer(Node pNode)
    //{
    //    Player lPlayer = SpawnPlayer();
    //    pNode.AddChild(lPlayer);

    //    return lPlayer;
    //}
}

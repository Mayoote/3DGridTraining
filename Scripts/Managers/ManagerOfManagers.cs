using Godot;
using System;
using System.ComponentModel;

// Author : Maïtson PIERRE

namespace Com.IsartDigital.TRPG.Managers;

public partial class ManagerOfManagers : Node
{


    public override void _Ready()
    {
        foreach (IManager lManager in GetChildren())
        {
            lManager.Start();
        }
    }
}
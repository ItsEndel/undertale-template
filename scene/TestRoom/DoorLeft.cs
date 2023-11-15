using Godot;
using System;

public partial class DoorLeft : Area2D
{
	// 信号方法
	private void OnBodyEntered(Node2D body) {
		if (body is Player) {
			
		}
	}



	// 节点方法 //
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}
}

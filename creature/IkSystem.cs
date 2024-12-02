using Godot;
using System;

public partial class IKSystem : Node2D
{
	private Bone _bone1;
	private Bone _bone2;
	
	public override void _Ready()
	{
		// Get references to our bones
		_bone1 = GetNode<Bone>("Bone1");
		_bone2 = GetNode<Bone>("Bone2");
		
		// Initial setup
		_bone1.Position = new Vector2(100, 300);
		_bone2.Position = _bone1.Position + new Vector2(_bone1.BoneLength, 0);
	}
	
	public override void _Process(double delta)
	{
		// Get mouse position for testing
		var target = GetGlobalMousePosition();
		QueueRedraw(); // Request redraw for our custom drawing
	}
	
	public override void _Draw()
	{
		// Draw target point when mouse moves
		var target = GetGlobalMousePosition();
		DrawCircle(target, 5, Colors.Red);
	}
}

using Godot;
using System;

public partial class Bone : Sprite2D
{
	[Export]
	public float BoneLength { get; set; } = 50.0f;
	
	[Export]
	public float BoneWidth { get; set; } = 10.0f;
	
	[Export]
	public Color BoneColor { get; set; } = Colors.White;

	public override void _Ready()
	{
		// Create a simple rectangular texture for our bone
		var image = Image.Create(
			(int)BoneLength, 
			(int)BoneWidth, 
			false, 
			Image.Format.Rgba8
		);
		
		// Fill the bone
		image.Fill(BoneColor);
		
		// Draw outline
		for (int x = 0; x < BoneLength; x++)
		{
			image.SetPixel(x, 0, Colors.Black);
			image.SetPixel(x, (int)BoneWidth - 1, Colors.Black);
		}
		
		for (int y = 0; y < BoneWidth; y++)
		{
			image.SetPixel(0, y, Colors.Black);
			image.SetPixel((int)BoneLength - 1, y, Colors.Black);
		}
		
		// Create and set texture
		Texture = ImageTexture.CreateFromImage(image);
		
		// Set pivot point to left center of bone
		Offset = new Vector2(-BoneLength/2, -BoneWidth/2);
		Position = new Vector2(BoneLength/2, 0);
	}
}

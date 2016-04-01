using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Game1
{
	// Button code from Aintaro Microsoft
	class Button : GameObject
	{
		public int buttonX;
		public int buttonY;
		Rectangle ButtonPos;
		string Name;
        MouseState ms;
		public Button(Rectangle buttonPos, int buttonX, int buttonY)
		{
			
			ButtonPos = buttonPos;
			this.buttonX = buttonX;
			this.buttonY = buttonY;
		}

		public bool enterButton()
		{
			ms = Mouse.GetState();
			if (ms.X <= (buttonX + ButtonPos.Width) && 
				ms.X >= buttonX &&
				ms.Y <= (buttonY + ButtonPos.Height) &&
				ms.Y >= buttonY)
			
			{ return true; }
			return false;
		}


			

	}
}

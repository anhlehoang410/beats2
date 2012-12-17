using UnityEngine;
using System;
using System.Collections.Generic;
using Beats2;
using Beats2.Common;
using Beats2.Graphic;

namespace Beats2.UI {
	
	public class TestBackground : BeatsObject<Sprite> {

		private SpriteData _data;
		private string _imgUrl;

		public static TestBackground Instantiate(string imgUrl) {
			// Create GameObject
			GameObject obj = new GameObject();
			obj.name = "TestBackground";
			obj.tag = Tags.UNTAGGED;

			// Add TestBackground Component
			TestBackground beatsObj = obj.AddComponent<TestBackground>();

			// Create SpriteData
			Texture2D texture = Loader.LoadTexture(imgUrl, false);
			if (Screens.width > Screens.height) {
				beatsObj._data = new SpriteData(texture, Screens.width, 0f, ScaleType.SCALED_WIDTH);
			} else {
				beatsObj._data = new SpriteData(texture, 0f, Screens.height, ScaleType.SCALED_HEIGHT);
			}
			beatsObj._imgUrl = imgUrl;

			// Add Sprite Component
			Sprite sprite = obj.AddComponent<Sprite>();
			sprite.Setup(beatsObj._data);
			beatsObj._sprite = sprite;

			// Return instantiated BeatsObject
			return beatsObj;
		}

		public override void Destroy() {
			base.Destroy();
			_data.Destroy();
			Loader.UnloadTexture(_imgUrl);
		}
	}
}

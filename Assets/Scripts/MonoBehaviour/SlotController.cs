using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviour
{
	public class SlotController : UnityEngine.MonoBehaviour
	{
		private readonly ColorTransformer _colorTransformer = new ColorTransformer();
		private Image _image;
	
		// Use this for initialization
		void Start ()
		{
			_image = GetComponent<Image>();
			_image.color = Color.black;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (_colorTransformer.IsActive())
			{
				_image.color = _colorTransformer.Update();
			}
		}

		// ReSharper disable once UnusedMember.Global
		public void Show()
		{
			_colorTransformer.Show();
		}
	}
}

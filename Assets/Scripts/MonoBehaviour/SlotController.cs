using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

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
		public void MH_Show(Dictionary<String, Object> args)
		{
			_colorTransformer.Show();
		}
	}
}

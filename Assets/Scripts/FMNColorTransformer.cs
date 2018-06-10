using UnityEngine;

public class ColorTransformer
{
	private float duration = 1.5f;
	private Color _from;
	private Color _to;
	private float _time = 1f;

	public void Show()
	{
		_from = Color.black;
		_to = Color.white;
		_time = 0;
	}

	public Color Update()
	{
		if (IsActive())
		{
			Color newColor = Color.Lerp(_from, _to, _time);
			_time += Time.deltaTime / duration;
			return newColor;
		}

		return _to;
	}

	public bool IsActive()
	{
		return _time < 1;
	}
}

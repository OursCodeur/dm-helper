using UnityEngine;
using System;

public class ColorHSV : System.Object
{
	private float h = 0f;
	private float s = 0f;
	private float v = 0f;
	private float a = 0f;
   
    /**
    * Construct without alpha (which defaults to 1)
    */
	public ColorHSV(float h, float s, float v)
	{
		this.h = h;
		this.s = s;
		this.v = v;
		this.a = 1f;
	}

	/**
    * Construct with alpha
    */
	public ColorHSV(float h, float s, float v, float a)
	{
		this.h = h;
		this.s = s;
		this.v = v;
		this.a = a;
	}

	/**
	    * Return an RGBA color object
	    */
	public Color ToColor()
	{
		// no saturation, we can return the value across the board (grayscale)
		if ( this.s == 0 )
			return new Color(this.v, this.v, this.v, this.a);

		// which chunk of the rainbow are we in?
		float sector = this.h / 60f;

		// split across the decimal (ie 3.87 into 3 and 0.87)
		int i = Mathf.FloorToInt(sector);
		Debug.Log (i);
		float f = sector - i;
		Debug.Log (f);

		float v = this.v;
		float p = v * ( 1 - s );
		float q = v * ( 1 - s * f );
		float t = v * ( 1 - s * ( 1 - f ) );

		// build our rgb color
		Color color = new Color(0, 0, 0, this.a);

		switch(i)
		{
			case 0:
				color.r = v;
				color.g = t;
				color.b = p;
			break;
			case 1:
				color.r = q;
				color.g = v;
				color.b = p;
			break;
			case 2:
				color.r  = p;
				color.g  = v;
				color.b  = t;
			break;
			case 3:
				color.r  = p;
				color.g  = q;
				color.b  = v;
			break;
			case 4:
				color.r  = t;
				color.g  = p;
				color.b  = v;
			break;
			default:
				color.r  = v;
				color.g  = p;
				color.b  = q;
			break;
		}

		return color;
	}
}

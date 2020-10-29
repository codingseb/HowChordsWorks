namespace HowChordsWorks.Utils
{
    public struct RGB
	{
        public RGB(byte r, byte g, byte b)
		{
			R = r;
			G = g;
			B = b;
		}

        public byte R { get; set; }

        public byte G { get; set; }

        public byte B { get; set; }

        public bool Equals(RGB rgb)
		{
			return (R == rgb.R) && (G == rgb.G) && (B == rgb.B);
		}
	}

	public struct HSL
	{
        public HSL(int h, float s, float l)
		{
			H = h;
			S = s;
			L = l;
		}

        public int H { get; set; }

        public float S { get; set; }

        public float L { get; set; }

        public bool Equals(HSL hsl)
		{
			return (H == hsl.H) && (S == hsl.S) && (L == hsl.L);
		}
	}

	/// <summary>
	/// Allow to convert between colors format
	/// </summary>
	public static class ColorsConverter
    {
		public static RGB ToRGB(this HSL hsl)
		{
            byte r;
            byte g;
            byte b;

            if (hsl.S == 0)
            {
                r = g = b = (byte)(hsl.L * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)hsl.H / 360;

                v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : (hsl.L + hsl.S - (hsl.L * hsl.S));
                v1 = (2 * hsl.L) - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
                g = (byte)(255 * HueToRGB(v1, v2, hue));
                b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
            }

            return new RGB(r, g, b);
		}

		private static float HueToRGB(float v1, float v2, float vH)
		{
			if (vH < 0)
                vH++;

			if (vH > 1)
                vH--;

			if ((6 * vH) < 1)
				return v1 + ((v2 - v1) * 6 * vH);

			if ((2 * vH) < 1)
				return v2;

			if ((3 * vH) < 2)
				return v1 + ((v2 - v1) * ((2.0f / 3) - vH) * 6);

			return v1;
		}
	}
}

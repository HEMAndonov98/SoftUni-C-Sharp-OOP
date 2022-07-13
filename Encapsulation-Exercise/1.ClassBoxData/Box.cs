using System;
using System.Text;

namespace _1.ClassBoxData
{
	public class Box
	{
        private const string ZeroOrNegativeMsg = "{0} cannot be zero or negative.";
        private const int PropertyMinValue = 0;

        private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		public double Length {
			get
			{
				return this.length;
			}
			private set
			{
                if (value <= PropertyMinValue)
                {
					throw new ArgumentException(string.Format(ZeroOrNegativeMsg, nameof(this.Length)));
                }
				this.length = value;
			}
        }

		public double Width
        {
			get { return this.width; }
			private set
			{
                if (value <= PropertyMinValue)
                {
					throw new ArgumentException(string.Format(ZeroOrNegativeMsg, nameof(this.Width)));
                }
				this.width = value;
			}

        }

		public double Height
        {
			get { return this.height; }
			private set
			{
                if (value <= PropertyMinValue)
                {
                    throw new ArgumentException(string.Format(ZeroOrNegativeMsg, nameof(this.Height)));
                }
				this.height = value;
            }
        }

		public double SurfaceArea()
			=> (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

		public double LateralSurfaceArea()
			=> (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

		public double Volume()
			=> this.Length * this.Width * this.Height;

        public override string ToString()
        {
			var sb = new StringBuilder();
			sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
			sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
			sb.Append($"Volume - {this.Volume():F2}");
            return sb.ToString();
        }
    }
}


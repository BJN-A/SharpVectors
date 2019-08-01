﻿using System;
using System.Drawing;

using SharpVectors.Dom.Css;
using SharpVectors.Dom.Svg;

namespace SharpVectors.Renderers
{
    public static class GdiConverter
    {
        /// <summary>
        /// A GDI Color representation of the RgbColor
        /// </summary>
        public static Color ToColor(ICssColor color)
        {
            if (color == null)
            {
                return Color.Empty;
            }

            double dRed   = color.Red.GetFloatValue(CssPrimitiveType.Number);
            double dGreen = color.Green.GetFloatValue(CssPrimitiveType.Number);
            double dBlue  = color.Blue.GetFloatValue(CssPrimitiveType.Number);

            if (double.IsNaN(dRed) || double.IsInfinity(dRed))
            {
                return Color.Empty;
            }
            if (double.IsNaN(dGreen) || double.IsInfinity(dGreen))
            {
                return Color.Empty;
            }
            if (double.IsNaN(dBlue) || double.IsInfinity(dBlue))
            {
                return Color.Empty;
            }

            return Color.FromArgb(Convert.ToInt32(dRed), Convert.ToInt32(dGreen), Convert.ToInt32(dBlue));
        }

        public static RectangleF ToRectangle(ICssRect rect)
        {
            if (rect == null)
            {
                return RectangleF.Empty;
            }

            float x = (float)rect.Left.GetFloatValue(CssPrimitiveType.Px);
            float y = (float)rect.Top.GetFloatValue(CssPrimitiveType.Px);
            float width  = (float)rect.Right.GetFloatValue(CssPrimitiveType.Px) - x;
            float height = (float)rect.Bottom.GetFloatValue(CssPrimitiveType.Px) - y;

            return new RectangleF(x, y, width, height);
        }

        /// <summary>
        /// This converts the specified <see cref="RectangleF"/> structure to a 
        /// <see cref="SvgRectF"/> structure.
        /// </summary>
        /// <param name="rect">The <see cref="RectangleF"/> structure to convert.</param>
        /// <returns>
        /// The <see cref="SvgRectF"/> structure that is converted from the 
        /// specified <see cref="RectangleF"/> structure.
        /// </returns>
        public static RectangleF ToRectangle(SvgRectF rect)
        {
            return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static Rectangle Snap(this RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }

        public static RectangleF ToRectangle(SvgRect rect)
        {
            if (rect == null)
            {
                return RectangleF.Empty;
            }

            return new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
        }
    }
}

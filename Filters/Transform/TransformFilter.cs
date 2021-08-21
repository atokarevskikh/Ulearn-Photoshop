﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters>
        : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        string name;
        Func<Size, TParameters, Size> sizeTransform;
        Func<Point, Size, TParameters, Point?> pointTransform;

        public TransformFilter(
            string name,
            Func<Size, TParameters, Size> sizeTransform,
            Func<Point, Size, TParameters, Point?> pointTransform
        )
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize, parameters);
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }

        public override string ToString() => name;
    }
}
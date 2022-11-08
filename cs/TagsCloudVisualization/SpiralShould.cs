﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    [TestFixture]
    public class SpiralShould
    {
        [TestCase(0, 0)]
        [TestCase(1000, 500)]
        [TestCase(-200, -30)]
        public void Spiral_Create_ShouldHaveRightCenter(int centerX, int centerY)
        {
            var center = new Point(centerX, centerY);

            var spiral = new Spiral(center);

            spiral.center.Should().Be(center);
        }

        [Test]
        public void Spiral_CreateWithParams_ShouldHave2Points()
        {
            var center = Point.Empty;

            var spiral = new Spiral(center, 30, 10);

            spiral.Points.Count.Should().Be(2);
        }

        [Test]
        public void Spiral_CreateWithoutParams_ShouldHave2Points()
        {
            var center = Point.Empty;

            var spiral = new Spiral(center);

            spiral.Points.Count.Should().Be(2);
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        public void AddMorePointsInSpiral_AddPoints_ShouldAddNewPoints(int quantity)
        {
            var center = Point.Empty;
            var spiral = new Spiral(center);
            int expectedQuantity;

            if (quantity <= 0)
            {
                expectedQuantity = spiral.Points.Count;
            }
            else
            {
                expectedQuantity = spiral.Points.Count + quantity;
            }

            for (int i = 0; i < quantity; i++)
            {
                spiral.AddOneMorePointInSpiral();
            }

            spiral.Points.Count.Should().Be(expectedQuantity);
            spiral.FreePoints.Count.Should().Be(expectedQuantity);
        }
    }
}

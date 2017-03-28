﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using System;

namespace osu.Game.Screens.Select
{
    public class DetailsBar : Container
    {
        private Box background;
        private Box bar;

        private const int resize_duration = 250;

        private float length;
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                updateBarLength();
            }
        }

        public SRGBColour BackgroundColour
        {
            get
            {
                return background.Colour;
            }
            set
            {
                background.Colour = value;
            }
        }

        public SRGBColour BarColour
        {
            get
            {
                return bar.Colour;
            }
            set
            {
                bar.Colour = value;
            }
        }

        private BarDirection direction = BarDirection.LeftToRight;
        public BarDirection Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                updateBarLength();
            }
        }

        public DetailsBar()
        {
            Children = new []
            {
                background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                },
                bar = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                }
            };
        }

        private void updateBarLength()
        {
            switch (direction)
            {
                case BarDirection.LeftToRight:
                case BarDirection.RightToLeft:
                    bar.ResizeTo(new Vector2(length, 1), resize_duration);
                    break;
                case BarDirection.TopToBottom:
                case BarDirection.BottomToTop:
                    bar.ResizeTo(new Vector2(1, length), resize_duration);
                    break;
            }

            switch (direction)
            {
                case BarDirection.LeftToRight:
                case BarDirection.TopToBottom:
                    bar.Anchor = Anchor.TopLeft;
                    bar.Origin = Anchor.TopLeft;
                    break;
                case BarDirection.RightToLeft:
                case BarDirection.BottomToTop:
                    bar.Anchor = Anchor.BottomRight;
                    bar.Origin = Anchor.BottomRight;
                    break;
            }
        }
    }

    public enum BarDirection
    {
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop,
    }
}

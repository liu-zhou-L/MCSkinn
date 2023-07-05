﻿//
//    MCSkinn, A modern Minecraft 3D skin manager/editor for Windows by NotYoojun.!
//    Copyright © iNKORE! 2023
//
//    The copy of source (only the public part) can be used anywhere with a credit to MCSkinn page at your own risk
//    https://github.com/InkoreStudios/MCSkinn
//

using System;
using System.Drawing;
using System.Windows.Forms;
using Devcorp.Controls.Design;
using MCSkinn.Scripts.Paril.Controls.Color;

namespace MCSkinn.Forms.Controls
{
    public class SaturationSlider : Control
    {
        #region Component Designer generated code

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        private HSL _color;

        private int _curLum;
        private bool _down;

        public SaturationSlider()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserMouse |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
        }

        public HSL Color
        {
            get { return _color; }
            set
            {
                _color = value;
                Invalidate();
            }
        }

        public int CurrentLum
        {
            get { return _curLum; }
            set
            {
                _curLum = value;
                OnLumChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        protected virtual void OnLumChanged(EventArgs e)
        {
            if (LumChanged != null)
                LumChanged(this, e);
        }

        public event EventHandler LumChanged;

        private void CheckClick(MouseEventArgs e)
        {
            var borderThing = new Rectangle(0, 8, Width - 8, Height - 16);

            if (e.Y <= borderThing.Y)
                CurrentLum = 240;
            else if (e.Y >= borderThing.Y + borderThing.Height)
                CurrentLum = 0;
            else
            {
                float div = (e.Y - 8) / (float)borderThing.Height;

                CurrentLum = 240 - (int)(div * 240);
            }

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _down = true;
            CheckClick(e);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_down)
                CheckClick(e);
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _down = false;
            CheckClick(e);
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var borderThing = new Rectangle(0, 8, Width - 8, Height - 16);

            HSL half = Color;
            half.Luminance = 0.5f;
            ColorSpaceRenderer.GenerateColorSlider(e.Graphics, ColorSpaceHelper.HSLtoRGB(half).ToColor(), borderThing);

            ControlPaint.DrawBorder3D(e.Graphics, borderThing, Border3DStyle.SunkenOuter);

            float inc = (Height - 18) / 240.0f;

            float invLum = 240 - _curLum;

            e.Graphics.FillPolygon(System.Drawing.Brushes.Black,
                                   new[]
                                   {
                                       new Point(Width - 7, 6 + (int) (invLum * inc) + 2),
                                       new Point(Width - 1, 12 + (int) (invLum * inc) + 2),
                                       new Point(Width - 1, 0 + (int) (invLum * inc) + 2),
                                   }
                );
        }
    }
}
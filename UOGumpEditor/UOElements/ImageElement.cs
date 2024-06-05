﻿namespace UOGumpEditor.UOElements
{
    public class ImageElement : TransparentControl
    {
        public ElementTypes ElementType { get; set; }

        private Point _dragStartPoint;

        private bool _isDragging;

        public int GetLayer()
        {
            if (UOEditorCore.Z_Layer.Contains(this))
            {
                return UOEditorCore.Z_Layer.IndexOf(this);
            }
            else
            {
                return 0;
            }
        }

        public ImageElement()
        {
            BackColor = Color.Transparent;

            MouseDown += BaseElement_MouseDown;

            MouseMove += BaseElement_MouseMove;

            MouseUp += BaseElement_MouseUp;

            MouseDoubleClick += ImageElement_MouseDoubleClick;
        }

        private static void MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(Color.Black);
        }

        private void BaseElement_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragStartPoint = e.Location;

                _isDragging = true;

                BringToFront(); 
            }
        }

        private void BaseElement_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Location = new((Left + e.X - _dragStartPoint.X), (Top + e.Y - _dragStartPoint.Y));
            }
        }

        private void BaseElement_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;

                UOEditorCore.ReorderZLayers();
            }
        }

        private void ImageElement_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            // Open Element Editor
        }

        public void SetElement(ArtEntity entity)
        {
            Bitmap? tempBitmap = entity.GetImage();

            if (tempBitmap != null)
            {
                MakeTransparent(tempBitmap);

                Image = tempBitmap;

                Width = entity.Width;

                Height = entity.Height;
            }
        }

        public (int X, int Y) GetLocation()
        {
            if (Parent != null && Parent is Panel panel)
            {
                return (Location.X + panel.Location.X, Location.Y + panel.Location.Y);
            }
            else
            {
                return (Location.X, Location.Y + 26);
            }
        }

        public Image? GetImage()
        {
            return Image;
        }
    }
}
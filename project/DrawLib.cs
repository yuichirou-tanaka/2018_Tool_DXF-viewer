using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXFViewer
{
    class DrawLib
    {
        public static void ImageUpdate(PictureBox targetPictureBox, Bitmap targetBitmap)
        {
            targetPictureBox.Image = targetBitmap;
        }
        public static void DrawLinePenColor(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Color color)
        {
            try
            {
                Color backupColor = drawPen.Color;
                drawPen.Color = color;
                targetGraphics.DrawLine(drawPen, firstPoint, lastPoint);
                ImageUpdate(targetPictureBox, targetBitmap);
                drawPen.Color = backupColor;
            }
            catch (Exception e){
                MessageBox.Show(e.Message);
            }
        }
        public static void DrawLinePenBrush(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Brush ibrush)
        {
            try
            {
                Brush backup = drawPen.Brush;
                drawPen.Brush = ibrush;
                targetGraphics.DrawLine(drawPen, firstPoint, lastPoint);
                ImageUpdate(targetPictureBox, targetBitmap);
                drawPen.Brush = backup;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private static Rectangle GetPointToRect(Point firstPoint, Point lastPoint)
        {

            Rectangle rect = new Rectangle();
            if(firstPoint.X < lastPoint.X && firstPoint.Y < lastPoint.Y)
            {
                // 右下を動かす
                rect.X = firstPoint.X;
                rect.Y = firstPoint.Y;
                rect.Width = lastPoint.X - firstPoint.X;
                rect.Height = lastPoint.Y - firstPoint.Y;
            }
            else if (firstPoint.X > lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                // 左上を動かす
                rect.X = lastPoint.X;
                rect.Y = lastPoint.Y;
                rect.Width = firstPoint.X - lastPoint.X;
                rect.Height = firstPoint.Y - lastPoint.Y;
            }
            else if (firstPoint.X > lastPoint.X && firstPoint.Y < lastPoint.Y)
            {
                // 左上を動かす
                rect.X = lastPoint.X;
                rect.Y = firstPoint.Y;
                rect.Width = firstPoint.X - lastPoint.X;
                rect.Height = lastPoint.Y - firstPoint.Y;
            }
            else if (firstPoint.X < lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                // 左上を動かす
                rect.X = firstPoint.X;
                rect.Y = lastPoint.Y;
                rect.Width = lastPoint.X - firstPoint.X;
                rect.Height = firstPoint.Y - lastPoint.Y;
            }

            return rect;
        }

        public static void DrawRectangleColor(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Color color)
        {
            Color backupColor = drawPen.Color;
            drawPen.Color = color;
            targetGraphics.DrawRectangle(drawPen, GetPointToRect(firstPoint, lastPoint));
            ImageUpdate(targetPictureBox, targetBitmap);
            drawPen.Color = backupColor;
        }
        public static void DrawRectangleBrush(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Brush ibrush)
        {
            Brush backup = drawPen.Brush;
            drawPen.Brush = ibrush;
            targetGraphics.DrawRectangle(drawPen, GetPointToRect(firstPoint, lastPoint));
            ImageUpdate(targetPictureBox, targetBitmap);
            drawPen.Brush = backup;
        }

        public static void DrawEllipseColor(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Color color)
        {
            Color backupColor = drawPen.Color;
            drawPen.Color = color;
            targetGraphics.DrawEllipse(drawPen, GetPointToRect(firstPoint, lastPoint));
            ImageUpdate(targetPictureBox, targetBitmap);
            drawPen.Color = backupColor;
        }

        public static void DrawEllipseBrush(PictureBox targetPictureBox, Bitmap targetBitmap, Graphics targetGraphics, Pen drawPen, Point firstPoint, Point lastPoint, Brush ibrush)
        {
            Brush backup = drawPen.Brush;
            drawPen.Brush = ibrush;
            targetGraphics.DrawEllipse(drawPen, GetPointToRect(firstPoint, lastPoint));
            ImageUpdate(targetPictureBox, targetBitmap);
            drawPen.Brush = backup;
        }

    }

}

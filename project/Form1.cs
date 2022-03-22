using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXFViewer
{

    public partial class Form1 : Form
    {

        private Bitmap pictureBoxBitmap;
        Graphics pictureGraphics;

        Point pre = new Point();
        Boolean BakF = false;       // ラバーバンドを表示した時には True
        Point Bak = new Point();
        Pen drawingPen = new Pen(Brushes.DeepSkyBlue);
        //ControlPaint cpaint = new ControlPaint();
        FileDXF mFileDXF = new FileDXF();
        enum DrawStatus
        {
            None,
            Paint, // 1手書き線作図
            Ten,//2
            Siten,// 線　始点
            Syuten,// 線 終点

            SikakuSiten,    // 4
            SikakuSyuten,   // 5

            DaenSiten,//7楕円
            DaenSyuten,

            HaniSiten,
            HaniSyuten,
            HaniSyutenEnd,

            Harituke, //12 貼り付け

            Max
        };

        private DrawStatus DrawMode = DrawStatus.None;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            pictureBoxBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            pictureGraphics = Graphics.FromImage(pictureBoxBitmap);
            //pictureBox1に表示する
            pictureBox1.Image = pictureBoxBitmap;

            drawingPen.Width = 1.0f;
            drawingPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            //Work.saveY = -pictureBox1.Height / 2.0f;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //リソースを解放する
            pictureGraphics.Dispose();
            Console.WriteLine("Form1_FormClosed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mFileDXF.LoadClick(sender, e, this))
            {
                textBox1.Text = mFileDXF.bufferText;
            }
        }



        // draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawLine(Pens.Aqua, new Point(0, 10), new Point(100, 100));

            OnPainDataEntity();
        }

        private void OnPainDataEntity()
        {
            // line

            foreach (var line in Work.gDXFData.entity.lines)
            {
                // 線を作図
                Point now = new Point((int)line.x1, (int)line.y1);
                Point next = new Point((int)line.x2, (int)line.y2);
                DrawLib.DrawLinePenColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, now, next, Color.Black);
            }

            //rect
            foreach (var re in Work.gDXFData.entity.rects)
            {
                Point now = new Point((int)re.x1, (int)re.y1);
                Point next = new Point((int)re.x2, (int)re.y2);
                DrawLib.DrawRectangleColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, now, next, Color.Black);
            }


            //daen
            foreach (var re in Work.gDXFData.entity.daen)
            {
                Point now = new Point((int)re.x1, (int)re.y1);
                Point next = new Point((int)re.x2, (int)re.y2);
                DrawLib.DrawEllipseColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, now, next, Color.Black);
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearScreenAll();
        }

        public void ClearScreenAll() { 
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            pictureGraphics.FillRectangle(myBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);

            //pictureBox1に表示する
            pictureBox1.Image = pictureBoxBitmap;

            Work.gDXFData.entity.clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //折れ線を引く
            pictureGraphics.DrawEllipse(Pens.Black, new RectangleF(100, 100, 20, 20));
            //pictureBox1に表示する
            pictureBox1.Image = pictureBoxBitmap;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (DrawMode)
            {
                case DrawStatus.Paint:
                    {
                        pre.X = e.X;
                        pre.Y = e.Y;
                        break;
                    } // 1手書き線作図
                case DrawStatus.Ten:
                    {
                        MarkDraw(e.X, e.Y);
                        break;
                    }//2
                case DrawStatus.Siten:
                    {
                        pre.X = e.X;
                        pre.Y = e.Y;
                        DrawMode = DrawStatus.Syuten;
                        StatusBarLabel2.Text = "終点を指定";
                        break;
                    }//3
                case DrawStatus.SikakuSiten:
                    {
                        pre.X = e.X;
                        pre.Y = e.Y;
                        DrawMode = DrawStatus.SikakuSyuten;
                        StatusBarLabel2.Text = "終点を指定";
                        break;
                    }
                case DrawStatus.DaenSiten:
                    {
                        pre.X = e.X;
                        pre.Y = e.Y;
                        DrawMode = DrawStatus.DaenSyuten;
                        StatusBarLabel2.Text = "終点を指定";
                        break;
                    }//7楕円
                case DrawStatus.Harituke:
                    {
                        break;
                    }
                case DrawStatus.HaniSyuten:
                    {
                        break;
                    }
                case DrawStatus.HaniSyutenEnd:
                    {
                        break;
                    }
                case DrawStatus.None:
                    {
                        break;
                    }
                //12 貼り付け
                case DrawStatus.HaniSiten:
                    {
                        break;
                    }
                default: break;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (DrawMode)
                {
                    case DrawStatus.Syuten:
                        {
                            // 以前のラバーバンドを消す
                            if (BakF)
                            {
                                DrawLib.DrawLinePenBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                            }

                            //// 新しいラバーバンドを描く
                            DrawLib.DrawLinePenColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, new Point(e.X, e.Y), Color.Aqua);

                            BakF = true;
                            Bak.X = e.X;
                            Bak.Y = e.Y;

                            break;
                        }//3
                    case DrawStatus.SikakuSyuten:
                        {
                            // 以前のラバーバンドを消す
                            if (BakF)
                            {
                                DrawLib.DrawRectangleBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                            }

                            //// 新しいラバーバンドを描く
                            DrawLib.DrawRectangleColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, new Point(e.X, e.Y), Color.Aqua);

                            BakF = true;
                            Bak.X = e.X;
                            Bak.Y = e.Y;
                            break;
                        }

                    case DrawStatus.DaenSyuten:
                        {
                            // 以前のラバーバンドを消す
                            if (BakF)
                            {
                                DrawLib.DrawEllipseBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                            }

                            //// 新しいラバーバンドを描く
                            DrawLib.DrawEllipseColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, new Point(e.X, e.Y), Color.Aqua);

                            BakF = true;
                            Bak.X = e.X;
                            Bak.Y = e.Y;

                            break;
                        }
                    default: break;
                }

            }
            else if (e.Button == MouseButtons.None)
            {

                if (DrawMode == DrawStatus.Syuten) { 
                    // 線の終点モード(マウスを離した時)
                    // 以前のラバーバンドを消す
                    if (BakF) {
                        DrawLib.DrawLinePenBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                        BakF = false;
                    }
                    // 線を作図
                    Point next = new Point(e.X, e.Y);
                    DrawLib.DrawLinePenColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, next, Color.Black);

                    DrawMode = DrawStatus.Siten; // 線の始点モードに
                    StatusBarLabel2.Text = "始点を指定";

                    
                    Work.gDXFData.entity.lines.Add(new Data.DXFData.Entity.Line()
                    {
                        x1 = pre.X,
                        y1 = pre.Y,
                        x2 = next.X,
                        y2 = next.Y
                    });
                }
                else if (DrawMode == DrawStatus.SikakuSyuten)
                {
                    // 線の終点モード(マウスを離した時)
                    // 以前のラバーバンドを消す
                    if (BakF)
                    {
                        DrawLib.DrawRectangleBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                        BakF = false;
                    }
                    // 線を作図
                    Point next = new Point(e.X, e.Y);

                    DrawLib.DrawRectangleColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, next, Color.Black);

                    DrawMode = DrawStatus.SikakuSiten; // 線の始点モードに
                    StatusBarLabel2.Text = "始点を指定";


                    Work.gDXFData.entity.rects.Add(new Data.DXFData.Entity.Rect()
                    {
                        x1 = pre.X,
                        y1 = pre.Y,
                        x2 = next.X,
                        y2 = next.Y
                    });

                }
                else if (DrawMode == DrawStatus.DaenSyuten)
                {
                    // 線の終点モード(マウスを離した時)
                    // 以前のラバーバンドを消す
                    if (BakF)
                    {
                        DrawLib.DrawEllipseBrush(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, Bak, Brushes.White);
                        BakF = false;
                    }
                    // 線を作図
                    Point next = new Point(e.X, e.Y);

                    DrawLib.DrawEllipseColor(pictureBox1, pictureBoxBitmap, pictureGraphics, drawingPen, pre, next, Color.Black);

                    DrawMode = DrawStatus.DaenSiten; // 線の始点モードに
                    StatusBarLabel2.Text = "始点を指定";

                    Work.gDXFData.entity.daen.Add(new Data.DXFData.Entity.Rect()
                    {
                        x1 = pre.X,
                        y1 = pre.Y,
                        x2 = next.X,
                        y2 = next.Y
                    });

                }
            }

            /**
      else if (DrawMode = 8) then begin   // 楕円の終点モード(ドラッグ中)
         // 以前のラバーバンドを消す
         if (BakF) then begin
            with Image1.Canvas do begin
               Brush.Style := bsClear ;
               Pen.Mode := pmXor ;
               Pen.Color := clAqua ;
               Pen.Width := 0 ;
               Pen.Style := psSolid ;
               Ellipse(PreX,PreY, BakX,BakY);
            end;
         end;
         // 新しいラバーバンドを描く
         with Image1.Canvas do begin
            Brush.Style := bsClear ;
            Pen.Mode := pmXor ;
            Pen.Color := clAqua ;   // ラバーバンドは赤色になるように
            Pen.Width := 0 ;
            Pen.Style := psSolid ;
            Ellipse(PreX,PreY, X,Y);   // 直前の座標から今回の座標まで、ラバーバンドを作図
            BakF := True ;
            BakX := X ;
            BakY := Y ;
         end;
      end
      else if (DrawMode = 10) then begin  // 範囲選択の終点モード(ドラッグ中)
         // 以前のラバーバンドを消す
         if (BakF) then begin
            with Image1.Canvas do begin
               Brush.Style := bsClear ;
               Pen.Mode := pmXor ;
               Pen.Color := clYellow ;
               Pen.Width := 0 ;
               Pen.Style := psSolid ;
               Rectangle(PreX,PreY, BakX,BakY);
            end;
         end;
         // 新しいラバーバンドを描く
         with Image1.Canvas do begin
            Brush.Style := bsClear ;
            Pen.Mode := pmXor ;
            Pen.Color := clYellow ;   // ラバーバンドは青色になるように
            Pen.Width := 0 ;
            Pen.Style := psSolid ;
            Rectangle(PreX,PreY, X,Y); // 直前の座標から今回の座標まで、ラバーバンドを作図
            BakF := True ;
            BakX := X ;
            BakY := Y ;
         end;
      end
   end
   else begin
      else if (DrawMode = 8) then begin   // 楕円の終点モード(マウスを離した時)
         // 以前のラバーバンドを消す
         if (BakF) then begin
            with Image1.Canvas do begin
               Brush.Style := bsClear ;
               Pen.Mode := pmXor ;
               Pen.Color := clAqua ;
               Pen.Width := 0 ;
               Pen.Style := psSolid ;
               Ellipse(PreX,PreY, BakX,BakY);
            end;
            BakF := False ;
         end;
         // 楕円を作図
         PenBrushSet ;
         with Image1.Canvas do begin
            Ellipse(PreX,PreY, X,Y);   // 直前の座標から今回の座標まで、楕円を作図
         end;
         DrawMode := 7 ; // 始点モードに
         StatusBar1.Panels[1].Text := '始点を指定';
      end
      else if (DrawMode = 10) then begin   // 範囲選択の終点モード(マウスを離した時)
         // 以前のラバーバンドは消さずに残す
         // 以前ラバーバンドを描いていない場合はDragModeを0に
         // この範囲選択ラバーバンドは、他のコマンドを動かす直前に消す
         if not(BakF) then begin
            DrawMode := 0 ;
         end
         else begin
            // 連続で範囲選択は行わない
            DrawMode := 11 ;
            StatusBar1.Panels[1].Text := '範囲選択を行いました。';
         end;
      end;
   end;

   if (DrawMode = 12) then begin  // 貼り付け（マウス移動中、四角を描く）
      // 以前の四角を消す
      if (BakF) then begin
         with Image1.Canvas do begin
            Brush.Style := bsClear ;
            Pen.Mode := pmXor ;
            Pen.Color := clYellow ;
            Pen.Width := 0 ;
            Pen.Style := psSolid ;
            PreX := BakX+ClipImage.Width ;
            PreY := BakY+ClipImage.Height ;
            Rectangle(BakX,BakY, PreX,PreY);
         end;
      end;
      // 新しいラバーバンドを描く
      with Image1.Canvas do begin
         Brush.Style := bsClear ;
         Pen.Mode := pmXor ;
         Pen.Color := clYellow ;   // ラバーバンドは青色になるように
         Pen.Width := 0 ;
         Pen.Style := psSolid ;
         BakX := X ;
         BakY := Y ;
         PreX := BakX+ClipImage.Width ;
         PreY := BakY+ClipImage.Height ;
         Rectangle(BakX,BakY, PreX,PreY);
         BakF := True ;
      end;
   end;
             */
            OnPainDataEntity();

        }


        // 点（マーク）を描きます
        //    x,y : 中心の座標
        private void MarkDraw(int x, int y)
        {

            int sz = 10;
            Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
            skyBluePen.Width = 1.0f;
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            pictureGraphics.DrawRectangle(skyBluePen, new Rectangle(x - sz, y - sz, sz, sz));
            //pictureBox1に表示する
            pictureBox1.Image = pictureBoxBitmap;

            

            //         // ペンの幅→点の大きさ 　円の場合,半径をszに入れる
            //         sz= StrToInt(Edit1.Text) div 2;

            //         PenBrushSet;   // ペンとブラシをセット
            //         Image1.Canvas.Pen.Width = 0; // ペン幅は0に
            
            //Case(ComboBox5.ItemIndex)of
            //// ○
            //0: begin
            //      Image1.Canvas.Ellipse(x - sz, y - sz, x + sz, y + sz);
            //         end;
            //         // □
            //         1: begin
            //      Image1.Canvas.Rectangle(x - sz, y - sz, x + sz, y + sz);
            //         end;
            //         // ◇
            //         2: begin
            //      Image1.Canvas.Polygon([Point(x, y - sz), Point(x - sz, y), Point(x, y + sz), Point(x + sz, y)]);
            //         end;
            //         // △
            //         3: begin
            //      Image1.Canvas.Polygon([Point(x, y - sz), Point(x - sz, y + sz), Point(x + sz, y + sz)]);
            //         end;
            //         // ▽
            //         4: begin
            //      Image1.Canvas.Polygon([Point(x, y + sz), Point(x - sz, y - sz), Point(x + sz, y - sz)]);
            //         end;
            //         // ／
            //         5: begin
            //      Image1.Canvas.MoveTo(x - sz, y + sz);
            //         Image1.Canvas.LineTo(x + sz, y - sz);
            //         end;
            //         // ＼
            //         6: begin
            //      Image1.Canvas.MoveTo(x - sz, y - sz);
            //         Image1.Canvas.LineTo(x + sz, y + sz);
            //         end;
            //         // ＋
            //         7: begin
            //      Image1.Canvas.MoveTo(x, y - sz);
            //         Image1.Canvas.LineTo(x, y + sz);
            //         Image1.Canvas.MoveTo(x - sz, y);
            //         Image1.Canvas.LineTo(x + sz, y);
            //         end;
            //         // ×
            //         8: begin
            //      Image1.Canvas.MoveTo(x - sz, y + sz);
            //         Image1.Canvas.LineTo(x + sz, y - sz);
            //         Image1.Canvas.MoveTo(x - sz, y - sz);
            //         Image1.Canvas.LineTo(x + sz, y + sz);
            //         end;
            //         end;
            //         end;
        }

        private void FreePenBtn_Click(object sender, EventArgs e)
        {
            //SelectBoxClear;  // 範囲選択ＢＯＸを消す
            DrawMode = DrawStatus.Paint;   // 作図モード＝手書き線
            StatusBarLabel.Text = "手描き線";
            StatusBarLabel2.Text = "";
        }
        private void TenPenBtn_Click(object sender, EventArgs e)
        {
            // SelectBoxClear;  // 範囲選択ＢＯＸを消す
            DrawMode = DrawStatus.Ten;   // 作図モード＝点
            StatusBarLabel.Text = "点";
            StatusBarLabel2.Text = "";
        }

        private void LinePenBtn_Click(object sender, EventArgs e)
        {
            //SelectBoxClear;  // 範囲選択ＢＯＸを消す
            DrawMode = DrawStatus.Siten;   // 作図モード＝線・始点
            StatusBarLabel.Text = "線";
            StatusBarLabel2.Text = "始点を指定";

        }

        private void SikakuPenBtn_Click(object sender, EventArgs e)
        {
            //SelectBoxClear;  // 範囲選択ＢＯＸを消す
            DrawMode = DrawStatus.SikakuSiten;   // 作図モード＝四角・始点
            StatusBarLabel.Text = "四角";
            StatusBarLabel2.Text = "始点を指定";

        }

        private void MaruPenBtn_Click(object sender, EventArgs e)
        {
            //SelectBoxClear;  // 範囲選択ＢＯＸを消す
            DrawMode = DrawStatus.DaenSiten;   // 作図モード＝楕円・始点
            StatusBarLabel.Text = "楕円";
            StatusBarLabel2.Text = "始点を指定";
        }

        private void HaniPenBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (mFileDXF.SaveClick(sender, e))
            {
                
            }
        }
    }
}

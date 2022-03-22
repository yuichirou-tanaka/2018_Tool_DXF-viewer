using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXFViewer
{
    class FileDXF
    {
        string fbufferText;

        public string bufferText
        {
            get { return fbufferText; }
        }

        public FileDXF()
        {
        }

        public bool LoadClick(object sender, EventArgs e, Form1 refForm1) 
        {
            Console.WriteLine("ok");
            OpenFileDialog ofd = new OpenFileDialog();
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "DXFファイル(*.dxf)|*.dxf|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName);

                // textBox1.Text = ofd.FileName;
                LoadFile(ofd.FileName, refForm1);
                return true;
            }
            return false;
        }

        private void LoadFile(string filename, Form1 refForm1)
        {

            // clear
            refForm1.ClearScreenAll();
            Work.gDXFData.clear();

            //ファイルを開く
            FileStream fs = new System.IO.FileStream(
                filename,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            StreamReader sr = new StreamReader(fs);
            // 1行ずつ読み込む
            while (sr.Peek() != -1)
            {
                string buf = sr.ReadLine();
                Console.WriteLine(buf);
                fbufferText += buf + Environment.NewLine;
                if(buf == "LINE")
                {
                    Data.DXFData.Entity.Line linex = new Data.DXFData.Entity.Line();
                    bool breakflag = false;
                    while (!breakflag)
                    {
                        buf = sr.ReadLine();
                        if (buf == "10")
                        {
                            buf = sr.ReadLine();
                            linex.x1 = float.Parse(buf);
                        }
                        else if (buf == "11")
                        {
                            buf = sr.ReadLine();
                            linex.x2 = float.Parse(buf);
                        }
                        else if (buf == "20")
                        {
                            buf = sr.ReadLine();
                            linex.y1 = float.Parse(buf);
                        }
                        else if (buf == "21")
                        {
                            buf = sr.ReadLine();
                            linex.y2 = float.Parse(buf);
                            breakflag = true;
                        }

                        if (breakflag) break;
                    }
                    Work.gDXFData.entity.lines.Add(linex);

                }
                else if (buf == "CIRCLE")
                {
                    Data.DXFData.Entity.Circle linex = new Data.DXFData.Entity.Circle();
                    bool breakflag = false;
                    while (!breakflag)
                    {
                        buf = sr.ReadLine();
                        if (buf == "10")
                        {
                            buf = sr.ReadLine();
                            linex.x = float.Parse(buf);
                        }
                        else if (buf == "20")
                        {
                            buf = sr.ReadLine();
                            linex.y = float.Parse(buf);
                        }
                        else if (buf == "40")
                        {
                            buf = sr.ReadLine();
                            linex.radian = float.Parse(buf);
                            breakflag = true;
                        }

                        if (breakflag) break;
                    }
                    Work.gDXFData.entity.circles.Add(linex);
                }
            }
            //閉じる
            fs.Close();
        }


        public bool SaveClick(object sender, EventArgs e)
        {
            Console.WriteLine("ok");
            SaveFileDialog sfd = new SaveFileDialog();
            //指定しないとすべてのファイルが表示される
            sfd.Filter = "DXFファイル(*.dxf)|*.dxf|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //0番目の「"DXFファイル(*.dxf)」が選択されているようにする
            sfd.FilterIndex = 0;

            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(sfd.FileName);

                // textBox1.Text = ofd.FileName;
                SaveFile(sfd);
                return true;
            }
            return false;
        }
        private void SaveFile(SaveFileDialog sfd)
        {
            try
            {  
                //ファイルを開く
                using (StreamWriter writer = new StreamWriter(sfd.OpenFile()))
                {
                    string buf = "";
                    Data.DXFData dxfdata = Work.gDXFData;
                    buf = @"  0
SECTION
  2
HEADER
  9
$ACADVER
  1
AC1009
  9
$INSBASE
 10
0
 20
0
 30
0
  9
$EXTMIN
 10
0
 20
0
  9
$EXTMAX
 10
891
 20
630
  9
$LIMMIN
 10
0
 20
0
  9
$LIMMAX
 10
891
 20
630
  9
$LTSCALE
 40
3
  0
ENDSEC";

                    //buf += "0" + Environment.NewLine + "SECTION";
                    //buf += Environment.NewLine + "2" + Environment.NewLine + "HEADER";
                    //// header

                    //buf += Environment.NewLine + "0" + Environment.NewLine + "ENDSEC";


                    // entity
                    buf += Environment.NewLine + "0" + Environment.NewLine + "SECTION";
                    buf += Environment.NewLine + dxfdata.entity.entities + Environment.NewLine + "ENTITIES";

                    for (int i = 0; i < dxfdata.entity.lines.Count; ++i)
                    {
                        Data.DXFData.Entity.Line _line = dxfdata.entity.lines[i];
                        buf += Environment.NewLine + "0" + Environment.NewLine + "LINE";

                        buf += Environment.NewLine + "8" + Environment.NewLine + _line.layername;
                        buf += Environment.NewLine + "62" + Environment.NewLine + _line.color;
                        buf += Environment.NewLine + "6" + Environment.NewLine + _line.type;
                        buf += Environment.NewLine + "10" + Environment.NewLine + _line.x1;
                        buf += Environment.NewLine + "11" + Environment.NewLine + _line.x2;
                        float _y1 = _line.y1;// + Work.saveY;
                        float _y2 = _line.y2;// + Work.saveY;
                        buf += Environment.NewLine + "20" + Environment.NewLine + _y1;
                        buf += Environment.NewLine + "21" + Environment.NewLine + _y2;

                    }



                    for (int i = 0; i < dxfdata.entity.rects.Count; ++i)
                    {
                        Data.DXFData.Entity.Rect _rect = dxfdata.entity.rects[i];

                        for(int j = 0; j < 4; ++j)
                        {
                            float x1 = _rect.x1;
                            float x2 = _rect.x1;
                            float y1 = _rect.y1;
                            float y2 = _rect.y2;
                            switch (j)
                            {
                                case 0:
                                    {
                                        //|
                                        x1 = _rect.x1;
                                        x2 = _rect.x1;
                                        y1 = _rect.y1;
                                        y2 = _rect.y2;
                                    }
                                    break;
                                case 1:
                                    {
                                        //_
                                        x1 = _rect.x1;
                                        x2 = _rect.x2;
                                        y1 = _rect.y1;
                                        y2 = _rect.y1;

                                    }
                                    break;
                                case 2:
                                    {
                                        //|
                                        x1 = _rect.x2;
                                        x2 = _rect.x2;
                                        y1 = _rect.y1;
                                        y2 = _rect.y2;

                                    }
                                    break;
                                case 3:
                                    {
                                        x1 = _rect.x1;
                                        x2 = _rect.x2;
                                        y1 = _rect.y2;
                                        y2 = _rect.y2;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            buf += Environment.NewLine + "0" + Environment.NewLine + "LINE";
                            buf += Environment.NewLine + "8" + Environment.NewLine + _rect.layername;
                            buf += Environment.NewLine + "10" + Environment.NewLine + x1;
                            buf += Environment.NewLine + "11" + Environment.NewLine + x2;
                            buf += Environment.NewLine + "20" + Environment.NewLine + y1;
                            buf += Environment.NewLine + "21" + Environment.NewLine + y2;
                        }
                    }



                    buf += Environment.NewLine + "0" + Environment.NewLine + "ENDSEC";
                    buf += Environment.NewLine + "0" + Environment.NewLine + "EOF";
                    writer.Write(buf);
                    writer.Dispose();
                    writer.Close();
                }

            }
            catch (Exception e){
                MessageBox.Show(e.Message);
            }
          
        }



    }
}

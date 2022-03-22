using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFViewer.Data
{
    class DXFData
    {
        public class Header
        {
            public int section = 0;
            public int header = 2;
            public int endsec = 0;
            

        }

        public class Entity 
        {
            public int section = 0;
            public int entities = 2;
            //
            // line
            /*
             * 
             * 
             * //                色 赤   黄 緑   水 青   紫 白
//色番号	１	２	３	４	５	６	７

             * 
    __0
    LINE
    __8
    0 　　　　　　←レイヤー名
    _62
    _____5　　　　←色番号
    __6
    CENTER　　　　←線種名
    _10
    100.0 　　　　←開始点ｘ座標値
    _20
    200.0 　　　　←開始点ｙ座標値
    _11
    300.0 　　　　←終了点ｘ座標値
    _21
    400.0 　　　　←終了点ｙ座標値
    __0
             * 
             */
            public List<Line> lines = new List<Line>();
            public List<Rect> rects = new List<Rect>();
            public List<Rect> daen = new List<Rect>();
            public List<Circle> circles = new List<Circle>();
            public List<Arc> arcs = new List<Arc>();

            public class Line
            {
                public int layername = 0;
                public int color = 0;
                public string type = "CENTER";
                public float x1 = 0;
                public float y1 = 0;
                public float x2 = 0;
                public float y2 = 0;
            }
            public class Circle
            {
                public int layername = 0;
                public float x = 0;
                public float y = 0;
                public float radian = 0;
            }
            public class Rect
            {
                public int layername = 0;
                public float x1 = 0;
                public float y1 = 0;
                public float x2 = 0;
                public float y2 = 0;
            }

            public class Arc
            {
                public int layername = 0;
                public float x = 0;
                public float y = 0;
                public float radian = 0;
                public float degree1 = 0;
                public float degree2 = 0;
            }
            public class Point
            {
                public int layername = 0;
                public float x = 0;
                public float y = 0;
            }
            public class Text
            {
                public int layername = 0;
                public float x = 0;
                public float y = 0;
                public float mojitakasa = 0;
                public string msg = "";
                public float degree = 0;
                public float xsyakudo = 0;
            }
            public class Text2
            {
                public int layername = 0;
                public float x1 = 0;
                public float y1 = 0;
                public float mojitakasa = 0;
                public string msg = "";
                public float x2 = 0;
                public float y2 = 0;
                public int yokoitiawase = 0;
            }

            public Entity()
            {

            }

            public void clear()
            {
                lines.Clear();
                rects.Clear();
                daen.Clear();
                circles.Clear();
                arcs.Clear();

            }
        }


        public Header header = new Header();
        public Entity entity = new Entity();

        public void clear()
        {
            //header.Clear();
            entity.clear();
        }
    }
}

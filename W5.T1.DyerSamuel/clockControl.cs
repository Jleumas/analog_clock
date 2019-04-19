using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace W5.T1.DyerSamuel
{
    class ClockControl
    {
        public ClockControl(int canvasSize)
        {
            secondHandLength = (int)(canvasSize * 0.5 * 0.9F);
            minuteHandLength = (int)(canvasSize * 0.5 * 0.6F);
            hourHandLength = (int)(canvasSize * 0.5 * 0.35F);

            Origin.X = canvasSize / 2;
            Origin.Y = canvasSize / 2;
        }

        public int secondHandLength;
        public int minuteHandLength;
        public int hourHandLength;

        public Point Origin;

        public Pen returnPen(string timeType)
        {
            float width;
            Color color;
            switch (timeType)
            {
                case "hour":
                    width = 8F;
                    color = Color.Black;
                    break;

                case "minute":
                    width = 5F;
                    color = Color.Blue;
                    break;

                case "second":
                    width = 2F;
                    color = Color.Red;
                    break;

                default:
                    width = 0F;
                    color = Color.Black;
                    break;
            }
            Pen pen = new Pen(color, width);
            return pen;
        }

        public Point handPosition(int angle, int radius)
        {
            Point point = new Point();
            point.X = (int)(Origin.X + (radius * Math.Cos(degreesToRadians(angle))));
            point.Y = (int)(Origin.Y + (radius * Math.Sin(degreesToRadians(angle))));
            return point;
        }

        public Point updateSeconds()
        {
            return handPosition((270 + (DateTime.Now.Second * 6)), secondHandLength);      //one second per six degrees;
        }

        public Point updateMinutes()
        {
            return handPosition((270 + (DateTime.Now.Minute * 6)), minuteHandLength);      //one minute per six degrees;
        }

        public Point updateHours()
        {
            return handPosition((270 + (DateTime.Now.Hour * 30)), hourHandLength);     //one hour per 30 degrees;
        }

        public double degreesToRadians(int angle)
        {
            double radians = angle * Math.PI / 180; //degrees * radians per degree
            return radians;
        }
    }
}

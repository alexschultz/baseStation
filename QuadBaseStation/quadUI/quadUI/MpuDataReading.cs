using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadUI
{
    public class MpuDataReading
    {
        public double Temp { get; set; }
        public Gyroscope Gyro { get; set; }
        public Accelerometer Acce { get; set; }
        public MpuDataReading(String mpuData)
        {
            /*The MPU data will be transmitted as small as possile 
             *The format will be mAcceleration[X]|Acceleration[Y]| Acceleration[Z]|Temp|Gyro[X]|Gyro[Y]|Gyro[Z]~
             *i.e. m2|4|72|95|100|100|100~
             */
            try
            {

                String[] mpuArray = mpuData.Remove(0, 2).Remove(mpuData.Length - 3).Split('|');
                this.Acce = new Accelerometer(System.Math.Round((Convert.ToDouble(mpuArray[0]) / 65535) * 100), System.Math.Round((Convert.ToDouble(mpuArray[1]) / 65535) * 100), System.Math.Round((Convert.ToDouble(mpuArray[2]) / 65535) * 100));
                this.Temp = Convert.ToInt32(mpuArray[3]) * 1.8 + 32;
                this.Gyro = new Gyroscope(System.Math.Round((Convert.ToDouble(mpuArray[4]) / 65535) * 100), System.Math.Round((Convert.ToDouble(mpuArray[5]) / 65535) * 100), System.Math.Round((Convert.ToDouble(mpuArray[6]) / 65535) * 100));
            }
            catch (Exception ex)
            {
                this.Gyro = new Gyroscope(0, 0, 0);
                this.Acce = new Accelerometer(0, 0, 0);
                this.Temp = 0;
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("MPU: ");
            sb.Append("TEMP " + this.Temp);
            sb.Append(" ");
            sb.Append(this.Gyro.ToString());
            sb.Append(this.Acce.ToString());
            return sb.ToString();
        }
    }

    public class Gyroscope
    {
        public double X{get;set;}
        public double Y{get;set;}
        public double Z{get;set;}
        public Gyroscope(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return String.Format("Gyro X[{0}]Y[{1}]Z[{2}]",X,Y,Z);
        }
    }

    public class Accelerometer
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Accelerometer(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return String.Format("Acc X[{0}]Y[{1}]Z[{2}]", X, Y, Z);
        }
    }

}

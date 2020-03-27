using System;
using System.Windows.Forms.Design;
using System.Text;

namespace UsingMaskedTextBox
{

    //  Implement custom types for Latitude.
    public class Latitude
    {
        private float v;
        private DirectionEnum d;

        public Latitude(float value, DirectionEnum direction)
        {
            this.Value = value;
            this.Direction = direction;
        }

        //  Constructor: "97.3 N", "123 S"
        public Latitude(string latitude)
        {
            char[] seperator = new char[2];
            seperator[0] = ' ';
            string[] parts = latitude.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            this.Value = float.Parse(parts[0]);
            switch (parts[1].ToUpper())
            {
                case "N":
                    this.Direction = DirectionEnum.North;
                    break;
                case "S":
                    this.Direction = DirectionEnum.South;
                    break;
                default:
                    throw new ApplicationException("Invalid latitude. You must specify N or S.");
            }
        }

        public DirectionEnum Direction
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
            }
        }

        public float Value
        {
            get
            {
                return v;
            }
            set
            {
                if (((0 <= value) && (value <= 90)))
                {
                    v = value;
                }
                else
                {
                    throw new Exception("Invalid Latitude value.");
                }
            }
        }

        public override string ToString()
        {
            string directionString;
            if ((this.Direction == DirectionEnum.North))
            {
                directionString = "N";
            }
            else
            {
                directionString = "S";
            }
            return (this.Value.ToString() + (" " + directionString));
        }

        //  A public static Parse method is required for MaskedTextBox 
        //  custom type validation
        public static Latitude Parse(string latitude)
        {
            return new Latitude(latitude);
        }

        public enum DirectionEnum
        {

            North,

            South,
        }
    }
    //  Implement a MaskDescriptor for the Latitude type.  
    //  The InputMask dialog will display all types for which
    //  a MaskDescriptor is found.
    public class LatitudeMaskDescriptor : MaskDescriptor
    {

        public override string Mask
        {
            get
            {
                return "00 >L";
            }
        }

        public override string Name
        {
            get
            {
                return "Latitude";
            }
        }

        public override string Sample
        {
            get
            {
                return "58 N";
            }
        }

        public override Type ValidatingType
        {
            get
            {
                return typeof(Latitude);
            }
        }
    }
}
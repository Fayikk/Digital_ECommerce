using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Digital_Domain_Layer.Enums
{

    //var action = ActionCode.Edit;
    //var actionDescription = action.GetDescription();

    public enum Colors
    {
        [Description("Red")]
        Red,
        [Description("Orange")]

        Orange, 
        [Description("Yellow")]

        Yellow,
        [Description("Green")]

        Green,
        [Description("Blue")]

        Blue,
        [Description("Indigo")]

        Indigo,
        [Description("Violet")]

        Violet,
        [Description("Black")]

        Black,
        [Description("White")]

        White,
        [Description("Brown")]

        Brown,
        [Description("Pink")]

        Pink,
        [Description("Purple")]

        Purple,
        [Description("Gray")]

        Gray,
        [Description("Silver")]

        Silver,
        [Description("Gold")]

        Gold
    }
}

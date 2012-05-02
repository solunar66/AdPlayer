using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PLAY
{
    class CalenderCell : MonthCalendar
    {
        public DataGridViewCell cell = null;
        public CalenderCell(DataGridViewCell c) 
        { 
            cell = c;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class Block
    {
        public Control Blockobject { get; set; }
        
        public Block(Control pBlockobject)
        {
            this.Blockobject = pBlockobject;
        }
    }
}

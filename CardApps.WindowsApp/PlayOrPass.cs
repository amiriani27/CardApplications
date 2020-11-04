using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardApps.WindowsApp
{
    public partial class PlayOrPass : UserControl
    {
        public delegate void OptionClickedHandler(string optSelected);

        public PlayOrPass()
        {
            InitializeComponent();
        }

        private void optPickItUp_CheckedChanged(object sender, EventArgs e)
        {
            OnSubmitClicked("PICK");
        }

        private void optPass_CheckedChanged(object sender, EventArgs e)
        {
            OnSubmitClicked("PASS");
        }

        private void optAlone_CheckedChanged(object sender, EventArgs e)
        {
            OnSubmitClicked("ALONE");
        }

        public event OptionClickedHandler OptionClicked;
        // Add a protected method called OnSubmitClicked().
        // You may use this in child classes instead of adding
        // event handlers.
        protected virtual void OnSubmitClicked(string selectedOption)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (OptionClicked != null)
            {
                OptionClicked(selectedOption);  // Notify Subscribers
            }
        }

    }
}

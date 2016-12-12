using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetraSurpriseMvc.ViewModels
{
    public class CheckBoxItem
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Checked
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Id.ToString() ;
        }
    }
}
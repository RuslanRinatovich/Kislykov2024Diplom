using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetrospektivaApp.Entities
{
    public partial class Service
    {

        public Visibility GetVisibility
        {
            get
            {
                if (Manager.CurrentUser == null)
                    return Visibility.Collapsed;
                if (Manager.CurrentUser.RoleId < 2)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }
    }
}
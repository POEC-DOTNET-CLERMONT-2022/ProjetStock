 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Application.Utils
{
    public interface INavigator
    {
        public ContentControl CurrentContentControl { get; set; }

        void RegisterView(Control view);
        
        void NavigateTo(Type type);

        void Back();

        bool CanGoBack();
    }
}

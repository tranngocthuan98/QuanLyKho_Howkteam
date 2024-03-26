using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class ControlBarViewModel
    {
        #region commands
        public ICommand CloseWindowCommand {  get; set; }
        public ICommand MinimizeWindowCommand {  get; set; }
        public ICommand MaximizeWindowCommand {  get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        #endregion
        public ControlBarViewModel() 
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = (FindParent(p) as FrameworkElement) as Window;
                if (window != null)
                {
                    window.Close();
                }
            });
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = (FindParent(p) as FrameworkElement) as Window;
                if (window != null)
                {
                    if(window.WindowState != WindowState.Minimized)
                        window.WindowState = WindowState.Minimized;
                    else window.WindowState = WindowState.Maximized;
                }
            });
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = (FindParent(p)as FrameworkElement) as Window;
                if (window != null)
                {
                    if (window.WindowState != WindowState.Maximized)
                        window.WindowState = WindowState.Maximized;
                    else window.WindowState = WindowState.Normal;
                }
            });
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = (FindParent(p) as FrameworkElement) as Window;
                if(window != null)
                {
                    window.DragMove();
                }
            });
        }
        FrameworkElement FindParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}

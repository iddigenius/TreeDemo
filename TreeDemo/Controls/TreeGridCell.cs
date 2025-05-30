/*
 *  主要参考：https://blog.csdn.net/lhx527099095/article/details/8061169/ 
 */

namespace TreeDemo.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /*
     * https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Controls/GridViewRowPresenter.cs,ace7d38fc902993d
     * GridViewRow里的每个元素，增加了一个默认的Margin，这样在设置边框的时候会比较麻烦，在运行时去掉
     */
    public class TreeGridCell : ContentControl
    {
        static TreeGridCell()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeGridCell), new FrameworkPropertyMetadata(typeof(TreeGridCell)));
        }

        public TreeGridCell()
        {
            Loaded += TreeGridCell_Loaded;
            //test
        }

        private void TreeGridCell_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= TreeGridCell_Loaded;
            var p = VisualTreeHelper.GetParent(this);
            if (p != null && p is FrameworkElement f && f.Margin.Left > 0)
            {
                f.Margin = new Thickness(0);
            }
        }
    }
}

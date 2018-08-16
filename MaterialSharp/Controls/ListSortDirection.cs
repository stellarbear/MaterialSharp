using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MaterialSharp.Controls
{
    [TemplateVisualState(GroupName = DirectionGroupName, Name = NoneStateName)]
    [TemplateVisualState(GroupName = DirectionGroupName, Name = AscendingStateName)]
    [TemplateVisualState(GroupName = DirectionGroupName, Name = DescendingStateName)]
    public class ListSortDirectionToggle : Control
    {
        public const string DirectionGroupName = "Direction";
        public const string NoneStateName = "None";
        public const string AscendingStateName = "Ascending";
        public const string DescendingStateName = "Descending";

        static ListSortDirectionToggle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListSortDirectionToggle), new FrameworkPropertyMetadata(typeof(ListSortDirectionToggle)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            GotoVisualState(true, ListSortDirection);
        }


        public static readonly DependencyProperty ListSortDirectionProperty = DependencyProperty.Register(
            nameof(ListSortDirection), typeof(ListSortDirection?), typeof(ListSortDirectionToggle), new PropertyMetadata(default(ListSortDirection?), ListSortDirectionPropertyChangedCallback));

        private static void ListSortDirectionPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var indicator = (ListSortDirectionToggle)dependencyObject;
            indicator.GotoVisualState(true, indicator.ListSortDirection);
            indicator.IsNeutral = !indicator.ListSortDirection.HasValue;
        }

        public ListSortDirection? ListSortDirection
        {
            get { return (ListSortDirection?)GetValue(ListSortDirectionProperty); }
            set { SetValue(ListSortDirectionProperty, value); }
        }

        private static readonly DependencyPropertyKey IsNeutralPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsNeutral", typeof(bool), typeof(ListSortDirectionToggle),
                new PropertyMetadata(true));

        public static readonly DependencyProperty IsNeutralProperty =
            IsNeutralPropertyKey.DependencyProperty;

        public bool IsNeutral
        {
            get { return (bool)GetValue(IsNeutralProperty); }
            private set { SetValue(IsNeutralPropertyKey, value); }
        }

        private void GotoVisualState(bool useTransitions, ListSortDirection? direction)
        {
            var stateName = direction.HasValue
                ? (direction.Value == System.ComponentModel.ListSortDirection.Ascending
                    ? AscendingStateName
                    : DescendingStateName)
                : NoneStateName;

            VisualStateManager.GoToState(this, stateName, useTransitions);
        }
    }
}

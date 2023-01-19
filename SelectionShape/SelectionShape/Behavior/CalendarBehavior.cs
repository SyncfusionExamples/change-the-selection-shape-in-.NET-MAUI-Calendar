using Syncfusion.Maui.Calendar;

namespace SelectionShape
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar calendar;
        private Button selectionShapeButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.FindByName<SfCalendar>("calendar");
            this.selectionShapeButton = bindable.FindByName<Button>("selectionShapeButton");
            this.selectionShapeButton.Text = "SelectionShape: " + this.calendar.SelectionShape.ToString();
            this.selectionShapeButton.Clicked += SelectionShapeButton_Clicked;
        }

        private void SelectionShapeButton_Clicked(object sender, EventArgs e)
        {
            if (this.calendar.SelectionShape == CalendarSelectionShape.Circle)
            {
                this.calendar.SelectionShape = CalendarSelectionShape.Rectangle;
                this.selectionShapeButton.Text = "SelectionShape: " + this.calendar.SelectionShape.ToString();
            }
            else
            {
                this.calendar.SelectionShape = CalendarSelectionShape.Circle;
                this.selectionShapeButton.Text = "SelectionShape: " + this.calendar.SelectionShape.ToString();
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.selectionShapeButton != null)
            {
                this.selectionShapeButton.Clicked -= SelectionShapeButton_Clicked;
            }

            this.selectionShapeButton = null;
            this.calendar = null;
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using Microsoft.Workflow.Samples.Administration;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    public class DataGridViewExplore : DataGridView
    {
        public event KeyEventHandler EnterKeyDown;

        public DataGridViewExplore()
        {
            this.MultiSelect = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Rows.CollectionChanged += new CollectionChangeEventHandler(Rows_CollectionChanged);
            this.DataError += new DataGridViewDataErrorEventHandler(DataGridViewExplore_DataError);
        }

        void DataGridViewExplore_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action != CollectionChangeAction.Remove)
            {
                foreach (DataGridViewRow row in this.Rows)
                {
                    TwoLineCell cell = row.Cells[0] as TwoLineCell;
                    if (cell != null)
                        cell.ForceDataBinding(row.Index);
                }
            }
        }

        private ImageList stateImageList = null;
        public ImageList StateImageList
        {
            get { return this.stateImageList; }
            set { this.stateImageList = value; }
        }

        protected override void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
        {
            e.Height = 32;
            e.MinimumHeight = 30;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Columns.Count > 0)
            {
                int width = this.ClientSize.Width;
                TwoLineColumn column = this.Columns[0] as TwoLineColumn;
                column.MinimumWidth = width;
                column.Width = width;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            // DataGridView doesn't automatically select on rt-click
            bool selectionChanged = false;
            DataGridView.HitTestInfo hti = this.HitTest(e.X, e.Y);
            if (hti.Type == DataGridViewHitTestType.Cell && MouseButtons.Right == e.Button && 1 == e.Clicks)
            {
                if (0 != this.Rows[hti.RowIndex].Cells.Count && !this.Rows[hti.RowIndex].Cells[0].Selected)
                {
                    for (int rowIndex = 0, maxRowIndex = this.Rows.Count; rowIndex < maxRowIndex; rowIndex++)
                    {
                        bool rowAlreadySelected = this.Rows[rowIndex].Selected;
                        bool rowShouldBeSelected = (rowIndex == hti.RowIndex);
                        selectionChanged |= (rowAlreadySelected != rowShouldBeSelected);
                        SetSelectedRowCore(rowIndex, rowShouldBeSelected);
                    }
                    this.CurrentCell = this.Rows[hti.RowIndex].Cells[hti.ColumnIndex];
                }
            }

            if (selectionChanged)
            {
                OnSelectionChanged(EventArgs.Empty);
            }
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                //dont let the grid view handle the enter key - it will move to the next row
                //fire custom event instead
                if (EnterKeyDown != null)
                    EnterKeyDown(this, e);
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }

    public class TwoLineColumn : DataGridViewColumn
    {
        public TwoLineColumn()
            : base(new TwoLineCell())
        {
        }

        public override object Clone()
        {
            TwoLineColumn col = base.Clone() as TwoLineColumn;
            return col;
        }

        public Font RegularFont
        {
            get { return this.DataGridView.Font; }
        }

        private Font boldFont = null;
        public Font BoldFont
        {
            get
            {
                if (this.boldFont == null)
                    this.boldFont = new Font(this.RegularFont, FontStyle.Bold);

                return this.boldFont;
            }
        }
    }

    public class TwoLineCell : DataGridViewCell
    {
        private TwoLineGridRowItem item = null;

        private Rectangle bounds = Rectangle.Empty;
        private Rectangle bitmapRect = Rectangle.Empty;
        private Rectangle firstLineRect = Rectangle.Empty;
        private Rectangle secondLineRect = Rectangle.Empty;
        private Rectangle dateLineRect = Rectangle.Empty;
        private int verticalOffset;
        private int defaultHeight = 32;

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return value;
        }

        public void ForceDataBinding(int rowIndex)
        {
            if (this.item == null)
            {
                DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                try
                {
                    TwoLineGridRowItem twoLineGridRowItem = row.DataBoundItem as TwoLineGridRowItem;
                    this.item = twoLineGridRowItem;
                }
                catch
                {
                    //ignore potential bound element unavailable items - this is coming from list changed event...
                }
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            bool isSelected = (cellState & DataGridViewElementStates.Selected) != 0;

            if (this.Bounds != cellBounds || this.IsSelected != isSelected)
            {
                this.Bounds = cellBounds;
                this.IsSelected = isSelected;
                this.OnLayout(graphics);
            }

            this.Draw(graphics, clipBounds);

            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
        }

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }
        public bool IsSelected
        {
            get { return this.item.Selected; }
            set { this.item.Selected = value; }
        }

        public void Draw(Graphics graphics, Rectangle clipBounds)
        {
            string firstLine = this.item.FirstLineTitle;
            string secondLine = this.item.SecondLineTitle;
            string dateLine = this.FormatDateCreated(this.item.DateCreated);

            TwoLineColumn column = this.DataGridView.Columns[this.ColumnIndex] as TwoLineColumn;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Brush basckground = !this.item.Selected ? SystemBrushes.Window : SystemBrushes.Highlight;
            Brush text = !this.item.Selected ? SystemBrushes.WindowText : SystemBrushes.HighlightText;

            graphics.FillRectangle(basckground, Bounds);

            if (!string.IsNullOrEmpty(this.item.ImageName))
            {
                Bitmap bitmap = ((DataGridViewExplore)this.DataGridView).StateImageList.Images[this.item.ImageName] as Bitmap;
                if (bitmap != null)
                {
                    bitmap.MakeTransparent(bitmap.GetPixel(0, 0));
                    graphics.DrawImage(bitmap, this.bitmapRect.Location);
                }
            }

            TextRenderingHint oldTextHint = graphics.TextRenderingHint;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            graphics.DrawString(firstLine, column.BoldFont, text, this.firstLineRect, format);
            graphics.DrawString(secondLine, column.RegularFont, text, this.secondLineRect, format);
            graphics.DrawString(dateLine, column.BoldFont, text, this.dateLineRect, format);

            graphics.TextRenderingHint = oldTextHint;
        }

        public void OnLayout(Graphics g)
        {
            string firstLine = this.item.FirstLineTitle;
            string secondLine = this.item.SecondLineTitle;
            string dateLine = FormatDateCreated(this.item.DateCreated);

            Rectangle currentRect = this.Bounds;//new Rectangle(0, 0, this.Width, this.Height);

            Size bitmapSize = new Size(16 + 3 + 3, 16 + 3 + 3);
            this.bitmapRect = new Rectangle(new Point(currentRect.X + 3, currentRect.Y + 3), new Size(16, 16));

            TwoLineColumn column = this.DataGridView.Columns[this.ColumnIndex] as TwoLineColumn;
            Size firstLineSize = Size.Ceiling(g.MeasureString(firstLine, column.BoldFont));
            Size secondLineSize = Size.Ceiling(g.MeasureString(secondLine, column.RegularFont));
            Size dateLineSize = Size.Ceiling(g.MeasureString(dateLine, column.BoldFont));
            dateLineSize.Width += 3;//to overcome issue with the "1/14" date format being clipped

            //the bitmap will take some space in the left-most column
            int width = this.Bounds.Width - bitmapSize.Width;//this.Width - bitmapSize.Width;

            //we will be updating the height only, the width will be used as it was set
            int Height = this.defaultHeight;
            //to center the content
            this.verticalOffset = (this.defaultHeight - (firstLineSize.Height + secondLineSize.Height)) / 2;

            secondLineSize.Width = Math.Min(secondLineSize.Width, width);
            if (firstLineSize.Width + dateLineSize.Width > width)
            {
                //datetime is more important until total width is less then the width itself
                if (dateLineSize.Width > width)
                {
                    dateLineSize.Width = width / 2;
                    firstLineSize.Width = width / 2;
                }
                else
                {
                    firstLineSize.Width = width - dateLineSize.Width;
                }
            }

            this.firstLineRect = new Rectangle(new Point(currentRect.X + bitmapSize.Width, currentRect.Y + this.verticalOffset), firstLineSize);
            this.secondLineRect = new Rectangle(new Point(currentRect.X + bitmapSize.Width, currentRect.Y + this.firstLineRect.Height + this.verticalOffset), secondLineSize);
            this.dateLineRect = new Rectangle(new Point(currentRect.X + currentRect.Width - dateLineSize.Width, currentRect.Y + this.verticalOffset), dateLineSize);
        }

        public string FormatDateCreated(DateTime date)
        {
            string returnValue = string.Empty;

            CultureInfo ci = CultureInfo.CurrentCulture;
            string longTimePattern = ci.DateTimeFormat.LongTimePattern.ToString();
            string shortTimePattern = ci.DateTimeFormat.ShortTimePattern.ToString();

            CalendarWeekRule calendarWeekRule = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek dayOfWeek = ci.DateTimeFormat.FirstDayOfWeek;

            Calendar calendar = ci.Calendar;
            int creationDay = calendar.GetDayOfYear(date);
            int creationWeek = calendar.GetWeekOfYear(date, calendarWeekRule, dayOfWeek);
            int creationMonth = calendar.GetMonth(date);
            int creationYear = calendar.GetYear(date);

            DateTime now = DateTime.Now;
            int currentDay = calendar.GetDayOfYear(now);
            int currentWeek = calendar.GetWeekOfYear(now, calendarWeekRule, dayOfWeek);
            int currentMonth = calendar.GetMonth(now);
            int currentYear = calendar.GetYear(now);

            string longTime = date.ToString(longTimePattern);
            string shortTime = date.ToString(shortTimePattern);
            string shortDate = creationMonth + "/" + calendar.GetDayOfMonth(date);
            string longDate = date.ToShortDateString();

            if (currentDay == creationDay && currentYear == creationYear)
            {
                //Today			4:30pm
                returnValue = shortTime;
            }
            else if (currentWeek == creationWeek && currentYear == creationYear)
            {
                //This Week		Mon 5:30am
                DayOfWeek creationDayOfWeek = calendar.GetDayOfWeek(date);
                returnValue = creationDayOfWeek.ToString().Substring(0, 3) + " " + shortTime;
            }
            else if (creationMonth == currentMonth && currentYear == creationYear)
            {
                //This Month	Fri 1/21
                DayOfWeek creationDayOfWeek = calendar.GetDayOfWeek(date);
                returnValue = creationDayOfWeek.ToString().Substring(0, 3) + " " + shortDate;
            }
            else
            {
                //Last Month	1/21/2001
                returnValue = longDate;
            }

            return returnValue;
        }
    }

    public class TwoLineGridRowItem
    {
        // FirstLine											Mon 3:40am
        // Second Line is usually long enough to take a lot of space an...

        private string firstLineTitle = string.Empty;
        private string secondLineTitle = string.Empty;
        private DateTime dateCreated;
        private string imageName;

        private IWorkflowInstance instance = null;
        private bool selected = false;
        private string instanceTypeSuffix;

        private TwoLineGridRowItem(IWorkflowInstance instance, string firstLineTitle, string secondLineTitle, DateTime dateCreated, string instanceTypeSuffix)
        {
            this.instance = instance;
            this.firstLineTitle = firstLineTitle;
            this.secondLineTitle = secondLineTitle;
            this.dateCreated = dateCreated;
            this.instanceTypeSuffix = instanceTypeSuffix;

            if (instance is LiveInstanceProxy)
            {
                LiveInstanceProxy liveInstance = instance as LiveInstanceProxy;
                liveInstance.OnInstanceStateChanged += new EventHandler(liveInstance_OnInstanceStateChanged);
            }

            UpdateItemBitmap(instance.State);
        }

        private void liveInstance_OnInstanceStateChanged(object sender, EventArgs e)
        {
            InstanceStateChangeEventArgs instanceStateChangedEventArgs = e as InstanceStateChangeEventArgs;
            if (instanceStateChangedEventArgs != null)
            {
                UpdateItemBitmap(FromChangeTypeToStatus(instanceStateChangedEventArgs.ChangeType));
            }
            else
            {
                UpdateItemBitmap(instance.State);
            }
        }

        private ActivityExecutionStatus FromChangeTypeToStatus(InstanceStateChangeType changeType)
        {
            switch (changeType)
            {
                case InstanceStateChangeType.Terminated:
                    return ActivityExecutionStatus.Canceling;

                case InstanceStateChangeType.Completed:
                    return ActivityExecutionStatus.Closed;

                case InstanceStateChangeType.Created:
                case InstanceStateChangeType.Resumed:
                case InstanceStateChangeType.Suspended:
                default:
                    return ActivityExecutionStatus.Initialized;
            }
        }

        public static TwoLineGridRowItem CreateTwoLineRowItem(IWorkflowInstance instance, string instanceTypeSuffix)
        {
            TwoLineGridRowItem item = new TwoLineGridRowItem(instance, instance.Type, instance.Title, instance.ActivationTime, instanceTypeSuffix);
            return item;
        }

        private void UpdateItemBitmap(ActivityExecutionStatus status)
        {
            string instanceStatePrefix = "Completed";
            switch (status)
            {
                case ActivityExecutionStatus.Initialized:
                case ActivityExecutionStatus.Compensating:
                case ActivityExecutionStatus.Executing:
                    instanceStatePrefix = "Started";
                    break;

                case ActivityExecutionStatus.Closed:
                    instanceStatePrefix = "Completed";
                    break;

                case ActivityExecutionStatus.Canceling:
                    instanceStatePrefix = "Terminated";
                    break;
            }

            //suspend needs a different approach now
            if (((IWorkflowInstance)instance).Suspended)
                instanceStatePrefix = "Suspended";

            this.imageName = instanceStatePrefix + this.instanceTypeSuffix;
        }

        #region public properties
        public IWorkflowInstance Instance
        {
            get { return this.instance; }
        }

        public string ImageName
        {
            get { return this.imageName; }
        }

        public bool Selected
        {
            get { return this.selected; }
            set
            {
                if (this.selected == value)
                    return;
                this.selected = value;
            }
        }

        public string FirstLineTitle
        {
            get { return this.firstLineTitle; }
            set { this.firstLineTitle = value; }
        }

        public string SecondLineTitle
        {
            get { return this.secondLineTitle; }
            set { this.secondLineTitle = value; }
        }

        public DateTime DateCreated
        {
            get { return this.dateCreated; }
            set { this.dateCreated = value; }
        }
        #endregion
    }
}
namespace EdgeOfTheEmpire.Models
{
    public class RowAndColumn
    {
        public RowAndColumn()
        {
            Row = 1;
            Column = 1;
        }
        public RowAndColumn(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; set; }
        public int Column { get; set; }

        public RowAndColumn Next()
        {
            int newRow;
            int newColumn;
            if (Column ==4)
            {
                newRow = Row + 1;
                newColumn = 1;
            }
            else
            {
                newRow = Row;
                newColumn = Column + 1;
            }

            return new RowAndColumn(newRow, newColumn);
        }

        public override bool Equals(object obj)
        {
            var column = obj as RowAndColumn;
            return column != null &&
                   Row == column.Row &&
                   Column == column.Column;
        }

        public override int GetHashCode()
        {
            var hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }
    }
}

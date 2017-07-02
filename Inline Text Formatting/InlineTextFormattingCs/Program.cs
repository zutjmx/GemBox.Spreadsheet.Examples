using GemBox.Spreadsheet;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

        ExcelFile ef = new ExcelFile();
        ExcelWorksheet ws = ef.Worksheets.Add("Inline Text Formatting");

        ws.Cells[0, 0].Value = "Inline text formatting examples:";
        ws.PrintOptions.PrintGridlines = true;

        // Column width of 20 characters.
        ws.Columns[0].Width = 20 * 256;

        ws.Cells[2, 0].Value = "This is big and red text!";

        // Apply size to 'big and red' part of text
        ws.Cells[2, 0].GetCharacters(8, 11).Font.Size = 400;

        // Apply color to 'red' part of text
        ws.Cells[2, 0].GetCharacters(16, 3).Font.Color = SpreadsheetColor.FromName(ColorName.Red);

        // Format cell content
        ws.Cells[4, 0].Value = "Formatting selected characters with GemBox.Spreadsheet component.";
        ws.Cells[4, 0].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
        ws.Cells[4, 0].Style.Font.Italic = true;
        ws.Cells[4, 0].Style.WrapText = true;

        // Get characters from index 36 to the end of string
        FormattedCharacterRange characters = ws.Cells[4, 0].GetCharacters(36);

        // Apply color and underline to selected characters
        characters.Font.Color = SpreadsheetColor.FromName(ColorName.Orange);
        characters.Font.UnderlineStyle = UnderlineStyle.Single;

        // Write selected characters
        ws.Cells[6, 0].Value = "Selected characters: " + characters.Text;

        ef.Save("Inline Text Formatting.xlsx");
    }
}

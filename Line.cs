public class Line : Shape
{
    public string? x1, y1, x2, y2;
    public string? lineStroke, lineStrokeWidth;

    public Line(string? x1, string? y1, string? x2, string? y2, string? lineStroke, string? lineStrokeWidth)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.lineStroke = lineStroke;
        this.lineStrokeWidth = lineStrokeWidth;
    }

    public override string ToString()
    {
        string lineSVG = String.Format(@"<line x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" style=""stroke:{4};stroke-width:{5}"" />", this.x1, this.y1, this.x2, this.y2, this.lineStroke, this.lineStrokeWidth);
        return lineSVG;
    }
}
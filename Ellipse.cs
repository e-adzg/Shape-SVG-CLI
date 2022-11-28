public class Ellipse : Shape   //the rest of these classes have the same layout as rectangle, just unique to their own shape
{
    public string? ex, ey, er1, er2;
    public string? ellipseFill, ellipseStroke, ellipseStrokeWidth;

    public Ellipse(string? ex, string? ey, string? er1, string? er2, string? ellipseFill, string? ellipseStroke, string? ellipseStrokeWidth)
    {
        this.ex = ex;
        this.ey = ey;
        this.er1 = er1;
        this.er2 = er2;
        this.ellipseFill = ellipseFill;
        this.ellipseStroke = ellipseStroke;
        this.ellipseStrokeWidth = ellipseStrokeWidth;
    }

    public override string ToString()
    {
        string ellipseSVG = String.Format(@"<ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" style=""fill:{4};stroke:{5};stroke-width:{6}"" />", this.ex, this.ey, this.er1, this.er2, this.ellipseFill, this.ellipseStroke, this.ellipseStrokeWidth);
        return ellipseSVG;
    }
}
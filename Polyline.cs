public class Polyline : Shape
{
    public string? points, polylineFill, polylineStroke, polylineStrokeWidth;

    public Polyline(string? points, string? polylineFill, string? polylineStroke, string? polylineStrokeWidth)
    {
        this.points = points;
        this.polylineFill = polylineFill;
        this.polylineStroke = polylineStroke;
        this.polylineStrokeWidth = polylineStrokeWidth;
    }

    public override string ToString()
    {
        string polylineSVG = String.Format(@"<polyline points=""{0}"" style=""fill:{1};stroke:{2};stroke-width:{3}"" />", this.points, this.polylineFill, this.polylineStroke, this.polylineStrokeWidth);
        return polylineSVG;
    }
}
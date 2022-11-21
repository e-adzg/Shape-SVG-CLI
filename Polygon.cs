class Polygon : Shape
{
    public string? GonPoints, polygonFill, polygonStroke, polygonStrokeWidth;

    public Polygon(string? GonPoints, string? polygonFill, string? polygonStroke, string? polygonStrokeWidth)
    {
        this.GonPoints = GonPoints;
        this.polygonFill = polygonFill;
        this.polygonStroke = polygonStroke;
        this.polygonStrokeWidth = polygonStrokeWidth;
    }

    public override string ToString()
    {
        string polygonSVG = String.Format(@"<polygon points=""{0}"" style=""fill: {1}; stroke: {2}; stroke-width:{3}"" />", this.GonPoints, this.polygonFill, this.polygonStroke, this.polygonStrokeWidth);
        return polygonSVG;
    }
}
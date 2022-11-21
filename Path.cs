class Path : Shape
{
    public string? path, pathStroke, pathStrokeWidth, pathStrokeFill;

    public Path(string? path, string? pathStroke, string? pathStrokeWidth, string? pathStrokeFill)
    {
        this.path = path;
        this.pathStroke = pathStroke;
        this.pathStrokeWidth = pathStrokeWidth;
        this.pathStrokeFill = pathStrokeFill;
    }

    public override string ToString()
    {
        string pathSVG = String.Format(@"<path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}"" />", this.path, this.pathStroke, this.pathStrokeWidth, this.pathStrokeFill);
        return pathSVG;
    }
}
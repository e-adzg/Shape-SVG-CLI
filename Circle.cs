class Circle : Shape
{
    public string? cr, cx, cy;
    public string? circleStroke, circleStrokeWidth, circleFill;

    public Circle(string? cr, string? cx, string? cy, string? circleStroke, string? circleStrokeWidth, string? circleFill)
    {
        this.cr = cr;
        this.cx = cx;
        this.cy = cy;
        this.circleStroke = circleStroke;
        this.circleStrokeWidth = circleStrokeWidth;
        this.circleFill = circleFill;
    }

    public override string ToString()
    {
        string circleSVG = String.Format(@"<circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""{3}"" stroke-width=""{4}"" fill=""{5}"" />", this.cx, this.cy, this.cr, this.circleStroke, this.circleStrokeWidth, this.circleFill);
        return circleSVG;
    }
}
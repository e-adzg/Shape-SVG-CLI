public abstract class Shape //this class holds all of the classes and overrides for all shapes
{
    public override string ToString()
    {
        return "No Shapes :(";
    }
}

public class Rectangle : Shape
{
    public string? rx, ry, rH, rW;
    public string? recFill, recStroke, recStrokeWidth, recFillOpacity, recStrokeOpacity;

    public Rectangle(string? rx, string? ry, string? rH, string? rW, string? recFill, string? recStroke, string? recStrokeWidth, string? recFillOpacity, string? recStrokeOpacity)
    {
        this.rx = rx;
        this.ry = ry;
        this.rH = rH;
        this.rW = rW;
        this.recFill = recFill;
        this.recStroke = recStroke;
        this.recStrokeWidth = recStrokeWidth;
        this.recFillOpacity = recFillOpacity;
        this.recStrokeOpacity = recStrokeOpacity;
    }

    public override string ToString()
    {
        string rectangleSVG = String.Format(@"<rect x=""{0}"" y=""{1}"" width=""{2}"" height=""{3}"" style=""fill:{4};stroke:{5};stroke-width:{6};fill-opacity:{7};stroke-opacity:{8}"" />", this.rx, this.ry, this.rW, this.rH, this.recFill, this.recStroke, this.recStrokeWidth, this.recFillOpacity, this.recStrokeOpacity);
        return rectangleSVG;
    }
}
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
public class Polygon : Shape
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
public class Path : Shape
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
public class Ellipse : Shape
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
public class Circle : Shape
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
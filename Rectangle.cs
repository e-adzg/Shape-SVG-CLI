class Rectangle : Shape     //RECTANGLE EXTENDS SHAPE
{
    public string? rx, ry, rH, rW;   //these are all variables that rectangle will use
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

    public override string ToString() //this will overide the ToString whenever the rectangle class needs to use it.
    {
        string rectangleSVG = String.Format(@"<rect x=""{0}"" y=""{1}"" width=""{2}"" height=""{3}"" style=""fill:{4};stroke:{5};stroke-width:{6};fill-opacity:{7};stroke-opacity:{8}"" />", this.rx, this.ry, this.rW, this.rH, this.recFill, this.recStroke, this.recStrokeWidth, this.recFillOpacity, this.recStrokeOpacity);
        return rectangleSVG;
    }
}
namespace RoutePlanning.Domain;

public class Dimensions
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }

    public Dimensions(double weight, double height, double width, double length)
    {
        Weight = weight;
        Height = height;
        Width = width;
        Length = length;
    }
}

namespace RoutePlanning.Domain;

public class Dimensions
{
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }

    public Dimensions(int weight, int height, int width, int length)
    {
        Weight = weight;
        Height = height;
        Width = width;
        Length = length;
    }
}

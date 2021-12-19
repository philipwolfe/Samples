// shapetest.cs
// compile with: /reference:abstractshape.dll;shapes.dll
public class TestClass
{
   public static void Main()
   {
      Shape[] shapes =
         {
            new Square(5, "Square #1"),
            new Circle(3, "Circle #1"),
            new Rectangle( 4, 5, "Rectangle #1")
         };
      
      System.Console.WriteLine("Shapes Collection");
      foreach(Shape s in shapes)
      {
         System.Console.WriteLine(s);
      }
         
   }
}

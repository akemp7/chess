using System;

class Program
{
  static void Main()
  {
    bool repeat = true; 
    Queen queen = new Queen();
    while(repeat){
        Console.WriteLine("Enter coordinates for the Queen");
        Console.WriteLine("X coordinate");
        string queenXString = Console.ReadLine();
        Console.WriteLine("Y coordinate");
        string queenYString = Console.ReadLine();
        int queenX = -1;
        int queenY = -1;
        try{
            queenX = int.Parse(queenXString);
            queenY = int.Parse(queenYString);

        } catch (FormatException){
            Console.WriteLine("Values are not whole numbers. Please try again.");
        }
        if(!(queenX >= 0 || queenY >= 0) || (queenX > 8 && queenY > 8)){
            Console.WriteLine("Values are not inside the chess board boundaries [0-7]. Please try again.");
        } else {
            queen.x = queenX;
            queen.y = queenY;
            repeat = false;
        }
    }

    repeat = true; 
    int otherX = -1;
    int otherY = -1;
    while(repeat){
        Console.WriteLine("Where is the other piece?");
        Console.WriteLine("X coordinate");
        string otherXString = Console.ReadLine();
        Console.WriteLine("Y coordinate");
        string otherYString = Console.ReadLine();
        
        try{
            otherX = int.Parse(otherXString);
            otherY = int.Parse(otherYString);

        } catch (FormatException){
            Console.WriteLine("Values are not whole numbers. Please try again.");
        }
        if(!(otherX >= 0 || otherY >= 0) || (otherX > 8 && otherY > 8)){
            Console.WriteLine("Values are not inside the chess board boundaries [0-7]. Please try again.");
        } else {
            repeat = false;
        }
    }
    if(queen.Attack(otherX, otherY)){
        Console.WriteLine("Attack successful!");
    } else{
        Console.WriteLine("She missed!");
    }
  }
}
class Queen{
    public int x;
    public int y;
    public bool Attack(int spaceX, int spaceY){
        bool attSuccessful = false;
        if(x == spaceX || y == spaceY){
            attSuccessful = true;
        } else {
            int posSlopeB = y-x;
            int negSlopeB = y+x;

            if((spaceY == spaceX + posSlopeB) || (spaceY == -spaceX + negSlopeB)){
                attSuccessful = true;
            }
        }
        return attSuccessful;
    }
}

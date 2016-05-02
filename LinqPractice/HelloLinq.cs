using System;
using System.Linq; //extension method for array that allows Where and Select

namespace LinqPractice {

  public class HelloLinq {

    public HelloLinq () {

      // numbers
      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};
      var result = 
        from n in numbers
        where n < 5      
        select n;

      // Less sugar - Using Linq extension to Arrays
      var resultLessSugar = 
        numbers
          .Where(n => n < 5)
          .Select(n => n);

      // No sugar - Using Enumerable
      var noSugar =
        Enumerable.Select(
          Enumerable.Where(numbers, n => n < 5), 
          n => n
        );

      foreach(int i in result){
        Console.WriteLine("HelloLinq : {0}", i);
      }

      foreach(int i in resultLessSugar){
        Console.WriteLine("Linq Less Sugar : {0}", i);
      }

      foreach (int i in noSugar) {
        Console.WriteLine("No Sugar : {0}", i);
      }

      // characters
      char[] chars = new[]{'c', 'p', 'o', 'm', 'i', 'k', 'e', 't', 'o', 'n'};
      var vowels =
        from letter in chars
        where letter=='a' || letter=='e' || letter=='i' || letter=='o' || letter=='u'
        select letter;

      foreach(char c in vowels){
        Console.WriteLine("Vowels : {0}", c);
      }

    }

  }
}


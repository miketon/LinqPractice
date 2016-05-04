using System;
using System.Linq; //extension method for array that allows Where and Select
using System.Collections.Generic; //needed for IEnumerable

namespace LinqPractice {

  static public class MTON{ 

    // Writing our own Where extension.
    // Function will search this context first before System.Linq
    static public IEnumerable<int> Where(this int[] ints, Func<int, bool> predicate){
      Console.WriteLine("MyWhere : {0}", ints);
      foreach(int i in ints){
        if(predicate(i)){
//          Console.WriteLine("MyWhere : Predicate True {0}", i);
          yield return i;
        }
      }
    }
  }

  public class HelloLinq {

    public HelloLinq () {

      // numbers
      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};
      var result = 
        from n in numbers
        where n < 5  // This is using our local Where...WTH, why doesn't capitlization matter????
        select n;    //degenerate clause, doesn't do anything. compiler deletes it

      foreach(int i in result){
        Console.WriteLine("HelloLinq : {0}", i);
      }

      HelloLinqBreakdown();

    }

    public void HelloLinqBreakdown () {

      // numbers
      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};

      // Less sugar - Using Linq extension to Arrays (which implements IEnumerable)
      var resultLessSugar = 
        numbers
          .Where(n => n < 5);
//          .Select(n => n); //degenerate clause, doesn't do anything. compiler deletes it

      // No sugar - Using Enumerable
      var noSugar =
        Enumerable.Select(
//          Enumerable.Where(numbers, n => n < 5), 
          MTON.Where(numbers, n => n < 5), 
          n => n
        );

      foreach(int i in noSugar){
        Console.WriteLine("No Sugar : {0} with MTON.Where", i);
      }

      foreach(int i in resultLessSugar){
        Console.WriteLine("Linq Less Sugar : {0}", i);
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


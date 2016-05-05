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

//      // numbers
//      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};
//      var result = 
//        from n in numbers
//        where n < 5  // This is using our local Where...WTH, why doesn't capitlization matter????
//        select n;    //degenerate clause, doesn't do anything. compiler deletes it
//
//      foreach(int i in result){
//        Console.WriteLine("HelloLinq : {0}", i);
//      }

//      HelloLinqBreakdown();
      LargerTranslation();

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


    public void LargerTranslation () {

      // numbers
      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};

      var result1 = 
        from n in numbers
        where n < 5 
        where n > 0
        where new Random().Next() == 23
        orderby n
        orderby n * 2 + 3
        orderby 5
        select n;

      // Less Sugar
      var result2 = 
//        from n in numbers
        numbers
          .OrderBy(n => 8)
          .Where(n => n < 5)
          .Where(n => n > 0)
          .Where(n => new Random().Next()==23)
          .OrderBy(n => n)
          .OrderBy(n => n*2+3)
          .OrderBy(n => 5);
//          .Select(n => n); // degenerate, compiler removes

      // No Sugar
      var result3 = 
//        from n in numbers
        Enumerable.OrderBy(
          Enumerable.OrderBy(
            Enumerable.OrderBy(
              Enumerable.Where(
                Enumerable.Where(
                  Enumerable.Where(
                    Enumerable.OrderBy(numbers, n => 8), n => n < 5), n => n > 0), 
                    n => new Random().Next()==23), n => n), n => n*2+3), n => 5);
//          .Select(n => n); // degenerate, compiler removes

      foreach(int i in result1){
        Console.WriteLine("HelloLinq : {0}", i);
      }

      foreach(int i in result2){
        Console.WriteLine("HelloLinq : Less Sugar {0}", i);
      }

      foreach(int i in result3){
        Console.WriteLine("HelloLinq : No Sugar {0}", i);
      }

    }

  }
}


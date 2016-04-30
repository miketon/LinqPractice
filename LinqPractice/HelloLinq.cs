using System;
using System.Linq;

namespace LinqPractice {

  public class HelloLinq {

    public HelloLinq () {

      int[] numbers = new[] { 2, 4, 8, 1, 9, 2, 0, 3, 4, 2};
      var result = 
        from n in numbers
        where n < 5
        select n;

      foreach(int i in result){
        Console.WriteLine("HelloLinq : {0}", i);
      }

    }

  }
}


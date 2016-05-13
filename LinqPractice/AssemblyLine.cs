using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice {
  public class AssemblyLine {
    public AssemblyLine () {
      Console.WriteLine("Assembly Line");
      int[] stuff = {4, 13, 8, 1, 9};
      var result = 
        stuff
        .Where(i => i < 10)
        .Where(i => 4 < i)
        .Select(i => i * 3)
        .Where(i => i % 2 == 0)
        .Select(i => i + "Mike");

      IEnumerator<string> rator = result.GetEnumerator();

      while(rator.MoveNext()){
        Console.WriteLine("rator {0}", rator.Current);
      }
    }
  }
}


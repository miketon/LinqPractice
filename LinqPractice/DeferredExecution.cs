using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice {

  static class MTON_DEF{

    public static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gauntlet){
      Console.WriteLine("Where {0}", 1);
      foreach (T item in items){
        if(gauntlet(item)){
          yield return item;
        }
      }
    }

    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform){
      Console.WriteLine("Select {0}", 2);
      foreach(T item in items){
        yield return transform(item);
      }
    }

  }

  public class DeferredExecution {

    public DeferredExecution () {
      Console.WriteLine("Deferring Hello World");
      int[] stuff = {1, 3, 5, 1, 1, 7, 9};
      IEnumerable<int> result = 
        from i in stuff
        where i < 5
        select i + 6; //must use Linq, doesn't work with my static Select??? Why???

      // Less sugar
      IEnumerable<int> result1 = 
//        from i in stuff
        stuff
          .Where(i => i < 5)
          .Select(i => i + 1);

      // No sugar
      IEnumerable<int> result2 =
        MTON_DEF.Select(MTON_DEF.Where(stuff, i => i < 5), 
          i => i + 2);

      IEnumerator<int> rator = result2.GetEnumerator();

      while(rator.MoveNext()){
        Console.WriteLine("rator : {0}", rator.Current);
      }

    }

  }

}


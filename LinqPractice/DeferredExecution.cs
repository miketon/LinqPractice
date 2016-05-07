using System;
using System.Collections.Generic;

namespace LinqPractice {

  public static class MTON_DEF{

    static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gauntlet){
      Console.WriteLine("Where {0}", 1);
      foreach (T item in items){
        if(gauntlet(item)){
          yield return item;
        }
      }
    }

    static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform){
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
        select i;

      IEnumerator<int> rator = result.GetEnumerator();

      while(rator.MoveNext()){
        Console.WriteLine("rator : {0}", rator.Current);
      }

    }

  }

}


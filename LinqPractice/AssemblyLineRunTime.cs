using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice {
  static class AssemblyLineRunTime {

    static Random rand = new Random ();

    static bool RandomBool {
      get {
        return rand.Next () % 2 == 0;
      }
    }

    public static void Init () {
      Console.WriteLine ("Assembly Line Run Time Ready to Go.");
      int[] stuff = { 4, 13, 8, 1, 9 };
      Random(stuff);
    }
    
    public static void Random(int[] stuff){
      IEnumerable<int> result = stuff;
      for (int j = 0; j < 3; j++) {
        if (RandomBool) {
          result = result.Where (i => i < 8);
        }
        if (RandomBool) {
          result = result.Where (i => i > 2);
        }
        if (RandomBool) {
          result = result.Select (i => i * 2);
        }
        if (RandomBool) {
          result = result.Select (i => i + 9);
        }
      }

    }
  }
}


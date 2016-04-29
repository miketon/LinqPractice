using System;

namespace LinqPractice {

  static class MyExtensionHelpers {
    
    public static DateTime Combined(this DateTime datePart, DateTime timePart){
      return new DateTime(
        datePart.Year, datePart.Month, datePart.Day,
        timePart.Hour, timePart.Minute, timePart.Millisecond
      );
    }
  }

  static class MainClass {

    public static void Main () {
      DateTime date = DateTime.Parse("3/24/2025");
      DateTime time = DateTime.Parse("1/1/0001 9:55pm");
      Console.WriteLine ("Hello Date! {0}", date);
      Console.WriteLine ("Hello Time! {0}", time);
      DateTime combined = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
      DateTime combinedFunc = MyExtensionHelpers.Combined(date, time);
      DateTime combinedFuncExtended = date.Combined(time); //sugar
      Console.WriteLine ("Combined date and time! {0}", combined);
      Console.WriteLine ("Combined date and time Function! {0}", combinedFunc);
      Console.WriteLine ("Combined (extension) date wand time Function! {0}", combinedFuncExtended);

      // All Moo() methods point to the same memory space in each cow instance
      // But each instance have their own copy of numMoos, so each instance size == int memory footprint
      Cow c = new Cow();
      c.Moo(); //1
      c.Moo(); //2
      c.Moo(); //3
      Cow c2 = new Cow();
      c2.Moo(); //1
      c2.Moo(); //2
      
      // Extension version of Moo()
      Cow.MooExt(c); //4 - uses the instance numMoos from c and continues the count
      Cow.MooExt(c); //5
      Cow.MooExt(c); //6
    }
  }

  //size of class is int : What it takes to store numMoos
  //Moo is static. All calls to it reference the same space in memory.
  //! Interesting : All methods (including instance methods) are static.
  class Cow{ 
    // instanced tracks this cow
    int numMoos;
    
    // static : All methods are static
    public void Moo(){
      this.numMoos++;
      Console.WriteLine("Moo {0}", this.numMoos);
    }

    // static equivalent to Moo() ; What extensions do under the hood
    public static void MooExt(Cow _this){
      _this.numMoos++;
      Console.WriteLine("Moo {0}", _this.numMoos);
    }

  }

}

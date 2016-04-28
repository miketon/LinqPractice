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
      Console.WriteLine ("Combined (extension) date and time Function! {0}", combinedFuncExtended);
    }
  }
}

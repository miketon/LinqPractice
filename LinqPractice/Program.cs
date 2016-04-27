using System;

namespace LinqPractice {
  class MainClass {
    public static void Main () {
      DateTime date = DateTime.Parse("3/24/2025");
      DateTime time = DateTime.Parse("1/1/0001 9:55pm");
      Console.WriteLine ("Hello Date! {0}", date);
      Console.WriteLine ("Hello Time! {0}", time);
      DateTime combined = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
      Console.WriteLine ("Combined date and time! {0}", combined);
    }
  }
}

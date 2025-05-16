using System;

public class StringWithExclamation {
  protected string _value;

  public StringWithExclamation(string str) {
    _value = str;
  }

  public StringWithExclamation(StringWithExclamation obj) {
    _value = obj._value;
  }

  public void AddExclamations() {
    _value = "!!! " + _value;
  }

  public override string ToString() {
    return $"{_value}";
  }
}

public class ImportantString : StringWithExclamation {
  private int _priority;

  public ImportantString(string str) : base(str) {
    _priority = 0;
  }

  public ImportantString(ImportantString obj) : base(obj) {
    _priority = obj._priority;
  }

  public void RemoveExclamations() {
    _value = _value.TrimStart('!', '!', '!', ' ');
  }

  public void PriorityIncrease() {
    _priority++;
    AddExclamations();
  }

  public void PriorityDecrease() {
    if (_priority == 0) {
      return;
    }
    _priority--;
    RemoveExclamations();
  }

  public override string ToString() {
    return $"{_value} (важность: {_priority})";
  }
}

public class Program {
  public static void Main(string[] args) {
    Console.WriteLine("какая хотите строка:");
    string a = Console.ReadLine();
    var str1 = new StringWithExclamation(a);
    Console.WriteLine($"конструктор по умолчанию - {str1}");

    var str2 = new StringWithExclamation(str1);
    Console.WriteLine($"конструктор копий - {str2}");
    str2.AddExclamations();
    Console.WriteLine($"метод для добавления восклицательных знаков - {str2}");

    Console.WriteLine("какая хотите строка:");
    a = Console.ReadLine();
    var extStr1 = new ImportantString(a);
    Console.WriteLine($"конструктор по умолчанию и метод уменьшения важности - {extStr1}");

    extStr1.PriorityIncrease();
    extStr1.PriorityDecrease();
    Console.WriteLine(extStr1);

    var extStr2 = new ImportantString(extStr1);
    Console.WriteLine($"конструктор копий и метод увеличения важности - {extStr1}");
    extStr2.PriorityIncrease();
    extStr2.PriorityIncrease();
    extStr2.PriorityIncrease();
    Console.WriteLine(extStr2);

    Console.WriteLine("какая хотите строка:");
    a = Console.ReadLine();
    var str3 = new ImportantString(a);
    Console.WriteLine("+/-/exit:");
    a = Console.ReadLine();
    while (a != "exit") {
      if (a == "+") {
        str3.PriorityIncrease();
      }
      if (a == "-") {
        str3.PriorityDecrease();
      }

      Console.WriteLine(str3);

      Console.WriteLine("+/-/exit:");
      a = Console.ReadLine();
    }
  }
}

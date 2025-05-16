using System;

public class Money {
  private uint _rubles;
  private byte _kopeks;

  public Money(uint rubles, byte kopeks) {
    _rubles = rubles + (uint)(kopeks / 100);
    _kopeks = (byte)(kopeks % 100);
  }

  public static Money operator +(Money m1, uint m2) {
    uint totalRubles = m1._rubles + m2 / 100;
    byte totalKopeks = (byte)(m1._kopeks + m2 % 100);
    if (totalKopeks >= 100) {
      totalRubles++;
      totalKopeks -= 100;
    }
    return new Money(totalRubles, totalKopeks);
  }

  public static Money operator +(uint m2, Money m1) {
    return m1 + m2;
  }

  public static Money operator -(uint m2, Money m1) {
    long totalRubles = m2 / 100 - m1._rubles;
    int totalKopeks = m2 % 100 - m1._kopeks;
    if (totalKopeks < 0) {
      totalRubles--;
      totalKopeks += 100;
    }
    if (totalRubles < 0) {
      return new Money(0, 0);
    }
    return new Money((uint)totalRubles, (byte)totalKopeks);
  }

  public static Money operator -(Money m1, uint m2) {
    long totalRubles = m1._rubles - m2 / 100;
    int totalKopeks = m1._kopeks - m2 % 100;
    if (totalKopeks < 0) {
      totalRubles--;
      totalKopeks += 100;
    }
    if (totalRubles < 0) {
      return new Money(0, 0);
    }
    return new Money((uint)totalRubles, (byte)totalKopeks);
  }

  public static explicit operator uint(Money money) {
    return money._rubles;
  }

  public static implicit operator double(Money money) {
    return money._rubles + money._kopeks / 100.0;
  }

  public static Money operator ++(Money m) {
    if (m._kopeks == 99) {
      m._rubles++;
      m._kopeks = 0;
    } else {
      m._kopeks++;
    }
    return m;
  }

  public static Money operator --(Money m) {
    if (m._kopeks == 0) {
      if (m._rubles == 0) {
        return new Money(0, 0);
      }
      m._rubles--;
      m._kopeks = 99;
    } else {
      m._kopeks--;
    }
    return m;
  }

  public override string ToString() {
    return $"{_rubles}.{_kopeks:D2} руб.";
  }
}

public class Program {
  public static void Main(string[] args) {
    try {
      Console.WriteLine("Введите два числа - рубли и копейки:");

      if (!int.TryParse(Console.ReadLine(), out int rubles) || rubles < 0) {
        Console.WriteLine("Некорректный ввод");
        return;
      }

      if (!int.TryParse(Console.ReadLine(), out int kopeks) || kopeks < 0) {
        Console.WriteLine("Некорректный ввод");
        return;
      }

      var money1 = new Money((uint)rubles, (byte)kopeks);

      Console.WriteLine($"Итого - {(uint)money1} рублей {((double)money1):F2} рублей");

      Console.WriteLine($"Плюс копейка - {money1++}");
      Console.WriteLine($"Обратно минус копейка - {money1--}");

      Console.WriteLine("Введите копейки для добавления к текущей сумме:");

      if (!int.TryParse(Console.ReadLine(), out int addKopeks) || addKopeks < 0) {
        Console.WriteLine("Введите неотрицательное число");
        return;
      }

      uint addKopeksUint = (uint)addKopeks;

      Console.WriteLine($"Итого - {money1 + addKopeksUint} = {addKopeksUint + money1}");
      Console.WriteLine("Вычитание того же числа копеек от текущей суммы:");
      Console.WriteLine($"Итого - {money1 - addKopeksUint} или {(uint)(addKopeksUint - money1)} (где-то здесь должен быть ноль, так как это проверка на отрицательные деньги так работает)");
    } catch (FormatException) {
      Console.WriteLine("Некорректный ввод");
    } catch (OverflowException) {
      Console.WriteLine("Слишком большое значение");
    }
  }
}

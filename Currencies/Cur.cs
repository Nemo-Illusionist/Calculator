using System;

namespace Currencies
{
    public struct Cur
    {
        public string CurName;
        public double Count;

        public static Cur operator +(Cur a1, Cur a2)
        {
            Argument(a1, a2);
            return Oper(a1, a2, (x, y) => x + y);
        }
        public static Cur operator -(Cur a1)
        {
            return new Cur { CurName = a1.CurName, Count = -a1.Count };
        }
        public static Cur operator -(Cur a1, Cur a2)
        {
            Argument(a1, a2);
            return Oper(a1, a2, (x, y) => x - y);
        }
        public static Cur operator *(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x * y);
        }
        public static Cur operator /(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x / y);
        }
        private static Cur Oper(Cur a1, Cur a2, Func<double, double, double> f1)
        {
            if (a1.CurName == a2.CurName || a1.CurName == "NNN" || a2.CurName == "NNN")
            {
                return new Cur { Count = f1(a1.Count, a2.Count), CurName = a1.CurName == "NNN" ? a2.CurName : a1.CurName };
            }
            else
            {
                return new Cur
                {
                    CurName = "USD",
                    Count = f1(a1.Count/CurrenciesAPI.Coefficient(a1.CurName),
                        a2.Count/CurrenciesAPI.Coefficient(a2.CurName))
                };
            }

        }

        private static void Argument(Cur a1, Cur a2)
        {
            if (a1.CurName == "NNN" && a2.CurName != "NNN" || a2.CurName == "NNN" && a1.CurName != "NNN")
                throw new ArgumentException("нельзя произвести \"+/-\" между валютой и числом");
        }


        public Cur(string str)
        {
            CurName = str.Substring(str.Length - 3, 3);
            Count = double.Parse(str.Remove(str.Length - 3, 3));
        }
        public Cur(double d)
        {
            CurName = "NNN";
            Count = d;
        }

        public override string ToString()
        {
            return Count + (CurName == "NNN" ? "" : CurName.ToUpper());
        }

        public void Convert(string newCur)
        {
            Count = Count / CurrenciesAPI.Coefficient(CurName) *
            (newCur == "USD" ? 1 : CurrenciesAPI.Coefficient(newCur));
            CurName = newCur;
        }
    }
}
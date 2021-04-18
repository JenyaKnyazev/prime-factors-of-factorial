using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial_to_primes
{
    class Program
    {
        static string fact_to_prime(int n) {
            string res = "";
            List<int> amount = new List<int> {0};
            List<int> primes = new List<int> {2};
            int p = 3;
            while (p <= n) {
                primes.Add(p);
                amount.Add(0);
                p = next_prime(p);
            }
            for (int i = 2; i <= n; i++) {
                int t = i;
                int index=0;
                while (t > 1) {
                    while (t % primes[index] == 0) {
                        t /= primes[index];
                        amount[index]++;
                    }
                    index++;
                }
            }
            for (int i = 0; i < primes.Count; i++) {
                if (amount[i] > 0){
                    if (res.Length > 0){
                        res += " * ";
                    }
                    res += primes[i] + "";
                    if (amount[i] > 1) {
                        res += "^";
                        res += amount[i] + "";
                    }
                }
            }
                return res;
        }
        static int next_prime(int n) {
            n++;
            int div = 2;
            while (n / 2 >= div) {
                if (n % div == 0) {
                    div = 1;
                    n++;
                }
                div++;
            }
            return n;
        }
        static string fact(int n) {
            if (n > 2){
                string t = fact(n - 1);
                return t+"*" + n;
            }else {
                return n + "";
            }

        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter number");
            n=int.Parse(Console.ReadLine());
            Console.WriteLine("Factorial (" + n + ") = " + fact(n));
            Console.WriteLine("Prime Factors = " + fact_to_prime(n));
            Console.ReadLine();
        }
    }
}

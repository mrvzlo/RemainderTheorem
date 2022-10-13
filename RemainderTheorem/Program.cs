using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var file = File.ReadAllLines("ieeja.txt");
var count = int.Parse(file[0]);
var divisors = new List<int>();
var remainders = new List<int>();
for (var i = 0; i < count; i++)
{
    divisors.Add(int.Parse(file[i + 1]));
    remainders.Add(int.Parse(file[i + 1 + count]));
}

var max = divisors.Aggregate(1, (a, b) => a * b);
if (max == 0)
{
    Console.WriteLine("Invalid data");
    return;
}

var parts = new List<long>();
for (var i = 0; i < count; i++)
{
    var primal = max / divisors[i];
    var reverse = GetReverse(primal, divisors[i]);
    parts.Add(remainders[i] * reverse * primal % max);
}

var sum = parts.Sum() % max;
if (sum < 0) sum += max;
Console.WriteLine("Answer is " + sum);
Console.ReadLine();

long GetReverse(long a, long b)
{
    long s = 0;
    long u = 1;

    while (b != 0)
    {
        var quotient = a / b;
        var temp = b;
        b = a % b;
        a = temp;

        temp = s;
        s = u - quotient * s;
        u = temp;
    }

    return u;
}
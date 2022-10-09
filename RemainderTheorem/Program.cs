var file = File.ReadAllLines("ieeja.txt");
var count = int.Parse(file[0]);
var divisors = file[1].Split(';').Select(int.Parse).ToList();
var remainders = file[2].Split(';').Select(int.Parse).ToList();
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
    var uv = EuclideanAlgo(primal, divisors[i]);
    var reverse = uv.Item1;
    parts.Add(remainders[i] * reverse * primal % max);
}

var sum = parts.Sum() % max;
if (sum < 0) sum += max;
Console.WriteLine("Answer is " + sum);

long t1 = 19;
long t2 = 7;
var uv2 = EuclideanAlgo(t1, t2);
Console.WriteLine("EuclideanAlgo is " + uv2);
Console.WriteLine("EuclideanAlgo is " + (t1 * uv2.Item1 + t2 * uv2.Item2));
Console.ReadLine();

(long, long) EuclideanAlgo(long a, long b)
{
    long u = 1;
    long v = 1;
    while (b > 0)
    {
        var temp = u;
        u = v;
        v = temp - (a / b) * v;
        temp = a;
        a = b;
        b = temp % b;
    }

    return (u, v);
}
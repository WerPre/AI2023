// See https://aka.ms/new-console-template for more information


double NextDob(double min, double max)
{
    Random random = new Random();
    double val = (random.NextDouble() * (max - min) + min);
    return (double)val;
}

double P(double fs, double fs_next, double T, double min, double max)
{
    double delta = fs_next - fs;
    if (delta < 0) return 1;
    else return (double)Math.Exp(-delta / T);
}

double randomFromArea(double s, double delta, double min, double max)
{
    double result = NextDob(s - delta, s + delta);
    if (result < min) return min;
    if (result > max) return max;
    return result;
}

double SA(Func<double, double> f, double a, double b, double s0)
{
    double s_best = s0;
    double T = 100;
    double Tmin = 0.001;
    double s_next;
    double cooling = 0.96;
    Random random= new Random();

    while (T > Tmin)
    {
        for (int i = 0; i <= 100; i++)
        {
            s_next = randomFromArea(s_best, Math.Abs(a - b)/3, a, b);
            double chance = P(f(s_best), f(s_next), T, a, b);
            if (chance == 1 || chance > random.NextDouble()) s_best = s_next;
        }
        T *= cooling;
    }

    return s_best;
}


double f(double s)
{
    return s * s;
}

double result = SA(f, -10, 10, 10);
Console.WriteLine("Result: " + result);


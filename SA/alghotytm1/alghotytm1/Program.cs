// See https://aka.ms/new-console-template for more information


float NextFloat(float min, float max)
{
    Random random = new Random();
    double val = (random.NextDouble() * (max - min) + min);
    return (float)val;
}

float P(float fs, float fs_next, float T, float min, float max)
{
    double delta = fs_next - fs;
    if (delta <= 0) return 1;
    else return (float)Math.Exp(-delta / T);
}

float randomFromArea(float s, float delta, float min, float max)
{
    float result = NextFloat(s - delta, s + delta);
    if (result < min) return min;
    if (result > max) return max;
    return result;
}

float SA(Func<float, float> f, float a, float b, float s0)
{
    float s_best = s0;
    float s_current = s0;
    float T = 1000;
    float Tmin = 0.0001f;
    float s_next;
    float cooling = 0.6f;
    Random random= new Random();

    while (T > Tmin)
    {
        for (int i = 0; i < 100; i++)
        {
            s_next = randomFromArea(s_current, Math.Abs(a - b)/3, a, b);
            float chance = P(f(s_current), f(s_next), T, a, b);
            if (chance == 1 || chance > random.NextDouble()) s_best = s_next;
        }
        T *= cooling;
    }

    return s_best;
}


float f(float s)
{
    return s * s;
}

float result = SA(f, -10, 10, 6);
Console.WriteLine("Result: " + result);


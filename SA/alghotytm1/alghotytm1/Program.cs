// See https://aka.ms/new-console-template for more information

float P(float fs, float fs_next, float T)
{
    double delta = fs_next - fs;
    if (delta <= 0) return 1;
    else return (float)Math.Exp(delta/T);
}
float SA(Func<float> f,float[] S, float s0, bool end_criterion)
{
    float best_s = s0;
    float s_i = s0;
    int i = 0;
    float T0 = 1;
    float s_next = 0;

    while (end_criterion)
    {
        
    }

    return best_s;
} 

Console.WriteLine("Hello, World!");

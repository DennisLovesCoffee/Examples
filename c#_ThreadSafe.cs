//Example 1, using a lock
public class MySingleton
{
    private double[] probeCurrentSeries;
    private object m_lock;

    public void Update(double[] series)
    {
        lock (m_lock)
        {
            probeCurrentSeries = new double[series.Length];

            int n = 0;
            while (n < series.Length)
            {
                probeCurrentSeries[n] = Math.Max(series[n++], 1e-8);
            }
        }

        Refresh();
    }

    private void Refresh()
    {
        //depending on the operation, lock again
    }
}

//Example 2, using Lazy<T> syntax
public sealed class MySingleton
{
    private static readonly Lazy<MySingleton> lazy = new Lazy<MySingleton>(() => new MySingleton());

    public static MySingleton Instance { get { return lazy.Value; } }

    private MySingleton() {}

    private double[] probeCurrentSeries;

    public void Update(double[] series)
    {
        probeCurrentSeries = new double[series.Length];

        int n = 0;
        while (n < series.Length)
        {
            probeCurrentSeries[n] = Math.Max(series[n++], 1e-8);
        }

        Refresh();
    }

    private void Refresh()
    {
        //someCode
    }
}

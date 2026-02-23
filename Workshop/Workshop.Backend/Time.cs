namespace Workshop.Backend;

public class Time
{
    // Fields
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    // Properties
    public int Hour => _hour;
    public int Minute => _minute;
    public int Second => _second;
    public int Millisecond => _millisecond;

    // 1) Sin parámetros
    public Time() : this(0, 0, 0, 0)
    {
    }

    // 2) Solo hora
    public Time(int hour) : this(hour, 0, 0, 0)
    {
    }

    // 3) Hora y minuto
    public Time(int hour, int minute) : this(hour, minute, 0, 0)
    {
    }

    // 4) Hora, minuto y segundo
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0)
    {
    }

    // 5) Constructor completo
    public Time(int hour, int minute, int second, int millisecond)
    {
        if (!ValidHour(hour))
            throw new Exception($"The hour: {hour}, is not valid.");

        if (!ValidMinute(minute))
            throw new Exception($"The minute: {minute}, is not valid.");

        if (!ValidSecond(second))
            throw new Exception($"The second: {second}, is not valid.");

        if (!ValidMillisecond(millisecond))
            throw new Exception($"The millisecond: {millisecond}, is not valid.");

        _hour = hour;
        _minute = minute;
        _second = second;
        _millisecond = millisecond;
    }

    // Métodos de validación 
    private bool ValidHour(int hour)
    {
        return hour >= 0 && hour <= 23;
    }

    private bool ValidMinute(int minute)
    {
        return minute >= 0 && minute <= 59;
    }

    private bool ValidSecond(int second)
    {
        return second >= 0 && second <= 59;
    }

    private bool ValidMillisecond(int millisecond)
    {
        return millisecond >= 0 && millisecond <= 999;
    }

    // ToMilliseconds
    public long ToMilliseconds()
    {
        return _hour * 3600000L
             + _minute * 60000L
             + _second * 1000L
             + _millisecond;
    }

    // ToSeconds
    public long ToSeconds()
    {
        return ToMilliseconds() / 1000;
    }

    // ToMinutes
    public long ToMinutes()
    {
        return ToSeconds() / 60;
    }

    // Add
    public Time Add(Time other)
    {
        int ms = _millisecond + other._millisecond;
        int s = _second + other._second;
        int m = _minute + other._minute;
        int h = _hour + other._hour;

        if (ms >= 1000)
        {
            s += ms / 1000;
            ms %= 1000;
        }

        if (s >= 60)
        {
            m += s / 60;
            s %= 60;
        }

        if (m >= 60)
        {
            h += m / 60;
            m %= 60;
        }

        h %= 24;

        return new Time(h, m, s, ms);
    }

    // IsOtherDay
    public bool IsOtherDay(Time other)
    {
        int ms = _millisecond + other._millisecond;
        int s = _second + other._second;
        int m = _minute + other._minute;
        int h = _hour + other._hour;

        if (ms >= 1000)
            s += ms / 1000;

        if (s >= 60)
            m += s / 60;

        if (m >= 60)
            h += m / 60;

        return h >= 24;
    }

    // Formato NO militar 
    public override string ToString()
    {
        int displayHour = _hour % 12;
        if (displayHour == 0)
            displayHour = 12;

        string tt = _hour < 12 ? "AM" : "PM";

        return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {tt}";
    }
}
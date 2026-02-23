namespace Workshop.Backend;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;
    //utilizo atributos privados

    //Constructor sin parámetros
    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0; 
    }

    //Constructor que recibe solo la hora
        public Time(int hour) : this(hour, 0, 0, 0)
    {
    }

    //Constructor que recibe hora y minuto
    public Time(int hour, int minute) : this(hour, minute, 0, 0)
    {
    }

    //Constructor que recibe hora, minuto y segundo
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0)
    {
    }

    // Constructor completo
   
    public Time(int hour, int minute, int second, int millisecond)
    {
        // Se realizan las Validación 
        if (hour < 0 || hour > 23)
            throw new Exception($"The hour: {hour}, is not valid.");

        
        if (minute < 0 || minute > 59)
            throw new Exception($"The minute: {minute}, is not valid.");

        if (second < 0 || second > 59)
            throw new Exception($"The second: {second}, is not valid.");

        
        if (millisecond < 0 || millisecond > 999)
            throw new Exception($"The millisecond: {millisecond}, is not valid.");

        _hour = hour;
        _minute = minute;
        _second = second;
        _millisecond = millisecond;
    }

    // Método que convierte la hora completa a milisegundos

    public long ToMilliseconds()
    {
        return _hour * 3600000L
             + _minute * 60000L
             + _second * 1000L
             + _millisecond;
    }


    public long ToSeconds()
    {
        return ToMilliseconds() / 1000;
    }

    public long ToMinutes()
    {
        return ToSeconds() / 60;
    }

    
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

    // Método que verifica si al sumar dos horas
    // se pasa al día siguiente
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

    // Formato: HH:MM:SS.mmm AM/PM
    public override string ToString()
    {
        int displayHour = _hour;

        if (_hour > 12)
            displayHour = _hour - 12;

        string tt = _hour < 12 ? "AM" : "PM";

        return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {tt}";
    }
}

   



ArrayList<int[]> data = new ArrayList<int>();

public class ArrayList<T>
{
    private T[] _array;
    private int _TrueLength
    {
        get
        {
            return _array.Length;
        }
    }
    public int Length { get; private set; }
    public ArrayList()
    {
        _array = new T[9];
        Length = 0;
    }
    public ArrayList(T a)
    {
        _array = new T[9];
        _array[0] = a;
        Length = 1;
    }
    public ArrayList(int[] array)
    {
        _array = new T[(int)(array.Length * 1.33)];
        Array.Copy(array, _array, array.Length);
        Length = array.Length;
    }

    public T this[int index]
    {
        get
        {
            if (index > Length - 1)
            {
                throw new Exception();
            }
            return _array[index];
        }
        set
        {
            if (index > Length - 1)
            {
                throw new Exception();
            }
            _array[index] = value;
        }
    }

    public void Add(T number)
    {
        if (Length >= _TrueLength)
        {
            IncreaseLenght();
        }
        _array[Length] = number;
        Length++;
    }

    public void Add(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (Length >= _TrueLength)
            {
                IncreaseLenght(1);
            }
            _array[Length] = array[i];
            Length++;
        }
    }

    public void AddByIndex(int index, T value)
    {
        if (index < 0)
        {
            throw new Exception();
        }
        Length++;
        if (Length >= _TrueLength)
        {
            IncreaseLenght();
        }
        T tmp1 = _array[index];
        T tmp2;
        _array[index] = value;
        for (int i = index; i < Length; i++)
        {
            tmp2 = _array[i + 1];
            _array[i + 1] = tmp1;
            tmp1 = tmp2;
        }
    }

    
    public void Reverse()
    {
        for (int i = 0, j = Length - 1; i < j; i++, j--)
        {
            T temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }
    }

    private void IncreaseLenght(int number = 1)
    {
        int newLength = _TrueLength;
        while (newLength <= _TrueLength + number)
        {
            newLength = (int)(newLength * 1.33 + number);
        }
        T[] newArray = new T[newLength];
        Array.Copy(_array, newArray, _TrueLength);
        _array = newArray;
    }


    private void ReduceSize(int size)
    {
        int newLength = _TrueLength;
        if (newLength == 0)
        {
            return;
        }
        while (newLength > _TrueLength - size)
        {
            newLength = (int)(newLength * 0.66);
        }
        if (newLength > 0)
        {
            T[] newArray = new T[newLength];
            Array.Copy(_array, newArray, newLength);

            _array = newArray;
        }

    }
}
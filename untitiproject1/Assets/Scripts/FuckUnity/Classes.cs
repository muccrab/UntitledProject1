using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes //Thank you Enigmativity on stack overflow. Person from whom I deffinitely didn't steal the code.
{
    public class Map<T1, T2>
    {
        private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

        public Map()
        {
            this.Forward = new Indexer<T1, T2>(_forward);
            this.Reverse = new Indexer<T2, T1>(_reverse);
        }

        public class Indexer<T3, T4>
        {
            private Dictionary<T3, T4> _dictionary;
            public Indexer(Dictionary<T3, T4> dictionary)
            {
                _dictionary = dictionary;
            }
            public T4 this[T3 index]
            {
                get { return _dictionary[index]; }
                set { _dictionary[index] = value; }
            }
        }

        public void Add(T1 t1, T2 t2)
        {
            _forward.Add(t1, t2);
            _reverse.Add(t2, t1);
        }

        public Indexer<T1, T2> Forward { get; private set; }
        public Indexer<T2, T1> Reverse { get; private set; }

        public bool ContainsKey(T1 key){
            return _forward.ContainsKey(key);
        }
        public bool ContainsValue(T2 value){
            return _reverse.ContainsKey(value);
        }
    }
    public class RoomNameDivided
    {
        public char type;
        public int roomNumber, hallNumber;
        public RoomNameDivided(string name){
            if (name[0]=='r')
            {
                type = 'r';
                string str = "";
                for (int i = 1; i<name.Length && name[i]>=48 && name[i]<=57;i++)
                {
                    str += name[i];
                }
                roomNumber = int.Parse(str);
                hallNumber = 0;
                return;
            }
            if (name[0]=='h')
            {
                type = 'h';
                string str = "";
                int i = 1;
                for (;i<name.Length && name[i]!='-' &&name[i]>=48 && name[i]<=57 ;i++){
                    str += name[i];
                }
                roomNumber = int.Parse(str);
                i++;
                str = "";
                for (;i<name.Length && name[i]>=48 && name[i]<=57;i++)
                {
                    str += name[i];
                }
                hallNumber = int.Parse(str);
                return;
            }

        }
    }
}

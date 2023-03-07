using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class MagazineArray : IEnumerable<Magazine>
    {
        private readonly Magazine[] _array;
        public int Length { get { return _array.Length; } }
        public Magazine this[int index]
        {
            get 
            {
                if (index < 0 || index >= _array.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return _array[index]; 
            }
            set
            {
                if (index < 0 || index >= _array.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                _array[index] = value;
            }
        }
        public MagazineArray(int n)
        {
            _array = new Magazine[n];
        }
        public MagazineArray(IEnumerable<Magazine> Array)
        {
            _array = Array.ToArray();
        }
        public IEnumerator<Magazine> GetEnumerator()
        {
            foreach(var item in _array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}

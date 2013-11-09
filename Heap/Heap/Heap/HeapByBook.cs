using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class HeapByBook
    {
        int[] _data = null;
        int index = 0;

        public HeapByBook(int aMax = 100)
        {
            _data = new int[aMax];
        }

        public void Insert(int aValue)
        {
            _data[++index] = aValue;
            Up();
        }

        public void RemoveFirst()
        {
            _data[1] = _data[index];
            _data[index] = 0;
            index--;
            Down();
        }

        private void Up()
        {
            var temp = _data[index]; //przypisz ostatni element do zmiennej tymczasowej
            var n = index;
            while ((n != 1) && (_data[n / 2] <= temp)) { //dopóki n jest różne od pierwszego elementu i rodzic elementu jest mniejszy od ostatniego
                _data[n] = _data[n / 2]; //przypisz wartość rodzica do jego dziecka
                n = n / 2; //ustaw indeks na rodzica
            }
            _data[n] = temp; //utaw wartość pod indeksem, na którym zakończyła się iteracja
        }

        private void Down()
        {
            int i = 1;
            while (true) {
                int p = 2 * i; //lewe dziecko
                if (p > index) //jeżeli index lewego dziecka jest spoza zakresu 
                    break; //daj se spokój
                if (p + 1 <= index) //jeżeli prawe dziecko ma indeks mxniejszy lub równy zakresowi
                    if (_data[p] < _data[p + 1]) //oraz jeżeli wartość lewgo dziecka jest mniejsza od wartośći prawego dziecka
                        p++; //zwiększ indeks
                if (_data[i] >= _data[p]) //jeżeli wartość dziecka jest większa bądź równa wartośći elementu to daj se spokój
                    break;

                //zamiana wartośći;
                int tmp = _data[p];
                _data[p] = _data[i];
                _data[i] = tmp;
                i = p;
            }
        }

        public void Print()
        {
            Print(1, 0);
        }

        private void Print(int aIndex, int aIndent)
        {
            if (aIndex > index) return;
            
            Console.WriteLine(Indent(aIndent) + _data[aIndex]);
            Print(aIndex * 2, aIndent + 1);
            Print(aIndex * 2 + 1, aIndent + 1);
        }

        private string Indent(int count)
        {
            return "".PadLeft(count * 2);
        }
    }
}

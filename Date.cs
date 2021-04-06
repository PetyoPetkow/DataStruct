namespace DataStruct
{
    using System;

    public struct Date
    {
        private const int MAX_MONTH_VALUE = 12;
         
        private int month;
        private int year;

        public int Day { get; set; }

        public int Month 
        {
            get
            {
                return this.month;
            }
            set
            {
                if (value <= MAX_MONTH_VALUE)
                {
                    this.month = value;
                }
                else
                {
                    throw new ArgumentException("Invalid months value!");
                }
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                if (value > 0)
                {
                    this.year = value;
                }
                else
                {
                    throw new ArgumentException("Invalid year value!");
                }
            }
        }

        public int GetNumerOfDaysInAMonth (Date date)
        {
            int result=0;

            switch (date.Month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    result = 31;
                    break;

                case 4: case 6: case 9: case 11:
                    result = 30;
                    break;

                case 2:
                    if (date.Year % 4 == 0)
                    {
                        result = 29;
                    }
                    else
                    {
                        result = 28;
                    }
                    break;
            }

            return result;
        }

        public void Add(ref Date date)
        {
            int daysToBeAdded = int.Parse(Console.ReadLine());
            int daysThatCanBeAdded = GetNumerOfDaysInAMonth(date) - date.Day;

            while (daysToBeAdded > daysThatCanBeAdded)
            {
                daysToBeAdded -= daysThatCanBeAdded;
                date.Month++;
                date.Day = 0;

                daysThatCanBeAdded = GetNumerOfDaysInAMonth(date) - date.Day;
                if (date.Month == MAX_MONTH_VALUE && daysToBeAdded+date.Day>GetNumerOfDaysInAMonth(date))
                {
                    date.Month = 0; 
                    date.Year++;
                }
            }

            date.Day += daysToBeAdded;
        }

        public void Remove(ref Date date)
        {
            int daysToBeRemoved = int.Parse(Console.ReadLine());
            int daysThatCanBeRemoved = date.Day;

            while (daysToBeRemoved > daysThatCanBeRemoved)
            {
                daysToBeRemoved -= daysThatCanBeRemoved;
                date.Day -= daysThatCanBeRemoved;
                    
                if (date.Day==0)
                {
                    date.Month--;
                    if (date.Month == 0)
                    {
                        date.Month = MAX_MONTH_VALUE;
                        date.Year--;
                        date.Day = GetNumerOfDaysInAMonth(date);
                    }
                    date.Day = GetNumerOfDaysInAMonth(date);
                }
 
                daysThatCanBeRemoved = date.Day;
            }

            date.Day -= daysToBeRemoved;
        }
    }
}

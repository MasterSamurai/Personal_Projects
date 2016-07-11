# Problem 19:
"""How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?"""
import calendar as c
def days_Dates(start_date, stop_date, weekday, day):
    weekdays = 0
    for i in range(start_date,stop_date+1):
        for j in range(1,13):
            if c.weekday(i,j,day) == weekday:
                weekdays += 1
    return weekdays

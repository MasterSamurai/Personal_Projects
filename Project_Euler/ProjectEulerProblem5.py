# Problem 5
"""What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?"""
def smallest_evenly_divisible_number(start, stop):
    for i in range(0,10**10,max(range(start,stop))):
        if all(i % n == 0 for n in range(start,stop)) and i != 0:
            return i
            break

# Problem 21:
"""Evaluate the sum of all the amicable numbers under 10000."""
def proper_Divisors(num):
    l = []
    for i in range(1, num):
        if num % i == 0:
            l.append(i)
    return l

def sum_Divisors(nums):
    return sum([i for i in nums])

def pairs(limit):
    return {(i, sum_Divisors(proper_Divisors(i))) for i in range(limit) if i != sum_Divisors(proper_Divisors(i))}

def sum_Amicable_Pairs(pair_list):
    summation = 0
    for list in pair_list:
        if list in pair_list and list[::-1] in pair_list:
            summation += list[1]
    return summation

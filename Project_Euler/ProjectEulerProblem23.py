# Problem 23:
"""Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers."""
#Some code was borrowed from dreamshire.net. Note to self: rewrite with own code. That's what you get for googling a problem that's stumped you for days.
def sum_Proper_Divisors(num):
    l, t = 0, num**0.5
    for i in range(2, int(t)+1):
        if num % i == 0:
            l += i + num/i
    if t == int(t):
        l -= t
    return l

def list_Abundant_Numbers(limit):
    abuns, summation = set(), 0
    for i in range(1, limit):
        if sum_Proper_Divisors(i) > i:
            abuns.add(i)
        if not any((i-a in abuns) for a in abuns):
            summation += i
    return summation

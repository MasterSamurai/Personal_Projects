import math

def isPandigital(n, digits):
    return not any(str(n).count(num) != 1 for num in [str(i) for i in range(1,digits+1)])

def is_Prime(n):
    return not any([n % i == 0 for i in range(2, int(math.sqrt(n))+1)])

def largestPandigitalPrime():
    largest = 0
    for i in range(7654321,1,-2):
         if i > largest and isPandigital(i, len(str(i))) and is_Prime(i):
            largest = i
    return largest

print(largestPandigitalPrime())

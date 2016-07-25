# Problem 37:
"""Find the sum of the only eleven primes that are both truncatable from left to right and right to left."""
def isPrime(num):
    return True if num != 1 and all(num % i != 0 for i in range(2, int(num**0.5)+1)) else False

def truncatablePrimes():
    primes2, summation = [], 0
    for j in range(9, 1000000, 2):
        s = ('%s' % j)
        if len(primes2) != 11 and all(isPrime(int(s[k:])) and isPrime(int(s[:k])) for k in range(len(s)-1,0,-1)) and isPrime(j):
            primes2.append(j)
            summation += j
    return summation

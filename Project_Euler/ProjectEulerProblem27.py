# Problem 27:
""""Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0."""

def is_Prime(num):
    return True if all([num % i != 0 for i in range(2, int(abs(num)**0.5)+1)]) else False

def prime_Range(num):
    primes, i = [2], 1
    while max(primes) < abs(num):
        i += 2
        if all(i % prime != 0 for prime in primes):
            primes.append(i)
    return primes if num > 0 else sorted([-x for x in primes])

def number_Consecutive_Primes(limit):
    maxPrime, prod = 0, 0
    for a in prime_Range(-limit):
        for b in prime_Range(limit):
            n = -1
            while is_Prime(n ** 2 + a * n + b):
                n += 1
            if n > maxPrime:
                maxPrime, prod = n, a*b
    return prod

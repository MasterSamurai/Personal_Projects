# Problem 7
"""What is the 10 001st prime number?"""
def nth_prime(n):
    primes, i = [2], 1
    while len(primes) < n:
        i += 2
        if all(i % prime != 0 for prime in primes):
            primes.append(i)
    return primes[n-1]

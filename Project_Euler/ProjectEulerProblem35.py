# Problem 35:
"""How many circular primes are there below one million?"""
def isPrime(num):
    return True if all(num % i != 0 for i in range(int(num**0.5),1,-1)) else False

def isCircularPrime(num):
    s = ('%s' % num)
    return True if all(isPrime(n) for n in [int(s[i:] + s[:i]) for i in range(1, len(s))]) else False

def listOfCircularPrimeCandidates(limit):
    primes = [2,3,5]
    for i in range(5,limit+1,2):
        digits = [int(i) for i in ('%s' % i)]
        if any(d % 2 == 0 for d in digits) or i % 3 == 0 or ('%s' % i).count('5') != 0 or not isPrime(i):
            continue
        else:
            primes.append(i)
    return primes

def circularPrimes(limit):
    return len([p for p in listOfCircularPrimeCandidates(limit) if isCircularPrime(p)])

import math

def is_Prime(n):
    return not any([n % i == 0 for i in range(2, int(math.sqrt(n))+1)])

def prime_Factorization(n):
    prime_Factors = []
    for o in set([q for q in range(2, 2 * (int(math.sqrt(n)) + 1)) if is_Prime(q)]):
        if (n % o) == 0:
            prime_Factors.append(o)
            continue
    return prime_Factors

def consecutive_Prime_Factor_Numbers():
    l = []
    for i in range(140000,1,-1):
        prime_Factors = prime_Factorization(i)
        if len(prime_Factors) != 4:
            l.clear()
            continue
        else:
            if len(prime_Factors) == 4 and len(l) < 1 or len(prime_Factors) == 4 and l.count(i+1) == 1:
                    l.append(i)
            if len(l) == 4:
                return l

print(consecutive_Prime_Factor_Numbers())
